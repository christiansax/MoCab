using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PlexByte.MoCap.Logging
{
    public sealed class Trace : ITrace,
        IDisposable
    {
        public List<ITraceObject> TraceMessages => _traceMessages;
        public ILogObject LogObject { get; set; }
        public ITraceFactory TraceFactory { get; set; }
        public string ComponentName => _componentName;
        public string FileName => LogObject.LogName;
        public string FilePath => LogObject.LogPath;
        public int TraceLevel { get; set; }
        public int CacheSize { get; set; }
        public long MaxFileSize { get; set; }
        public string TracePrefix { get; set; }
        public DateTime TraceDate => LogObject.TraceDate.Date;

        private static Dictionary<string, Trace> _instances = new Dictionary<string, Trace>();
        private List<ITraceObject> _traceMessages = null;
        private string _componentName = string.Empty;
        private static object _lockObject = new object();

        private Trace(string pComponent)
        {
            _traceMessages = new List<ITraceObject>();
            _componentName = pComponent;
        }

        public List<TraceMessageAdapter> ReadLogFile(out int pNumMessages, string pFullFilePath)
        {
            TraceFactory.CreateLogObject(Path.GetFileName(pFullFilePath), Path.GetDirectoryName(pFullFilePath), true, 0, LogObjectType.BinaryFile);
            pNumMessages = 0;
            return LogObject.Read(out pNumMessages);
        }

        public List<ITraceObject> ReadLogFileRaw(out int pNumMessages, string pFullFilePath)
        {
            TraceFactory.CreateLogObject(Path.GetFileName(pFullFilePath), Path.GetDirectoryName(pFullFilePath), true, 0, LogObjectType.BinaryFile);
            pNumMessages = 0;
            return LogObject.ReadLogFileRaw(out pNumMessages);
        }

        public static ITrace GetInstance(string pComponent)
        {

            lock (_lockObject)
            {
                if (!_instances.ContainsKey(pComponent)) _instances.Add(pComponent, new Trace(pComponent));
            }
            return _instances[pComponent];

        }

        public void Always(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Always(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.SysInfo)); }

        public void Exception(string pMessage, Exception pException)
        {
            ITraceObject trace = CreateMessage(pMessage, TraceObjectType.Exception);
            pException = trace.CodeException;
            LogMessage(trace);
        }

        public void Error(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.Error)); }

        public void Warning(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.Warning)); }

        public void Info(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.Info)); }

        public void Detail(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.Detail)); }

        public void Verbose(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.Verbose)); }

        public void All(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.All)); }

        public void EnterScope(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.EnterScope)); }

        public void ExitScope(string pMessage) { LogMessage(CreateMessage(pMessage, TraceObjectType.ExitScope)); }

        public void All(ITraceObject pMessage) { LogMessage(pMessage); }

        public void EnterScope(ITraceObject pMessage) { LogMessage(pMessage); }

        public void ExitScope(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Exception(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Error(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Warning(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Info(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Detail(ITraceObject pMessage) { LogMessage(pMessage); }

        public void Verbose(ITraceObject pMessage) { LogMessage(pMessage); }

        public void RegisterComponent(string pFileName,
            string pComponent = "",
            string pFilePath = "",
            int pLevel = 40,
            int pCacheSize = 100,
            long pMaxFileSize = 7000000)
        {
            if (pComponent.Length < 1)
            {
                pComponent = Assembly.GetCallingAssembly().GetName().Name;
            }
            if (pFilePath.Length < 1)
            {
                pFilePath = Assembly.GetExecutingAssembly().Location;
            }
            _componentName = pComponent;
            TraceFactory = new TraceFactory();
            LogObject = TraceFactory.CreateLogObject(pFileName, pFilePath, false, pMaxFileSize, LogObjectType.BinaryFile);

        }

        private ITraceObject CreateMessage(string pMessage, TraceObjectType pType) { return TraceFactory.CreateTraceObject(pMessage, pType); }

        private void LogMessage(ITraceObject pMessage)
        {
            if (pMessage.Level <= TraceLevel)
            {
                lock (_lockObject)
                {
                    _traceMessages.Add(pMessage);
                    if (_traceMessages.Count >= CacheSize)
                    {
                        LogObject.Write(_traceMessages);
                        _traceMessages.Clear();
                    }
                }
            }
        }

        public void Dispose()
        {
            _traceMessages.Add(TraceFactory.CreateTraceObject($"Disposing trace object for component {ComponentName}",
                TraceObjectType.SysInfo));
            LogObject.Write(_traceMessages);
            _traceMessages.Clear();
            if (_instances.ContainsKey(ComponentName)) _instances.Remove(ComponentName);
        }
    }
}