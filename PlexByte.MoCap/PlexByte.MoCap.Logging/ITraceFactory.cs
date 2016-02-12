using System;
using System.Collections.Generic;

namespace PlexByte.MoCap.Logging
{
    public interface ITraceFactory
    {
        ILogObject LogObject { get; }
        IndentHelper IndentHelperObject { get; }
        ILogObject CreateLogObject(string pFileName, string pFilePath, bool pRead, long pMaxFileSize, LogObjectType pLogObjectType);

        ITraceObject CreateTraceObject(string pMessage,
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
            Exception pCodeException = null);
    }
}