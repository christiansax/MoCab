using System;
using System.Text;
using System.Drawing;

namespace PlexByte.MoCap.Logging
{
    public class TraceMessageAdapter
    {
        public string TimeStamp { get; set; }
        public Image Type { get; set; }
        public string Message { get; set; }
        public int Level { get; set; }
        public string Thread { get; set; }
        public string Component { get; set; }
        public string MethodName { get; set; }
        public string MethodDefinition { get; set; }
        public int LineNumber { get; set; }
        public string SourceFile { get; set; }
        public string Context { get; set; }
        public string Attribute1 { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Color MessageColor { get; } = Color.Transparent;

        private const string TimeFormat = "HH:mm:ss.fff";

        /// <summary>
        /// Creates a formatted log message from a logMessage
        /// </summary>
        /// <param name="pLogMessage">The logmessage to use</param>
        /// <param name="pIndentSpacer">The indent specifier to use</param>
        public TraceMessageAdapter(PlexByte.MoCap.Logging.TraceMessage pLogMessage, string pIndentSpacer)
        {
            TimeStamp = pLogMessage.MessageDateTime.ToString(TimeFormat);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pLogMessage.IndentLevel; i++)
                sb.Append(pIndentSpacer);
            sb.Append(pLogMessage.Message);
            Message = sb.ToString();
            sb = null;

            switch (pLogMessage.Type)
            {
                case TraceType.EnterScope:
                    Type = Properties.Resources.EnterScope;
                    break;
                case TraceType.ExitScope:
                    Type = Properties.Resources.ExitScope;
                    break;
                case TraceType.Detail:
                    Type = Properties.Resources.Detail;
                    break;
                case TraceType.Error:
                    Type = Properties.Resources.Error;
                    MessageColor = Color.FromArgb(242, 80, 80);
                    break;
                case TraceType.Warning:
                    Type = Properties.Resources.Warning;
                    MessageColor = Color.FromArgb(237, 152, 66);
                    break;
                case TraceType.Info:
                    Type = Properties.Resources.Info;
                    break;
                default:
                    Type = Properties.Resources.Feed;
                    break;
            }

            Level = pLogMessage.Level;
            Thread = pLogMessage.ThreadId;
            Component = pLogMessage.Component;
            MethodName = pLogMessage.Method;
            MethodDefinition = pLogMessage.ScopedMethod;
            LineNumber = pLogMessage.LineNumber;
            SourceFile = pLogMessage.Source;
            Context = pLogMessage.Topic;
            Attribute1 = pLogMessage.ObjectId.ToString();
        }

        /// <summary>
        /// Creates a formatted log message from direct imputs
        /// </summary>
        /// <param name="pTimeStamp">The datetime of the message</param>
        /// <param name="pType">The message bitmap to display</param>
        /// <param name="pMessage">The message</param>
        /// <param name="pLevel">The level of this message</param>
        /// <param name="pThread">The thread of this message</param>
        /// <param name="pComponent">The component</param>
        /// <param name="pMethodName">The method name from which it came from</param>
        /// <param name="pMethodDefinition">The method definition</param>
        /// <param name="pLineNumber">The line number this message was generated</param>
        /// <param name="pSourceFile">The source file from which this came from</param>
        /// <param name="pContext">The context of this message</param>
        /// <param name="pAttribute1">The attribute1 of this message</param>
        public TraceMessageAdapter(DateTime pTimeStamp, Image pType, string pMessage, int pLevel, string pThread,
            string pComponent, string pMethodName, string pMethodDefinition, int pLineNumber, string pSourceFile,
            string pContext, string pAttribute1)
        {
            TimeStamp = pTimeStamp.ToString(TimeFormat);
            Type = pType;
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