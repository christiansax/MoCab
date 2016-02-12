using System;

namespace PlexByte.MoCap.Logging
{
    public class TraceMessage : ITraceObject
    {
        public Exception CodeException { get; set; }

        public string Component { get; set; }

        public DateTime CustomDateTimeValue { get; set; }

        public int CustomIntValue { get; set; }

        public string CustomStringValue { get; set; }

        public int IndentLevel { get; set; }

        public int Level { get; set; }

        public int LineNumber { get; set; }

        public string Message { get; set; }

        public DateTime MessageDateTime { get; set; }

        public string Method { get; set; }

        public string ObjectId { get; set; }

        public string ScopedMethod { get; set; }

        public string Source { get; set; }

        public string ThreadId { get; set; }

        public string Topic { get; set; }

        public TraceObjectType Type { get; set; }

        public TraceMessage(string pMessage, TraceObjectType pType, int pLevel = -1, string pComponent = "",
            string pTopic = "", string pThreadId = "", int pIndentLevel = 0, string pObjectId = "",
            string pCustomStringValue = "", int pCustomIntValue = 0, DateTime pCustomDateTimeValue = new DateTime(),
            DateTime pMessageTime = new DateTime(), string pMethod = "", string pScopedMethod = "", int pLineNumber = 0, string pSource = "",
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
                    case TraceObjectType.All:
                        Level = (int)TraceObjectType.All;
                        break;
                    case TraceObjectType.Error:
                        Level = (int)TraceObjectType.Error;
                        break;
                    case TraceObjectType.Warning:
                        Level = (int)TraceObjectType.Warning;
                        break;
                    case TraceObjectType.Exception:
                        Level = (int)TraceObjectType.Exception;
                        break;
                    case TraceObjectType.Info:
                        Level = (int)TraceObjectType.Info;
                        break;
                    case TraceObjectType.Detail:
                        Level = (int)TraceObjectType.Detail;
                        break;
                    case TraceObjectType.Verbose:
                        Level = (int)TraceObjectType.Verbose;
                        break;
                    case TraceObjectType.EnterScope:
                        Level = (int)TraceObjectType.SysInfo;
                        break;
                    case TraceObjectType.ExitScope:
                        Level = (int)TraceObjectType.SysInfo;
                        break;
                    default:
                        Level = (int)TraceObjectType.Info;
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