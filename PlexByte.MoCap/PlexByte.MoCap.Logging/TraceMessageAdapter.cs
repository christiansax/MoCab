using System;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;

namespace PlexByte.MoCap.Logging
{
    public class TraceMessageAdapter
    {
        public virtual string CodeException { get; set; }

        public virtual string Component { get; set; }

        public virtual string CustomDTValue { get; set; }

        public virtual string CustomIntValue { get; set; }

        public virtual string CustomStringValue { get; set; }

        public virtual int IndentLevel { get; set; }

        public virtual int Level { get; set; }

        public virtual int LineNumber { get; set; }

        public virtual string Message { get; set; }

        public virtual string Time { get; set; }

        public virtual string Method { get; set; }

        public virtual string ObjectId { get; set; }

        public virtual string ScopedMethod { get; set; }

        public virtual string Source { get; set; }

        public virtual string ThreadId { get; set; }

        public virtual string Topic { get; set; }

        public virtual Image Type { get; set; }

        public virtual Color MessageColor { get; set; }

        private static string _timeFormat = "HH:mm:ss.fff";
        private static string _dateFormat = "yyy/MM/dd";

        public TraceMessageAdapter(ITraceObject pTraceMessage,string pIndentSpacer)
        {
            Time = pTraceMessage.MessageDateTime.ToString(_timeFormat);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pTraceMessage.IndentLevel; i++)
                sb.Append(pIndentSpacer);
            sb.Append(pTraceMessage.Message);
            Message = sb.ToString();
            sb = null;

            switch (pTraceMessage.Type)
            {
                case TraceObjectType.EnterScope:
                    Type = Properties.Resources.EnterScope;
                    break;
                case TraceObjectType.ExitScope:
                    Type = Properties.Resources.ExitScope;
                    break;
                case TraceObjectType.Detail:
                    Type = Properties.Resources.Detail;
                    break;
                case TraceObjectType.Error:
                    Type = Properties.Resources.Error;
                    MessageColor = Color.FromArgb(242, 80, 80);
                    break;
                case TraceObjectType.Warning:
                    Type = Properties.Resources.Warning;
                    MessageColor = Color.FromArgb(237, 152, 66);
                    break;
                case TraceObjectType.Info:
                    Type = Properties.Resources.Info;
                    break;
                default:
                    Type = Properties.Resources.Feed;
                    break;
            }

            Level = pTraceMessage.Level;
            ThreadId = pTraceMessage.ThreadId;
            Component = pTraceMessage.Component;
            Method = pTraceMessage.Method;
            ScopedMethod = pTraceMessage.ScopedMethod;
            LineNumber = pTraceMessage.LineNumber;
            Source = pTraceMessage.Source;
            Topic = pTraceMessage.Topic;
            ObjectId = pTraceMessage.ObjectId.ToString();
            CustomDTValue = (pTraceMessage.CustomDateTimeValue != default(DateTime)) ? pTraceMessage.CustomDateTimeValue.ToString(_dateFormat + " " + _timeFormat) : null;
            CustomIntValue = (pTraceMessage.CustomIntValue != default(int)) ? pTraceMessage.CustomIntValue.ToString() : null;
            CustomStringValue = (pTraceMessage.CustomStringValue != String.Empty) ? pTraceMessage.CustomStringValue : null;
        }

    }
}