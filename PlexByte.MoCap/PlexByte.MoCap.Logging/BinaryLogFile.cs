using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PlexByte.MoCap.Logging
{
    public class BinaryLogFile : ILogObject
    {
        private string _name;
        private string _path;
        private long _maxFileSize=-1;
        private long _currentFileSize;
        private static string _dateFormat="yyyyMMdd";
        private static string _timeFormat="HHmmss_fff";
        private static string _displayDateFormat = "yyyy/MM/dd";
        private static string _displayTimeFormat = "HH:mm:ss.fff";
        private DateTime _traceDate;
        private DateTime _traceModified;
        private DateTime _traceCreated;
        private static object _lockObject = new object();
        private int _fileIndex=0;
        private List<ITraceObject>_messageCache=new List<ITraceObject>(); 

        public event RolloverDay DayRolledOver;
        public event RolloverDay SizeRolledOver;

        public DateTime TraceDate => _traceDate;

        public string LogName { get { return _name; } set { _name = value; } }

        public string LogPath { get { return _path; } set { _path = value; } }

        public long MaxFileSize { get { return _maxFileSize; } set { _maxFileSize = value; } }

        public string DateFormat { get { return _dateFormat; } set { _dateFormat = value; } }

        public string TimeFormat { get { return _timeFormat; } set { _timeFormat = value; } }

        public string DisplayDateFormat { get { return _displayDateFormat; } set { _displayDateFormat = value; } }

        public string DisplayTimeFormat { get { return _displayTimeFormat; } set { _displayTimeFormat = value; } }

        public BinaryLogFile() { }
        public BinaryLogFile(string pFileName, string pFilePath) { Initialize(pFileName, pFilePath, MaxFileSize); }

        public virtual void Write(List<ITraceObject> pMessages)
        {
            string fileFullPath = _path + "\\" + _traceDate.Date.ToString(_dateFormat) + "\\" + _name;
            using (Stream stream = File.Open(fileFullPath, File.Exists(fileFullPath)
                ? FileMode.Append
                : FileMode.Create))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                foreach (TraceMessage tmp in pMessages)
                {
                    if (tmp.MessageDateTime.Date == _traceDate.Date)
                        binFmt.Serialize(stream, tmp);
                    else
                    {
                        // Day rollover
                        RolloverDay(tmp.MessageDateTime, _traceDate);
                        stream.Flush();
                        if (_messageCache == null) { _messageCache = new List<ITraceObject>(); }
                        _messageCache.AddRange(pMessages.Where(x => x.MessageDateTime.Date == tmp.MessageDateTime.Date));
                        return;
                    }
                }
                stream.Flush();
            }
            FileInfo fi = new FileInfo(fileFullPath);
            _currentFileSize = fi.Length;

            // Size rollover?
            if (_currentFileSize >= _maxFileSize)
                RolloverSize(_maxFileSize);
        }

        public virtual List<TraceMessageAdapter> Read(out int pNumberOfMessages, string pFullFilePath)
        {
            pNumberOfMessages = 0;
            FileInfo fi = new FileInfo(pFullFilePath);
            _maxFileSize = fi.Length;
            _traceModified = fi.LastWriteTime;
            using (Stream stream = File.Open(pFullFilePath, FileMode.Open, FileAccess.Read))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                List<TraceMessageAdapter> messages = new List<TraceMessageAdapter>();
                while (stream.Position != stream.Length)
                {
                    messages.Add(new TraceMessageAdapter((ITraceObject)binFmt.Deserialize(stream), "   "));
                    pNumberOfMessages++;
                }
                return messages;
            }
        }

        public virtual List<ITraceObject> ReadLogFileRaw(out int pNumberOfMessages, string pFullFilePath)
        {
            pNumberOfMessages = 0;
            FileInfo fi = new FileInfo(pFullFilePath);
            _maxFileSize = fi.Length;
            _traceModified = fi.LastWriteTime;
            using (Stream stream = File.Open(pFullFilePath, FileMode.Open, FileAccess.Read))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                List<ITraceObject> messages = new List<ITraceObject>();
                while (stream.Position != stream.Length)
                {
                    messages.Add((ITraceObject)binFmt.Deserialize(stream));
                    pNumberOfMessages++;
                }
                return messages;
            }
        }

        public void RolloverDay(DateTime pDate, DateTime pOldDate)
        {
            // rollover to a new day log file
            Initialize(LogName, LogPath, MaxFileSize, pDate);
            if (_messageCache != null && _messageCache.Count > 0)
                Write(_messageCache);
            _messageCache = null;
            OnRolledOverDay(new EventArgs());
        }

        public void RolloverSize(long pSize)
        {
            // Rename the existing file to <fileName>_<index>.<extension>
            string fullFilePath = LogPath + "\\" + TraceDate.Date.ToString(_dateFormat) + "\\" + LogName;
            string destFullFilePath = destFullFilePath = Path.GetDirectoryName(fullFilePath) + "\\" +
                Path.GetFileNameWithoutExtension(fullFilePath) + "_" + _fileIndex.ToString() +
                Path.GetExtension(fullFilePath); ;
            while (File.Exists(destFullFilePath))
            {
                _fileIndex++;
                destFullFilePath = Path.GetDirectoryName(fullFilePath) + "\\" +
                Path.GetFileNameWithoutExtension(fullFilePath) + "_" + _fileIndex.ToString() +
                Path.GetExtension(fullFilePath);
            }
            File.Move(fullFilePath, destFullFilePath);
            RolloverDay(TraceDate, TraceDate);
            OnRolledOverSize(new EventArgs());
        }

        public virtual void OnRolledOverDay(EventArgs e)
        {
            DayRolledOver?.Invoke(this, e);
        }

        public virtual void OnRolledOverSize(EventArgs e)
        {
            SizeRolledOver?.Invoke(this, e);
        }

        private void Initialize(string pFileName, string pFilePath, long pMaxSize,
            DateTime pTraceDate = default(DateTime))
        {
            _name = pFileName;
            _path = pFilePath;
            _maxFileSize = (pMaxSize == -1) ? 763363328 : pMaxSize;
            _traceDate = (pTraceDate == default(DateTime)) ? DateTime.Now : pTraceDate;

            // Checking file / path access...
            string fileFullPath = _path + "\\" + _traceDate.Date.ToString(_dateFormat) + "\\" + _name;
            if (File.Exists(fileFullPath))
            {
                FileInfo fi = new FileInfo(fileFullPath);
                _traceModified = fi.LastWriteTime;
                _traceCreated = fi.CreationTime;
                _currentFileSize = fi.Length;
                fi = null;
            }
            else
            {
                _traceCreated = _traceModified = DateTime.Now;
                _currentFileSize = 0;
                // Try creating the path if it does not exist yet
                if (!Directory.Exists(Path.GetDirectoryName(fileFullPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(fileFullPath));
                var list = new List<ITraceObject>();
                string message = String.Format(@"Trace file initializing, inventory as follows 
                    [FileName={0}] [FilePath={1}] [LogFileType={8}] [DateTime={2}] [Caller={3}] [Library={4}] 
                    [OSVersion={5}] [MachineName={6}] [x64={7}]",
                    pFileName,
                    pFilePath,
                    pTraceDate.ToString(_displayDateFormat + " " + _displayTimeFormat),
                    new StackFrame(2).GetMethod().DeclaringType.Name,
                    Assembly.GetCallingAssembly().GetName().Name,
                    Environment.OSVersion,
                    Environment.MachineName,
                    Environment.Is64BitOperatingSystem.ToString(), "BinaryLogFile");
                message = Regex.Replace(message, @"\s+", " ");
                ITraceObject tmp = new TraceMessage(message, TraceObjectType.SysInfo, 0);
                list.Add(tmp);
                Write(list);
            }
            _fileIndex++;
        }
    }
}