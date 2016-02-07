using System;
using System.Collections.Generic;

namespace PlexByte.MoCap.Logging
{
    public interface ITraceService
    {
        ITraceLog Log { get; }
        int CacheSize { get; }
        long MaxFileSize { get; }
        int TraceLevel { get; set; }
        string Component { get; }
        string Topic { get; }
        string TracePrefix { get; set; }

        void RegisterTrace(string pFileName, string pFilePath, string pComponent, string pTopic,
            int pLevel = default(int), int pCacheSize = 100, long pMaxFileSize = 763363328);

        void GetLogFile(string pFullPath);

        void Always(TraceMessage pMessage);
        void Always(string pMessage);

        void Exception(TraceMessage pMessage);
        void Exception(string pMessage, Exception e);

        void Error(TraceMessage pMessage);
        void Error(string pMessage);

        void Warning(TraceMessage pMessage);
        void Warning(string pMessage);

        void Info(TraceMessage pMessage);
        void Info(string pMessage);

        void Detail(TraceMessage pMessage);
        void Detail(string pMessage);

        void Verbose(TraceMessage pMessage);
        void Verbose(string pMessage);

        void EnterScope(TraceMessage pMessage);
        void EnterScope(string pMessage);

        void ExitScope(TraceMessage pMessage);
        void ExitScope(string pMessage);
    }
}
