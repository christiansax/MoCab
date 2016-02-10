using System;
using System.Collections.Generic;

namespace PlexByte.MoCap.Logging
{
    public delegate void RolloverDay(ILogObject sender, EventArgs e);
    public delegate void RolloverSize(ILogObject sender, EventArgs e);
    public interface ILogObject
    {
        event RolloverDay DayRolledOver;
        event RolloverDay SizeRolledOver;
        string LogName { get; set; }

        DateTime TraceDate { get; }

        string LogPath { get; set; }

        long MaxFileSize { get; set; }

        string DateFormat { get; set; }

        string TimeFormat { get; set; }

        string DisplayDateFormat { get; set; }

        string DisplayTimeFormat { get; set; }

        void Write(List<ITraceObject> pMessages);

        List<TraceMessageAdapter> Read(out int pNumberOfMessages);
        List<ITraceObject> ReadLogFileRaw(out int pNumberOfMessages);

        void RolloverDay(DateTime pDate, DateTime pOldDate);

        void RolloverSize(long pSize);

        void OnRolledOverDay(EventArgs e);

        void OnRolledOverSize(EventArgs e);

    }
}