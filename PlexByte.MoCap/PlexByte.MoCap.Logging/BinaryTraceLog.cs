using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlexByte.MoCap.Logging
{
    public sealed class BinaryTraceLog : ITraceLog, IDisposable
    {
        #region Implementation of ITraceLog

        public event RolloverDay RolledoverDay;
        public event RolloverSize RolledoverSize;

        public string FileName => _fileName;

        public string FilePath => _filePath;

        public DateTime TraceDate => _traceDate;

        public long MaxFileSize => _maxFileSize;

        public DateTime TraceModified => _traceDateModified;

        public DateTime TraceCreated => _traceDateCreated;

        public void WriteLog(List<TraceMessage> pMessages)
        {
            string fileFullPath = _filePath + "\\" + _traceDate.Date.ToString(_formatInternalDate) + "\\" + _fileName;
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
                        if(_messageCache == null) { _messageCache=new List<TraceMessage>(); }
                        _messageCache.AddRange(pMessages.Where(x=>x.MessageDateTime.Date==tmp.MessageDateTime.Date));
                        return;
                    }
                }
                stream.Flush();
            }
            FileInfo fi = new FileInfo(fileFullPath);
            _currentFileSize = fi.Length;

            // Size rollover?
            if(_currentFileSize>=_maxFileSize)
                RolloverSize(_maxFileSize);
        }

        public List<TraceMessage> ReadLog(out long pNumberOfMessages)
        {
            string fileFullPath = _filePath + "\\" + _fileName;
            pNumberOfMessages = 0;
            FileInfo fi = new FileInfo(fileFullPath);
            _maxFileSize = fi.Length;
            _traceDateModified = fi.LastWriteTime;
            using (Stream stream = File.Open(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                List<TraceMessage> messages = new List<TraceMessage>();
                while (stream.Position != stream.Length)
                {
                    messages.Add((TraceMessage)binFmt.Deserialize(stream));
                    pNumberOfMessages++;
                }
                return messages;
            }
        }

        public void RolloverDay(DateTime pDate, DateTime pOldDate)
        {
            if (!_isShutdown)
            {
                // rollover to a new day log file
                Initialize(FileName, FilePath, MaxFileSize, pDate);
                if (_messageCache != null && _messageCache.Count > 0)
                    WriteLog(_messageCache);
                _messageCache = null;
                OnRolledoverDay(new EventArgs());
            }
        }

        public void RolloverSize(long pSize)
        {
            // Rollover to a new log file, due to size
            if (!_isShutdown)
            {
                // Rename the existing file to <fileName>_<index>.<extension>
                string fullFilePath = FilePath + "\\" + TraceDate.Date.ToString(_formatInternalDate) + "\\" + FileName;
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
                OnRolledoverSize(new EventArgs());
            }
        }

        public void OnRolledoverDay(EventArgs e)
        {
            if (!_isShutdown)
                RolledoverDay?.Invoke(this, e);
        }

        public void OnRolledoverSize(EventArgs e)
        {
            if (!_isShutdown)
                RolledoverSize?.Invoke(this, e);
        }

        #endregion

        private string _fileName;
        private string _filePath;
        private long _maxFileSize;
        private long _currentFileSize;
        private DateTime _traceDate;
        private DateTime _traceDateModified;
        private DateTime _traceDateCreated;
        private string _formatInternalDate = "yyyyMMdd";
        private string _formatInternalTime = "HHmmssfff";
        private string _formatPresentationDate = "yyyy/MM/dd";
        private string _formatPresentationTime = "HH:mm:ss.fff";
        private List<TraceMessage> _messageCache = null;
        private bool _isShutdown = false;
        private int _fileIndex = 0;

        public BinaryTraceLog(string pFileName, string pFilePath) :
            this(pFileName, pFilePath, -1) { }

        public BinaryTraceLog(string pFileName, string pFilePath, long pMaxSize, DateTime pTraceDate = default(DateTime))
        {
            Initialize(pFileName, pFilePath, pMaxSize, pTraceDate);
        }

        private void Initialize(string pFileName, string pFilePath, long pMaxSize,
            DateTime pTraceDate = default(DateTime))
        {
            _fileName = pFileName;
            _filePath = pFilePath;
            _maxFileSize = (pMaxSize == -1) ? 763363328 : pMaxSize;
            _traceDate = (pTraceDate == default(DateTime)) ? DateTime.Now : pTraceDate;

            // Checking file / path access...
            string fileFullPath = _filePath + "\\" + _traceDate.Date.ToString(_formatInternalDate) + "\\" + _fileName;
            if (File.Exists(fileFullPath))
            {
                FileInfo fi = new FileInfo(fileFullPath);
                _traceDateModified = fi.LastWriteTime;
                _traceDateCreated = fi.CreationTime;
                _currentFileSize = fi.Length;
                fi = null;
            }
            else
            {
                _traceDateCreated = _traceDateModified = DateTime.Now;
                _currentFileSize = 0;
                // Try creating the path if it does not exist yet
                if (!Directory.Exists(Path.GetDirectoryName(fileFullPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(fileFullPath));
                var list=new List<TraceMessage>();
                string message = String.Format(@"Trace file initializing, inventory as follows 
                    [FileName={0}] [FilePath={1}] [DateTime={2}] [Caller={3}] [Library={4}] [OSVersion={5}] 
                    [MachineName={6}] [x64={7}]",
                    pFileName,
                    pFilePath,
                    pTraceDate.ToString(_formatPresentationDate + " " + _formatPresentationTime),
                    new StackFrame(2).GetMethod().DeclaringType.Name,
                    Assembly.GetCallingAssembly().GetName().Name,
                    Environment.OSVersion,
                    Environment.MachineName,
                    Environment.Is64BitOperatingSystem.ToString());
                message= Regex.Replace(message, @"\s+", " ");
                TraceMessage tmp =new TraceMessage(message, TraceType.Info, (int) TraceLevel.All);
                list.Add(tmp);
                WriteLog(list);
            }
            _fileIndex++;
        }

        public void Dispose()
        {
            _isShutdown = true;
        }
    }
}
