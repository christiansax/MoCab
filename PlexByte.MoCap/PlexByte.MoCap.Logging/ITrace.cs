using System;
using System.Collections.Generic;

namespace PlexByte.MoCap.Logging
{
    public interface ITrace
    {
        string ComponentName { get; }
        List<ITraceObject> TraceMessages { get; }
        int TraceLevel { get; set; }
        int CacheSize { get; set; }
        long MaxFileSize { get; set; }
        string TracePrefix { get; set; }

        ITrace GetInstance(string pComponent);
        List<TraceMessageAdapter> ReadLogFile(out int pNumMessages, string pFullFilePath);
        List<ITraceObject> ReadLogFileRaw(out int pNumMessages, string pFullFilePath);
        void Always(ITraceObject pMessage);
        void Always(string pMessage);
        void Exception(string pMessage, Exception pException);
        void Error(string pMessage);
        void Warning(string pMessage);
        void Info(string pMessage);
        void Detail(string pMessage);
        void Verbose(string pMessage);
        void All(string pMessage);
        void EnterScope(string pMessage);
        void ExitScope(string pMessage);
        void All(ITraceObject pMessage);
        void EnterScope(ITraceObject pMessage);
        void ExitScope(ITraceObject pMessage);
        void Exception(ITraceObject pMessage);
        void Error(ITraceObject pMessage);
        void Warning(ITraceObject pMessage);
        void Info(ITraceObject pMessage);
        void Detail(ITraceObject pMessage);
        void Verbose(ITraceObject pMessage);
        void RegisterComponent(string pFileName,
            string pComponent = "",
            string pFilePath = "",
            int pLevel = 40,
            int pCacheSize = 100,
            long pMaxFileSize = 7000000);
    }
}