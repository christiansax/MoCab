using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace MoCap.Logging
{
    public class TraceManager : IDisposable, ITraceManager
    {
        public bool AutoRefreshLog { get { return autoRefreshLog; } set { RefreshLogFile(value); } }
        public string Component { get; set; }
        public string Context { get; }
        public int CurrentIndent { get { return currentIndent; } }
        public string DateFolderName { get { return dateFolderName; } }
        public string IndentPrefix { get { return indentPrefix; } }
        public bool IsReadMode { get { return isReadMode; } }
        public int LogCache { get { return logCache; } }
        public int LogFileIndex { get { return logFileIndex; } }
        public long MaxFileSize { get { return maxFileSize; } }
        public string LogPath { get { return logPath; } }
        public string RecentLogFileName { get { return recentLogFileName; } }
        public int TraceLevel { get { return traceLevel; } set { SetTraceLevel(value); } }
        public List<MessageFilter> TraceFilter { get { return traceFilters; } set { traceFilters = value; } }
        public bool ZipLogFiles { get { return zipLogFiles; } }

        public event LogFileRollOverEventHanler LogFileRolledOver;
        public event NewMessagesRetrievedEventHanler NewMessagesRetrieved;
        public event TraceLevelChangedEventHanler TraceLevelChanged;

        private string dateFolderName = string.Empty;
        private string recentLogFileName = string.Empty;
        private string logPath = string.Empty;
        private string context = string.Empty;
        private int traceLevel = 41;
        private int logCache = 2000;
        private int logFileIndex = 0;
        private long maxFileSize = 763363328;
        private long currentFileSize = 0;
        private bool zipLogFiles = false;
        private string indentPrefix = "    ";
        private int currentIndent = 0;
        private bool isReadMode = false;
        private bool autoRefreshLog = false;
        private List<LogMessage> logMessages = null;
        private LogFile activeLog = null;
        private static object _LockObject = new object();
        private bool isLocked = false;
        private List<MessageFilter> traceFilters = null;

        #region Ctor and Dtor

        /// <summary>
        /// This is the one for all Ctor, being called from any other Ctor
        /// </summary>
        /// <param name="pFileName">The file name fo the log file</param>
        /// <param name="pFilePath">The path to the log file</param>
        /// <param name="pComponent">The component to log this under</param>
        /// <param name="pLevel">The level the tracemanager is on</param>
        /// <param name="pLogCache">The number of log entries to cache before writing to disk</param>
        /// <param name="pReadMode">Indicates if the traceManager is instanciated to read a log file</param>
        /// <param name="pMaxFileSize">The maximum size of a log file before rolling over to a new one</param>
        /// <param name="pIndent">The indent string to apply</param>
        public TraceManager(string pFileName, string pFilePath, string pComponent, int pLevel, int pLogCache = 2000, bool pReadMode = false,
            long pMaxFileSize = 763363328, string pIndent = "  ")
        {
            isReadMode = pReadMode;
            recentLogFileName = pFileName;
            logPath = pFilePath;
            logMessages = new List<LogMessage>();
            if (!isReadMode)
            {
                dateFolderName = DateTime.Now.ToString("yyyyMMdd");
                if (pFilePath.Length < 2)
                    logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PlexByte\\" + dateFolderName;
                else
                    logPath = pFilePath + "\\" + dateFolderName;
                SetTraceLevel(pLevel);
                if (pComponent.Length < 2)
                    Component = Assembly.GetCallingAssembly().GetName().Name;
                else
                    Component = pComponent;
                logCache = pLogCache;
                maxFileSize = pMaxFileSize;
                indentPrefix = pIndent;

                activeLog = InitLogFile(false, logFileIndex);
                logMessages.Add(new LogMessage("Logging started for component " + Component, MessageType.All, 0,
                    Thread.CurrentThread.ManagedThreadId.ToString(), "Initializing"));
            }
            else
            {
                activeLog = InitLogFile(false, 0);
                maxFileSize = activeLog.Size;
            }  
        }

        /// <summary>
        /// Default Ctor of the class, instanciating traceManager in READ mode
        /// </summary>
        public TraceManager() : this("", "", "", 0, 0, true, 0)
        {

        }

        /// <summary>
        /// Ctor of the class, instanciating traceManager in READ mode
        /// </summary>
        /// <param name="pFullFileName">The full path and file name including extension to open</param>
        public TraceManager(string pFullFileName) : 
            this(Path.GetFileName(pFullFileName), Path.GetDirectoryName(pFullFileName), "", 0, 0, true, 0)
        {
        }

        /// <summary>
        /// Ctor of the class, instanciating a writing traceManager
        /// </summary>
        /// <param name="pFileName">The file name including extension</param>
        /// <param name="pLevel">The trace level this manager on</param>
        public TraceManager(string pFileName, int pLevel) : this(pFileName, "", "", pLevel)
        {

        }

        /// <summary>
        /// Ctor of the class, instanciating a writing traceManager
        /// </summary>
        /// <param name="pFileName">The file name including extension</param>
        /// <param name="pFilePath">The path to the file</param>
        /// <param name="pLevel">The trace level this manager on</param>
        public TraceManager(string pFileName, string pFilePath, int pLevel) : this(pFileName, pFilePath, "", pLevel)
        {

        }

        /// <summary>
        /// Ctor of the class, instanciating a writing traceManager
        /// </summary>
        /// <param name="pFileName">The file name including extension</param>
        /// <param name="pFilePath">The path to the file</param>
        /// <param name="pLevel">The trace level this manager on</param>
        /// <param name="pCache">The nunber of log messages to cache before writing to disk</param>
        /// <param name="pMaxFileSize">The maximum size of the logfile before rolling over to a new one</param>
        public TraceManager(string pFileName, string pFilePath, int pLevel, int pCache, long pMaxFileSize) : 
            this(pFileName, pFilePath, "", pLevel, pCache, false, pMaxFileSize)
        {

        }

        /// <summary>
        /// Dtor, cleans up resources
        /// </summary>
        public void Dispose()
        {
            try
            {
                Monitor.TryEnter(_LockObject, 1000, ref isLocked);
                if (!isLocked)
                    throw new Exception("Failed to accuire lock when rolling over to new log file...");

                if (activeLog != null)
                {
                    activeLog.WriteLog(logMessages);
                    activeLog.WriteLog(new LogMessage("Logging stopped for component " + Component, MessageType.All, 0,
                        Thread.CurrentThread.ManagedThreadId.ToString(), "Dispose"));
                    activeLog.MessagesAdded -= ActiveLog_MessagesAdded;
                    activeLog = null;
                }
                if (logMessages != null)
                {
                    logMessages.Clear();
                    logMessages = null;
                }
                    
            }
            finally
            {
                if (isLocked)
                {
                    Monitor.Exit(_LockObject);
                    isLocked = false;
                }
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Clear previously applied filters and returns all messages
        /// </summary>
        /// <returns>The log messages contained in the file</returns>
        public List<LogMessage> ClearFilter()
        {
            TraceFilter.Clear();
            return logMessages;
        }

        /// <summary>
        /// Rolls over to a new log file
        /// </summary>
        public void DailyLogFileRollover()
        {
            InitLogFile(true, logFileIndex);
        }

        public List<LogMessage> FilterLogMessages(List<MessageFilter> pFilter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the first occurance of a string in the log file
        /// NOTE: Currently the message text is searched only
        /// </summary>
        /// <param name="pStringToFine">The string to find</param>
        /// <param name="pColumn">The column to search for</param>
        /// <returns>The position in the list of log messages</returns>
        public int FindLogMessages(string pStringToFine, LogComlumn pColumn)
        {
            switch (pColumn)
            {
                case LogComlumn.Text:
                    return logMessages.IndexOf(logMessages.Where(x => x.Text.Contains(pStringToFine)).First());
                default:
                    return logMessages.IndexOf(logMessages.Where(x => x.Text.Contains(pStringToFine)).First());
            }
        }

        /// <summary>
        /// Adds a log message to the file
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void Log(LogMessage pMessage)
        {
            string lockMessage = string.Empty;
            // Try getting the lock
            try
            {
                if (AcquireLock(500, out lockMessage))
                {
                    pMessage.IndentLevel = currentIndent;
                    pMessage.Context = Context;
                    if (pMessage.Component.Length < 2)
                        pMessage.Component = Component;
                    // Day rollover?
                    if (pMessage.TimeStamp.Date != DateTime.ParseExact(
                        dateFolderName, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Date)
                    {
                        activeLog.WriteLog(logMessages);
                        InitLogFile(true, LogFileIndex);
                    }
                    // File size rollover
                    else if (currentFileSize >= (MaxFileSize * 0.98))
                    {
                        activeLog.WriteLog(logMessages);
                        InitLogFile(true, LogFileIndex);
                    }
                    else
                    {
                        logMessages.Add(pMessage);
                        if (logMessages.Count >= LogCache)
                            currentFileSize = activeLog.WriteLog(logMessages);
                    }

                    // Check the indent level of this message
                    if (pMessage.Type == MessageType.EnterScope)
                        currentIndent++;
                    else if (pMessage.Type == MessageType.ExitScope)
                        currentIndent--;
                }
                else
                    throw new Exception(lockMessage);
            }
            finally
            {
                if (isLocked)
                    if (!ReleaseLock(out lockMessage))
                        throw new Exception(lockMessage);
            }
        }

        /// <summary>
        /// Logs a message of type EnterScope with the message specified (Level 5)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void EnterScope(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.EnterScope, 5, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type EnterScope
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void EnterScope(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.EnterScope)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.EnterScope, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);
            
        }

        /// <summary>
        /// Logs a message of type ExitScope with the message specified (Level 5)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void ExitScope(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.ExitScope, 5, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type ExitScope
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void ExitScope(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.ExitScope)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.ExitScope, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);

        }

        /// <summary>
        /// Logs a message of type Error with the message specified (Level 10)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void Error(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.Error, 10, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type Error
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void Error(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.Error)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.Error, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);
        }

        /// <summary>
        /// Logs a message of type Warning with the message specified (Level 20)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void Warning(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.Warning, 20, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type Warning
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void Warning(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.Warning)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.Warning, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);
        }

        /// <summary>
        /// Logs a message of type Info with the message specified (Level 40)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void Info(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.Info, 40, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type Info
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void Info(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.Info)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.Info, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);

        }

        /// <summary>
        /// Logs a message of type Detail with the message specified (Level 80)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void Detail(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.Detail, 80, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type Detail
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void Detail(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.Detail)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.Detail, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);

        }

        /// <summary>
        /// Logs a message of type All with the message specified (Level 0)
        /// </summary>
        /// <param name="pMessage">The message to log</param>
        public void All(string pMessage)
        {
            LogMessage tmp = new LogMessage(pMessage, MessageType.All, 0, "", "", "");
            Log(tmp);
        }

        /// <summary>
        /// Logs the message object provided as type All
        /// </summary>
        /// <param name="pMessage">The LogMessage object</param>
        public void All(LogMessage pMessage)
        {
            if (pMessage.Type != MessageType.All)
            {
                LogMessage tmp = new LogMessage(pMessage.Text, MessageType.All, pMessage.Level,
                    pMessage.ThreadId, pMessage.Context, pMessage.Attribute1, pMessage.Component);
                Log(tmp);
            }
            else
                Log(pMessage);

        }

        /// <summary>
        /// This method purges log files and corresponding directories on startup (7 days) 
        /// and when called explicitly
        /// </summary>
        /// <param name="pMaxAge">The maximum number of days before deleted</param>
        /// <returns>Returns a small report of the actions</returns>
        public string PurgeLogs(int pMaxAge)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Starting to purge log files older than {0} day(-s)...", pMaxAge);

            string sFullPathNoDate = logPath.Replace("\\" + dateFolderName, "");
            DirectoryInfo dirInfo = new DirectoryInfo(sFullPathNoDate);

            if (Directory.Exists(sFullPathNoDate))
            {
                foreach (FileInfo fileInf in dirInfo.GetFiles())
                {
                    if (DateTime.Compare(fileInf.CreationTime.Date.AddDays(pMaxAge), DateTime.Now.Date) < 0)
                    {
                        fileInf.Delete();
                        sb.AppendFormat("Found file {0} to delete [Created={1}] [Now={2}] [FullPath={3}] {4}",
                            fileInf.Name, fileInf.CreationTime.ToString("yyyy.MM.dd HH:mm:ss.fff"),
                            DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff"),
                            fileInf.FullName, Environment.NewLine);
                    }
                }

                foreach (DirectoryInfo dirInf in dirInfo.GetDirectories())
                {
                    if (DateTime.Compare(dirInf.CreationTime.Date.AddDays(pMaxAge), DateTime.Now.Date) < 0)
                    {
                        sb.AppendFormat("Found directory to delete[Created={1}] [Now={2}] [FullPath={3}] {4}",
                            dirInf.Name, dirInf.CreationTime.ToString("yyyy.MM.dd HH:mm:ss.fff"),
                            DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff"),
                            dirInf.FullName, Environment.NewLine);
                        dirInf.Delete();
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// This method reads the log file specified
        /// </summary>
        /// <param name="pFileFullPath">The full path including file name and extension</param>
        /// <returns>Returns the list of messages from the file</returns>
        public List<LogMessage> ReadLogFile(string pFileFullPath, out long pNumberOfMessages)
        {
            if(activeLog==null)
                activeLog = new LogFile(Path.GetFileName(pFileFullPath), Path.GetDirectoryName(pFileFullPath));
            logMessages.AddRange(activeLog.ReadFile(out pNumberOfMessages));
            return logMessages;
        }

        /// <summary>
        /// Refreshes a log file. If auto refresh is true, the message added event is registered
        /// </summary>
        /// <param name="pAutoRefresh">Indicates whether or not to auto refresh</param>
        public void RefreshLogFile(bool pAutoRefresh)
        {
            autoRefreshLog = pAutoRefresh;
            long numberMessages = 0;
            // Is it in read mode
            if (IsReadMode)
            {
                logMessages = activeLog.ReadFile(out numberMessages);
                if (autoRefreshLog)
                {
                    // Register the messages added event from the log file
                    activeLog.MessagesAdded += ActiveLog_MessagesAdded;
                }
                else
                {
                    // Unregister from messages added event
                    activeLog.MessagesAdded -= ActiveLog_MessagesAdded;
                }
            }
        }

        /// <summary>
        /// Updates the context of this log file
        /// </summary>
        /// <param name="pContext">The context to set</param>
        public void RegisterTopic(string pContext)
        {
            if (pContext.Length > 2)
            {
                context = pContext;
                GetTraceLevel();
            }
        }

        /// <summary>
        /// Temporarily sets the trace level of this manager
        /// </summary>
        /// <param name="pLevel">The level to set</param>
        public void SetTraceLevel(int pLevel)
        {
            traceLevel = pLevel;
            OnTraceLevelChanged();
        }

        /// <summary>
        /// Overrides the to string method
        /// </summary>
        /// <returns>Returns the current log file name</returns>
        public override string ToString()
        {
            return (recentLogFileName);
        }

        /// <summary>
        /// This method compresses a file specified
        /// </summary>
        /// <param name="pFullFilePath">The fully qualified file path including file name and extension</param>
        /// <param name="pLevel">The level of compression</param>
        /// <param name="pThread">The thread performing the compression</param>
        /// <returns></returns>
        public string ZipLogFile(string pFullFilePath, CompressionLevel pLevel, out int pThread)
        {
            string zipFullFilePath = pFullFilePath + "\\" + Component + ".zip";
            using (FileStream fileStream = new FileStream(zipFullFilePath, FileMode.Create))
            {
                using (GZipStream zipStream = new GZipStream(fileStream, pLevel))
                {
                    zipStream.Write(File.ReadAllBytes(logPath + "\\" + recentLogFileName), 0,
                        File.ReadAllBytes(logPath + "\\" + recentLogFileName).Length);
                }
            }
            pThread = Thread.CurrentThread.ManagedThreadId;
            return zipFullFilePath;
        }

        /// <summary>
        /// Raises log file rollover event
        /// </summary>
        /// <param name="pType">The type of rollover that took place</param>
        protected virtual void OnLogFileRolledOver(RolloverType pType)
        {
            if (LogFileRolledOver != null)
            {
                LogFileRolledOver(this, new TraceManagerEventArgs(recentLogFileName,
                    logFileIndex, traceLevel, DateTime.Now, pType));
            }
        }

        /// <summary>
        /// Raises the messages retrieved event, if new messages are written to the log
        /// </summary>
        protected virtual void OnNewMessagesRetrieved()
        {
            if (NewMessagesRetrieved != null)
            {
                NewMessagesRetrieved(this, new TraceManagerEventArgs(recentLogFileName,
                    logFileIndex, traceLevel, DateTime.Now, RolloverType.Unknown));
            }
        }

        /// <summary>
        /// Raises the trace level changed event
        /// </summary>
        protected virtual void OnTraceLevelChanged()
        {
            if (TraceLevelChanged != null)
            {
                TraceLevelChanged(this, new TraceManagerEventArgs(recentLogFileName, 
                    logFileIndex, traceLevel, DateTime.Now, RolloverType.Unknown));
            }
        }

        /// <summary>
        /// Initializes the current log file and rolls over if required
        /// </summary>
        /// <param name="pIsRollover">Indicates whether to rollover or not</param>
        /// <param name="pLogIndex">The index of the current log</param>
        /// <returns>Return the LogFile created</returns>
        private LogFile InitLogFile(bool pIsRollover, int pLogIndex)
        {
            // Purge logs
            PurgeLogs(7);
            string lockMessage = string.Empty;
            LogFile log = null;
            if (pIsRollover)
            {
                try
                {
                    // Try to get a lock
                    if (AcquireLock(1000, out lockMessage))
                    {
                        // Day rollover start reinitializing...
                        logMessages.Add(
                            new LogMessage("Trace day rollover end of day @ " +
                            DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.fff"), MessageType.All, 0, ""));
                        activeLog.WriteLog(logMessages);
                        int dummy = 0;
                        if (ZipLogFiles)
                        {
                            // Call the zip log file method asynchronously
                            AsyncZipLogFile logZipper = new AsyncZipLogFile(this.ZipLogFile);
                            IAsyncResult result = logZipper.BeginInvoke(LogPath + "\\" +
                                Path.GetFileNameWithoutExtension(LogPath + "\\" + RecentLogFileName) + ".zip",
                                CompressionLevel.Optimal,
                                out dummy,
                                new AsyncCallback(AsyncLogZippedCallback), null);
                        }
                        // New day?
                        if (DateFolderName != DateTime.Now.ToString("yyyyMMdd"))
                        {
                            logPath = logPath.Replace(dateFolderName, dateFolderName = DateTime.Now.ToString("yyyyMMdd"));
                            recentLogFileName = recentLogFileName.Replace(pLogIndex.ToString(), (logFileIndex = 0).ToString());
                            OnLogFileRolledOver(RolloverType.DayRollover);
                        }
                        else
                        {
                            recentLogFileName = recentLogFileName.Replace(pLogIndex.ToString(), (++logFileIndex).ToString());
                            OnLogFileRolledOver(RolloverType.SizeRollover);
                        }
                        log = new LogFile(RecentLogFileName, LogPath);
                        Log(new LogMessage("Trace file rolled over to " + RecentLogFileName + " in path " + LogPath +
                            "[TraceLevel=" + TraceLevel.ToString() + "] [Component=" + Component + "] [IsReadMode=" +
                            IsReadMode.ToString() + "] [Cache=" + LogCache.ToString() + "] [MaxSize=" + MaxFileSize.ToString() + "]"));
                    }
                    else
                        throw new Exception("Failed to accuire lock when rolling over to new log file...");
                }
                finally
                {
                    if (isLocked)
                        if (!ReleaseLock(out lockMessage))
                            throw new Exception(lockMessage);
                }
            }
            else
            {
                try
                {
                    // Try to get a lock
                    if (AcquireLock(1000, out lockMessage))
                    {
                        log = new LogFile(RecentLogFileName, LogPath);
                        logFileIndex = 0;
                    }
                    else
                        throw new Exception("Failed to accuire lock when trying to create a new log file...");
                }
                finally
                {
                    if (isLocked)
                        if (!ReleaseLock(out lockMessage))
                            throw new Exception(lockMessage);
                }
            }
            return log;
        }

        /// <summary>
        /// The callback method for the async ziplogfile request
        /// </summary>
        /// <param name="ar">The async Results</param>
        private void AsyncLogZippedCallback(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            AsyncZipLogFile logZipper = (AsyncZipLogFile)result.AsyncDelegate;
            int threadId = 0;
            
            // Call EndInvoke to retrieve the results.
            string returnValue = logZipper.EndInvoke(out threadId, ar);
        }

        /// <summary>
        /// This method looks for a Trace.cfg file in the current executing directory or the target file path. If found the level 
        /// specified for the component will be set as trace level. If no file was found, the default level of 41 will be set
        /// </summary>
        public int GetTraceLevel(string pTraceInfoFileName="Trace.cfg")
        {
            int level = 0;
            string[] configContent = null;
            string configFileFullPath = logPath + "\\" + pTraceInfoFileName;

            if (File.Exists(configFileFullPath))
            {
                configContent = new string[File.ReadAllLines(configFileFullPath).Length];
                configContent = File.ReadAllLines(configFileFullPath);
            }
            else
            {
                configFileFullPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\" + pTraceInfoFileName;
                if (File.Exists(configFileFullPath))
                {
                    configContent = new string[File.ReadAllLines(configFileFullPath).Length];
                    configContent = File.ReadAllLines(configFileFullPath);
                }
                else
                {
                    throw new Exception(String.Format(@"Trace config was not found in either folder [FileName={0}] 
                        [Folder={1}] [TraceLevel={2}]", pTraceInfoFileName, configFileFullPath, TraceLevel));
                }
            }

            if (configContent != null)
            {
                foreach (string s in configContent)
                {
                    // If we find the components name in the config file, we try to parse the value e.g. Logging=42
                    if (s.ToLower().Contains(Component.ToLower()))
                        if (Int32.TryParse(s.Substring(s.IndexOf('=')), out level))
                            return (level);
                }
            }
            return 41;
        }

        /// <summary>
        /// This is the callback method for Log messages added event. It's registered in read mode only
        /// </summary>
        /// <param name="sender">The log file sending the event</param>
        /// <param name="e">The LogFile event args</param>
        private void ActiveLog_MessagesAdded(object sender, LogFileEventArgs e)
        {
            if (e.MessagesAdded.Count > 0)
                logMessages.AddRange(e.MessagesAdded);
            recentLogFileName = e.FileName;
            logPath = e.FilePath;
            OnNewMessagesRetrieved();
        }

        /// <summary>
        /// Acquires the lock within the given timeout
        /// </summary>
        /// <param name="pTimeout">The timeout for the lock to be acquired</param>
        /// <param name="pMessage">The message describing the result</param>
        /// <returns>Boolean returning true if the lock was successfully acquired</returns>
        private bool AcquireLock(int pTimeout, out string pMessage)
        {
            pMessage = string.Empty;
            try
            {
                Monitor.TryEnter(_LockObject, pTimeout, ref isLocked);
                if (isLocked)
                {
                    pMessage = String.Format("Lock successfully acquired. [Timeout={0}]", pTimeout);
                    return true;
                }
                if (!isLocked)
                {
                    pMessage = String.Format("Failed to acquire lock within timeout specified [Timeout={0}]", pTimeout);
                    return false;
                }
            }
            catch { }
            if (!isLocked)
                pMessage = String.Format("Failed to acquire lock within timeout specified [Timeout={0}]", pTimeout);
            return false;
        }

        /// <summary>
        /// Tries to release the lock
        /// </summary>
        /// <param name="pMessage">The message describing the result of this action</param>
        /// <returns>Boolean returning true if the lock was successfully released</returns>
        private bool ReleaseLock(out string pMessage)
        {
            try
            {
                if (isLocked)
                {
                    Monitor.Exit(_LockObject);
                    isLocked = false;
                    pMessage = String.Format("Lock successfully released");
                    return true;
                }
            }
            catch { }
            pMessage = String.Format("Failed to release the lock");
            return false;
        }

        #endregion
    }
}
