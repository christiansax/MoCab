using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace PlexByte.MoCap.Logging
{
    public class TraceFactory : ITraceFactory
    {
        public IndentHelper IndentHelperObject => _indentHelperObject;
        public ILogObject LogObject => _logObject;

        private IndentHelper _indentHelperObject =new IndentHelper();
        private List<ITraceObject> _traceMessages = new List<ITraceObject>();
        private ILogObject _logObject = null;
        private LogObjectType _logType;

        public virtual ILogObject CreateLogObject(string pFileName,
            string pFilePath,
            bool pRead,
            long pMaxFileSize,
            LogObjectType pLogObjectType)
        {
            switch (pLogObjectType)
            {
                case LogObjectType.BinaryFile:
                    _logObject = new BinaryLogFile(pFileName, pFilePath);
                    _logObject.MaxFileSize = pMaxFileSize;
                    _logType=LogObjectType.BinaryFile;
                    break;
                default:
                    _logObject = new BinaryLogFile(pFileName, pFilePath);
                    _logObject.MaxFileSize = pMaxFileSize;
                    _logType = LogObjectType.BinaryFile;
                    break;
            }
            return _logObject;
        }

        public virtual ITraceObject CreateTraceObject(string pMessage,
            TraceObjectType pType,
            int pLevel = -1,
            string pComponent = "",
            string pTopic = "",
            string pThreadId = "",
            string pObjectId = "",
            string pCustomStringValue = "",
            int pCustomIntValue = -1,
            DateTime pCustomDateTimeValue = default(DateTime),
            string pMethod = "",
            string pScopedMethod = "",
            DateTime pMessageTime = default(DateTime),
            int pLineNumber = -1,
            string pSource = "",
            int pIndentLevel = 0,
            Exception pCodeException = null)
        {
            StackFrame caller = new StackTrace(true).GetFrame(2);
            ParameterInfo[] parameters = caller.GetMethod().GetParameters();
            string component = (pComponent.Length > 0) ? pComponent : Assembly.GetCallingAssembly().GetName().Name;
            string topic = (pTopic.Length > 0) ? pTopic: Assembly.GetCallingAssembly().GetName().Name;
            string threadId = (pThreadId.Length > 0) ? pThreadId:Thread.CurrentThread.ManagedThreadId.ToString();
            string customStringValue = (pCustomStringValue.Length > 0) ? pCustomStringValue:string.Empty;
            DateTime customDateTimeValue = (pCustomDateTimeValue!=default(DateTime)) ? pCustomDateTimeValue:default(DateTime);
            int customIntValue = (pCustomIntValue!=-1) ? pCustomIntValue:0;
            string member = (pMethod.Length > 0) ? pMethod:caller.GetMethod().Name;
            string source = (pSource.Length > 0) ? pSource:caller.GetFileName();
            int lineNumber = (pLineNumber!= -1) ? pLineNumber:caller.GetFileLineNumber();
            string scopedMethod = member + "(";
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i == 0)
                    scopedMethod += "[" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
                else
                    scopedMethod += ", [" + parameters[i].ParameterType + " | " + parameters[i].Name + "]";
            }
            scopedMethod += ")";
            int level = pLevel;
            int indent = 0;
            switch (pType)
            {
                case TraceObjectType.EnterScope:
                    level = (pLevel == -1)
                        ? level = (int) TraceObjectType.SysInfo
                        : level = pLevel;
                    try
                    {
                        _indentHelperObject.AddIndentLevel(topic,
                            scopedMethod,
                            threadId,
                            _indentHelperObject.CurrentIndent);
                        indent = _indentHelperObject.CurrentIndent;
                    }
                    catch (Exception exp) { /* Not used yet */ }
                    break;
                case TraceObjectType.ExitScope:
                    level = (pLevel == -1)
                        ? level = (int) TraceObjectType.SysInfo
                        : level = pLevel;
                    try
                    {
                        indent = _indentHelperObject.GetIndentLevel(topic, scopedMethod, threadId) - 1;
                        _indentHelperObject.DeleteIndent(topic, threadId, scopedMethod);
                    }
                    catch (Exception exp) { /* Not used yet */ }
                    break;
                default:
                    level = (pLevel == -1)
                        ? level = (int) TraceObjectType.SysInfo
                        : level = pLevel;
                    try { indent = _indentHelperObject.GetIndentLevel(topic, scopedMethod, threadId); }
                    catch (Exception exp) { /* Not used yet */ }
                    break;
            }
            string objectId = (pObjectId.Length>0) ? pObjectId:String.Empty;
            // int indentLevel = GetIndentLevel(scopedMethod, pType);
            DateTime messageDateTime = (pMessageTime!=default(DateTime)) ? pMessageTime:DateTime.Now;
            Exception codeException = (pCodeException != null) ? pCodeException : null;

            return new TraceMessage(pMessage, pType, level, component, topic, threadId, indent, objectId,
                customStringValue, customIntValue, customDateTimeValue, DateTime.Now, member, scopedMethod,
                lineNumber, source, codeException);
        }
    }
}