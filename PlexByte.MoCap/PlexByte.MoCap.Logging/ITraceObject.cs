using System;

namespace PlexByte.MoCap.Logging
{
    public interface ITraceObject
    {
        string Message { get; set; }

        TraceObjectType Type { get; set; }

        int Level { get; set; }

        string Component { get; set; }

        string Topic { get; set; }

        string ThreadId { get; set; }

        string Source { get; set; }

        string Method { get; set; }

        string ScopedMethod { get; set; }

        int LineNumber { get; set; }

        string ObjectId { get; set; }

        int IndentLevel { get; set; }

        DateTime MessageDateTime { get; set; }

        Exception CodeException { get; set; }

        int CustomIntValue { get; set; }

        string CustomStringValue { get; set; }

        DateTime CustomDateTimeValue { get; set; }
    }
}