using System;
using System.IO;

namespace MoCap.Security
{
    public class SessionEventArgs
    {
        public Stream Data { get; set; } = null;
        public string Message { get; set; } = null;
        public DateTime EventDateTime { get; }

        public SessionEventArgs(Stream pStream)
        {
            Data = pStream;
            EventDateTime = DateTime.Now;
        }

        public SessionEventArgs(string pDataSent)
        {
            Message = pDataSent;
            EventDateTime = DateTime.Now;
        }
    }
}
