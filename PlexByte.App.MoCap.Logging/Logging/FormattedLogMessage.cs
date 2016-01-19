using System;
using System.Drawing;

namespace MoCap.Logging
{
    public class FormattedLogMessage
    {
        public DateTime TimeStamp { get; set; }
        public Bitmap Type { get; set; }
        public string Message { get; set; }
        public int Level { get; set; }
        public string Thread { get; set; }
        public string Component { get; set; }
        public string MethodName { get; set; }
        public string MethodDefinition { get; set; }
        public string LineNumber { get; set; }
        public string SourceFile { get; set; }
        public string Context { get; set; }
        public string Attribute1 { get; set; }

        public FormattedLogMessage()
        {
        }

        public FormattedLogMessage(DateTime pTimeStamp, Bitmap pType, string pMessage, int pLevel, string pThread,
            string pComponent, string pMethodName, string pMethodDefinition, string pLineNumber, string pSourceFile,
            string pContext, string pAttribute1)
        {
            TimeStamp = pTimeStamp;
            Bitmap Type = pType;
            Message = pMessage;
            Level = pLevel;
            Thread = pThread;
            Component = pComponent;
            MethodName = pMethodName;
            MethodDefinition = pMethodDefinition;
            LineNumber = pLineNumber;
            SourceFile = pSourceFile;
            Context = pContext;
            Attribute1 = pAttribute1;
        }
    }
}
