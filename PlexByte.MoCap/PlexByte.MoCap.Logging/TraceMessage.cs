using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PlexByte.MoCap.Logging
{
    [Serializable]
    public enum TraceType
    {
        None,
        Exception,
        Error,
        Warning,
        Info,
        Detail,
        Verbose,
        EnterScope,
        ExitScope
    };

    [Serializable]
    public enum TraceLevel
    {
        None = 0,
        Exception = 5,
        Error = 10,
        Warning = 20,
        Info = 40,
        Detail = 60,
        Verbose = 80,
        All = 100
    };

    [Serializable]
    public class TraceMessage
    {
        public string Message { get; }
        public string Component { get; }
        public string Topic { get; }
        public string ThreadId { get; }
        public string Source { get; }
        public string Method { get; }
        public string CustomStringValue { get; set; }
        public string ScopedMethod { get; }
        public int Level { get; }
        public int LineNumber { get; }
        public string ObjectId { get; }
        public int IndentLevel { get; }
        public int CustomIntValue { get; set; }
        public TraceType Type { get; }
        public DateTime CustomDateTimeValue { get; set; }
        public DateTime MessageDateTime { get; }
        public Exception CodeException { get; set; }

        public TraceMessage(string pMessage, TraceType pType, int pLevel = -1, string pComponent = "", 
            string pTopic = "", string pThreadId = "", int pIndentLevel = 0, string pObjectId = "",
            string pCustomStringValue = "", int pCustomIntValue = 0, DateTime pCustomDateTimeValue = new DateTime(),
            DateTime pMessageTime = new DateTime(), string pMethod = "", string pScopedMethod ="", int pLineNumber = 0, string pSource = "", 
            Exception pCodeException = null)
        {
            Message = pMessage;
            Component = pComponent;
            Topic = pTopic;
            ThreadId = pThreadId;
            Source = pSource;
            Method = pMethod;
            LineNumber = pLineNumber;
            CustomStringValue = pCustomStringValue;
            CustomDateTimeValue = pCustomDateTimeValue;
            CustomIntValue = pCustomIntValue;
            ScopedMethod = pScopedMethod;
            if (pLevel == -1)
            {
                switch (pType)
                {
                    case TraceType.None:
                        Level = (int) TraceLevel.None;
                        break;
                    case TraceType.Error:
                        Level = (int) TraceLevel.Error;
                        break;
                    case TraceType.Warning:
                        Level = (int) TraceLevel.Warning;
                        break;
                    case TraceType.Exception:
                        Level = (int) TraceLevel.Exception;
                        break;
                    case TraceType.Info:
                        Level = (int) TraceLevel.Info;
                        break;
                    case TraceType.Detail:
                        Level = (int) TraceLevel.Detail;
                        break;
                    case TraceType.Verbose:
                        Level = (int) TraceLevel.Verbose;
                        break;
                    case TraceType.EnterScope:
                        Level = (int) TraceLevel.None;
                        break;
                    case TraceType.ExitScope:
                        Level = (int) TraceLevel.None;
                        break;
                    default:
                        Level = (int) TraceLevel.Info;
                        break;
                }
            }
            ObjectId = pObjectId;
            IndentLevel = pIndentLevel;
            Type = pType;
            MessageDateTime = (pMessageTime == default(DateTime)) ? DateTime.Now : pMessageTime;
            CodeException = pCodeException;
        }
    }
}