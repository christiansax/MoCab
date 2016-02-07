using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace PlexByte.MoCap.Logging
{
    public class TraceService:ITraceService
    {
        #region Implementation of ITraceService

        public ITraceLog Log => _log;
        public int CacheSize => _cacheSize;
        public long MaxFileSize => _maxFileSize;
        public int TraceLevel { get; set; }
        public string Component => _component;
        public string Topic => _topic;

        public string TracePrefix { get; set; }

        private ITraceLog _log = null;
        private int _cacheSize;
        private long _maxFileSize;
        private string _component;
        private string _topic;
        private List<KeyValuePair<string, int>> _methodIndentList = null;
        private List<TraceMessage> _traceMessages = null;
        private readonly object _lockObject = new object();
        private bool _isLocked = false;

        public ITraceLog GetInstance(string pFileName, string pFilePath)
        {
            if (Log == null)
                _log=new BinaryTraceLog(pFileName, pFilePath);

            return _log;
        }

        public void GetLogFile(string pFullPath)
        {
            GetInstance(Path.GetFileName(pFullPath), Path.GetDirectoryName(pFullPath));
        }

        public void RegisterTrace(string pFileName, string pFilePath, string pComponent, string pTopic, 
            int pLevel = default(int), int pCacheSize = 100, long pMaxFileSize = 763363328)
        {
            _component = pComponent.Length > 1 ? pComponent : Assembly.GetCallingAssembly().GetName().Name;
            _topic = pTopic.Length > 1 ? pTopic : Assembly.GetCallingAssembly().GetName().Name;
            TraceLevel = pLevel == default(int) ? (int) Logging.TraceLevel.Info : pLevel;
            _cacheSize = pCacheSize;
            _maxFileSize = pMaxFileSize;
            _log = new BinaryTraceLog(pFileName, pFilePath, pMaxFileSize, DateTime.Now);
            _traceMessages=new List<TraceMessage>();
        }

        public void Always(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Always(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.None));
        }

        public void Exception(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Exception(string pMessage, Exception e)
        {
            TraceMessage message = CreateDefaultTraceMessage(pMessage, TraceType.Exception);
            message.CodeException = e;
            LogMessage(message);
        }

        public void Error(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Error(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.Error));
        }

        public void Warning(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Warning(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.Warning));
        }

        public void Info(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Info(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.Info));
        }

        public void Detail(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Detail(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.Detail));
        }

        public void Verbose(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void Verbose(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.Verbose));
        }

        public void EnterScope(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void EnterScope(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.EnterScope));
        }

        public void ExitScope(TraceMessage pMessage)
        {
            LogMessage(pMessage);
        }

        public void ExitScope(string pMessage)
        {
            LogMessage(CreateDefaultTraceMessage(pMessage, TraceType.ExitScope));
        }

        /// <summary>
        /// Acquires the lock within the given timeout
        /// </summary>
        /// <param name="pTimeout">The timeout for the lock to be acquired</param>
        /// <param name="pMessage">The message describing the result</param>
        /// <returns>Boolean returning true if the lock was successfully acquired</returns>
        private bool AcquireLock(int pTimeout, out string pMessage)
        {
            pMessage = string.Empty;
            try
            {
                Monitor.TryEnter(_lockObject, pTimeout, ref _isLocked);
                if (_isLocked)
                {
                    pMessage = String.Format("Lock successfully acquired. [Timeout={0}]", pTimeout);
                    return true;
                }
                if (!_isLocked)
                {
                    pMessage = String.Format("Failed to acquire lock within timeout specified [Timeout={0}]", pTimeout);
                    return false;
                }
            }
            catch { }
            if (!_isLocked)
                pMessage = String.Format("Failed to acquire lock within timeout specified [Timeout={0}]", pTimeout);
            return false;
        }

        /// <summary>
        /// Tries to release the lock
        /// </summary>
        /// <param name="pMessage">The message describing the result of this action</param>
        /// <returns>Boolean returning true if the lock was successfully released</returns>
        private bool ReleaseLock(out string pMessage)
        {
            try
            {
                if (_isLocked)
                {
                    Monitor.Exit(_lockObject);
                    _isLocked = false;
                    pMessage = String.Format("Lock successfully released");
                    return true;
                }
            }
            catch { }
            pMessage = String.Format("Failed to release the lock");
            return false;
        }

        private TraceMessage CreateDefaultTraceMessage(string pMessage,TraceType pType)
        {
            StackFrame caller = new StackTrace(true).GetFrame(2);
            ParameterInfo[] parameters = caller.GetMethod().GetParameters();
            string component = Assembly.GetCallingAssembly().GetName().Name;
            string topic = Assembly.GetCallingAssembly().GetName().Name;
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();
            string customStringValue = string.Empty;
            DateTime customDateTimeValue = default(DateTime);
            int customIntValue = 0;
            string member = caller.GetMethod().Name;
            string scopedMethod = member+"(";
            string source = caller.GetFileName();
            int lineNumber = caller.GetFileLineNumber();
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == 0)
                    scopedMethod += "[" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
                else
                    scopedMethod += ", [" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
            }
            scopedMethod += ")";
            int level = 0;
            switch (pType)
            {
                case TraceType.None:
                    level = (int)MoCap.Logging.TraceLevel.None;
                    break;
                case TraceType.Error:
                    level = (int)MoCap.Logging.TraceLevel.Error;
                    break;
                case TraceType.Warning:
                    level = (int)MoCap.Logging.TraceLevel.Warning;
                    break;
                case TraceType.Exception:
                    level = (int)MoCap.Logging.TraceLevel.Exception;
                    break;
                case TraceType.Info:
                    level = (int)MoCap.Logging.TraceLevel.Info;
                    break;
                case TraceType.Detail:
                    level = (int)MoCap.Logging.TraceLevel.Detail;
                    break;
                case TraceType.Verbose:
                    level = (int)MoCap.Logging.TraceLevel.Verbose;
                    break;
                case TraceType.EnterScope:
                    level = (int)MoCap.Logging.TraceLevel.None;
                    break;
                case TraceType.ExitScope:
                    level = (int)MoCap.Logging.TraceLevel.None;
                    break;
                default:
                    level = (int)MoCap.Logging.TraceLevel.Info;
                    break;
            }
            string objectId = "";
            int indentLevel = GetIndentLevel(scopedMethod, pType);
            TraceType type = pType;
            DateTime messageDateTime = DateTime.Now;
            Exception codeException = null;

            return new TraceMessage(pMessage, pType, level, component, topic, threadId, indentLevel, objectId, 
                customStringValue,customIntValue, customDateTimeValue, DateTime.Now, member, scopedMethod,
                lineNumber, source, codeException);
        }

        private void LogMessage(TraceMessage pMessage)
        {
            string lockMessage=String.Empty;
            if (pMessage.Level <= TraceLevel)
            {
                try
                {
                    if (AcquireLock(1000, out lockMessage))
                    {
                        if (pMessage.MessageDateTime.Date != Log.TraceDate.Date)
                        {
                            Log.RolloverDay(Log.TraceDate, pMessage.MessageDateTime);
                        }
                        _traceMessages.Add(pMessage);
                        if (_traceMessages.Count >= _cacheSize)
                        {
                            Log.WriteLog(_traceMessages);
                            _traceMessages.Clear();
                        }
                    }
                    else
                        throw new Exception("Failed to accuire lock when rolling over to new log file...");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    if (_isLocked)
                        if (!ReleaseLock(out lockMessage))
                            throw new Exception(lockMessage);
                }
            }
        }

        private int GetIndentLevel(string pScopedMethod, TraceType pType)
        {
            KeyValuePair<string, int> lastEntry=new KeyValuePair<string, int>(pScopedMethod, 0);
            if (_methodIndentList == null)
            {
                _methodIndentList = new List<KeyValuePair<string, int>>();
            }

            if (_methodIndentList.FindLastIndex(x => x.Key == pScopedMethod) >= 0)
            {
                lastEntry = _methodIndentList.FindLast(x => x.Key == pScopedMethod);
            }
            else
            {
                lastEntry = _methodIndentList.Count >= 1
                    ? _methodIndentList[_methodIndentList.Count - 1]
                    : lastEntry;
            }

            switch (pType)
            {
                case TraceType.EnterScope:
                    _methodIndentList.Add(lastEntry = new KeyValuePair<string, int>(pScopedMethod, lastEntry.Value + 1));
                    break;
                case TraceType.ExitScope:
                    if(_methodIndentList.FindLastIndex(x=>x.Key==pScopedMethod)>=0)
                        _methodIndentList.RemoveAt(_methodIndentList.FindLastIndex(x => x.Key == pScopedMethod));
                    break;
                default:
                    break;
            }
            return lastEntry.Value;
        }

        #endregion
    }
}
