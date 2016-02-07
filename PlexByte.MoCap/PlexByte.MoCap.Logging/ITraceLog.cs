using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PlexByte.MoCap.Logging
{
    public delegate void RolloverDay(object sender, EventArgs e);
    public delegate void RolloverSize(object sender, EventArgs e);

    public interface ITraceLog
    {
        event RolloverDay RolledoverDay;
        event RolloverSize RolledoverSize;

        string FileName { get; }
        string FilePath { get; }
        DateTime TraceDate { get; }
        DateTime TraceModified { get; }
        DateTime TraceCreated { get; }
        long MaxFileSize { get; }

        void WriteLog(List<TraceMessage> pMessages);
        List<TraceMessage> ReadLog(out long pNumberOfMessages);
        void RolloverDay(DateTime pDate, DateTime pOldDate);
        void RolloverSize(long pSize);
        void OnRolledoverDay(EventArgs e);
        void OnRolledoverSize(EventArgs e);
    }
}
