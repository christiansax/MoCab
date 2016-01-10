//////////////////////////////////////////////////////////////////////////////
//      AbstrLogManager
//      Author:     Christian B. Sax
//      Project:    MoCap
//      Component:  Logging
#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
#endregion

#region Includes (3rd parties)
//////////////////////////////////////////////
//      using includes here (3rd parties)   //
//////////////////////////////////////////////
#endregion

#region Includes (MoCap based)
//////////////////////////////////////////////
//      using includes here (MoCap)         //
//////////////////////////////////////////////
#endregion
#endregion

namespace MoCap.Logging
{
    #region Delegates are declared here

    public delegate void DumpQueueEventHandler(object sender, LogManagerDumpQueueEventArgs e);
    public delegate void AddedMessageEventHandler(object sender, LogManagerMessageAddedEventArgs e);

    #endregion

    #region Enum(-s) or type(-s) declaration here

    #endregion

    /// <summary>
    /// This abstract class provides a partial implementation of the LogManager. It is used to store or forward
    /// log messages to a stream. It chaches the messages up to a certain value. Once exceeded the queue is being emptied.
    /// Further the log manager reads messaged from a stream, adding them to it's queue. When reading the queue grows continously 
    /// with every message and is never emptied until the object disposes
    /// </summary>
    public abstract class LogManager :IDisposable
    {
        // Log folder suffix is path is amended
        static string LOG_PRODUCT_DIR = @"\PexByte\MoCap";

        #region Class members

        #region Events

        public event DumpQueueEventHandler DumpQueue;
        public event AddedMessageEventHandler AddedMessage;

        #endregion

        #region Properties

        /// <summary>
        /// ReadOnly: The name of the logfile (path is not included) e.g. Log.mcl
        /// </summary>
        public string LogFileName { get; }

        /// <summary>
        /// ReadOnly: The path to the logfile e.g. C:\\Logs
        /// </summary>
        public string LogTargetPath { get; }

        /// <summary>
        /// ReadOnly: The extension of the logfile. Derived from the logfileName
        /// </summary>
        public string LogFileExtension { get; }

        /// <summary>
        /// ReadOnly: Holds the log file full path
        /// </summary>
        public string LogFileFullPath { get; }

        /// <summary>
        /// ReadOnly: The log level specified in the trace config file for the component
        /// </summary>
        public int LogLevel { get; }

        /// <summary>
        /// ReadOnly: The number of log messages to accumulate before the queue is dumped
        /// </summary>
        public int QueueSize { get; }

        /// <summary>
        /// ReadOnly: Returns the number of log messages in the queue currently
        /// </summary>
        public int QueueCount { get; }

        /// <summary>
        /// ReadOnly: Indicates whether the manager is in read or write mode
        /// </summary>
        public bool ReadMode { get; }

        /// <summary>
        /// ReadOnly: Indicates whether the manager will create a date prefix folder, in which the logs are placed (e.g C:\Path\20160104)
        /// </summary>
        public bool UseDatePrefix { get; }

        /// <summary>
        /// ReadOnly: Indicates whether the manager will compress the logs after finished writing
        /// </summary>
        public bool CompressLogFiles { get; }

        /// <summary>
        /// ReadOnly: The default component to log as, if the log message does not speify it
        /// </summary>
        public string ComponentName { get; }

        #endregion

        #region Variables

        private List<Queue> logQueues = null;
        private Stream stream = null;
        private int activeLogQueueIndex = 0;
        private object lockObject = new object();

        #endregion

        #endregion

        #region Methods

        #region Constructor(-s) & Destructor

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        public LogManager(string pLogFileName, bool pReadMode):
            this(pLogFileName, "", pReadMode, 500, "", true, false)
        {

        }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        /// <param name="pComponent">The default component to log as if component was undefined in the log message</param>
        public LogManager(string pLogFileName, bool pReadMode, string pComponent):
            this(pLogFileName, "", pReadMode, 500, pComponent, true, false)
        {

        }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        /// <param name="pQueueSize">The size of the queue, after which it is dumped to a stream</param>
        public LogManager(string pLogFileName, bool pReadMode, int pQueueSize):
            this(pLogFileName, "", pReadMode, pQueueSize, "", true, false)
        {

        }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        /// <param name="pQueueSize">The size of the queue, after which it is dumped to a stream</param>
        /// <param name="pComponent">The default component to log as if component was undefined in the log message</param>
        public LogManager(string pLogFileName, bool pReadMode, int pQueueSize, string pComponent):
            this(pLogFileName, "", pReadMode, pQueueSize, pComponent, true, false)
        {

        }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        /// <param name="pQueueSize">The size of the queue, after which it is dumped to a stream</param>
        /// <param name="pComponent">The default component to log as if component was undefined in the log message</param>
        /// <param name="pUseDatePrefixFolder">When set to true, the manager will create a dateTime value folder, in which the log files will be placed</param>
        public LogManager(string pLogFileName, bool pReadMode, int pQueueSize, string pComponent, bool pUseDatePrefixFolder) : 
            this(pLogFileName, "", pReadMode, pQueueSize, pComponent, pUseDatePrefixFolder, false)
        {

        }

        /// <summary>
        /// The default constructor of the class, as all others call this constructor
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        /// <param name="pLogTargetPath">If physical file on disk full path, network address id a network stream is used or DB name is a database is used</param>
        /// <param name="pQueueSize">The size of the queue, after which it is dumped to a stream</param>
        /// <param name="pComponent">The default component to log as if component was undefined in the log message</param>
        /// <param name="pUseDatePrefixFolder">When set to true, the manager will create a dateTime value folder, in which the log files will be placed</param>
        /// <param name="pCompress">When set to true, the manager will compress the log once closed</param>
        public LogManager(string pLogFileName, string pLogTargetPath, bool pReadMode = false, int pQueueSize = 500, string pComponent = "", 
            bool pUseDatePrefixFolder = true, bool pCompress = false)
        {
            LogFileName = pLogFileName;
            QueueSize = pQueueSize;

            if (pLogTargetPath == string.Empty)
            {
                LogTargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                LogTargetPath += LOG_PRODUCT_DIR;
            }
            else
                LogTargetPath = pLogTargetPath;
            if (pUseDatePrefixFolder)
            {
                LogTargetPath += "\\" + DateTime.Now.ToString("yyyyMMdd");
            }
            LogFileFullPath = LogTargetPath + "\\" + LogFileName;
            ReadMode = pReadMode;

            // Initialized the component name
            if(pComponent==string.Empty)
                ComponentName = Assembly.GetCallingAssembly().GetName().ToString();
            else
                ComponentName = pComponent;

            UseDatePrefix = pUseDatePrefixFolder;
            CompressLogFiles = pCompress;

            // Create three queues and initialize them
            logQueues = new List<Queue>();
            for (int i = 0; i < 3; i++)
                logQueues.Add(new Queue(QueueSize));
            activeLogQueueIndex = 0;

            // Register callback Methods for the events
            this.DumpQueue += LogManager_DumpQueue;
            this.AddedMessage += LogManager_AddedMessage;

            LogLevel = GetTraceLevel();
        }

        /// <summary>
        /// Disposes the AbstrLogManager and makes sure all resources are being released
        /// </summary>
        public void Dispose()
        {
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }

            for (int i = 0; i < logQueues.Count; i++)
            {
                logQueues[i].Clear();
                logQueues[i] = null;
            }
            logQueues.Clear();
            logQueues = null;
            activeLogQueueIndex = -1;
        }

        #endregion

        #region Event handlers (methods)

        protected virtual void OnDumpQueue(LogManagerDumpQueueEventArgs e)
        {
            // Check for subscriber and if raise event
            if (DumpQueue != null)
                DumpQueue(this, e);
        }

        protected virtual void OnAddedMessage(LogManagerMessageAddedEventArgs e)
        {
            if (AddedMessage != null)
                AddedMessage(this, e);
        }

        /// <summary>
        /// The registered callback for event DumpQueue assigned in constructor of the class
        /// </summary>
        /// <param name="sender">The object calling the event</param>
        /// <param name="e">The event arguments provided (LogQueue)</param>
        private void LogManager_DumpQueue(object sender, LogManagerDumpQueueEventArgs e)
        {
            WriteStream(e);
        }

        /// <summary>
        /// The registered callback for the event MessageAdded assigned in constuctr of the class
        /// </summary>
        /// <param name="sender">The object calling the event</param>
        /// <param name="e">The event arguments provided (Message)</param>
        private void LogManager_AddedMessage(object sender, LogManagerMessageAddedEventArgs e)
        {
            MessageAdded(e);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a message to the queue
        /// </summary>
        public void AddMessage(LogMessage pMessage)
        {
            // Try to accuire the lock.
            bool isLocked = false;
            int position = 0;
            // Check if we need to trace this message at all...
            if (LogLevel >= pMessage.Level)
            {
                try
                {
                    Monitor.TryEnter(lockObject, 500, ref isLocked);
                    if (!isLocked)
                        throw new LogManagerAddMessageException("Failed to accuire lock to insert message...");

                    // Check if we need to set the default component
                    if (pMessage.Component == string.Empty && ComponentName != string.Empty)
                        pMessage.Component = ComponentName;

                    // Capacity in current queue?
                    if (logQueues[activeLogQueueIndex].Count < QueueSize)
                    {
                        // We do have capacity and insert the message...
                        logQueues[activeLogQueueIndex].Enqueue(pMessage);
                        position = logQueues[activeLogQueueIndex].Count - 1;
                    }
                    else
                    {
                        // There's no capacity anymore, shifting to new queue and raise dump event for active queue...
                        OnDumpQueue(new LogManagerDumpQueueEventArgs(logQueues[activeLogQueueIndex]));
                        activeLogQueueIndex = (activeLogQueueIndex == 2) ? 0 : ++activeLogQueueIndex;
                        if (logQueues[activeLogQueueIndex] == null)
                            logQueues[activeLogQueueIndex] = new Queue(QueueSize);
                        else
                            logQueues[activeLogQueueIndex].Clear();
                        logQueues[activeLogQueueIndex].Enqueue(pMessage);
                        position = 0;
                    }
                    // Raise on message added event
                    OnAddedMessage(new LogManagerMessageAddedEventArgs(pMessage, position, activeLogQueueIndex));
                }
                finally
                {
                    if (isLocked) Monitor.Exit(lockObject);
                }
            }
        }

        /// <summary>
        /// Overwrite: Abstract method to handle stream writing, regarless of stream type. Called once DumpQueue occured
        /// </summary>
        /// <param name="e">The event arguments provided (LogQueue)</param>
        public abstract void WriteStream(LogManagerDumpQueueEventArgs e);

        /// <summary>
        /// Overwrite: Abstract method to deal with message added event whic is wired internally in the constructor
        /// </summary>
        /// <param name="e">The event arguments provided (Message)</param>
        public abstract void MessageAdded(LogManagerMessageAddedEventArgs e);

        /// <summary>
        /// Overwrite: Abstract method to deal with reading, regardless of stream type (typically a file)
        /// </summary>
        public abstract void ReadStream();

        /// <summary>
        /// Returns the path to the directory the given assembly is running
        /// </summary>
        /// <param name="ExecutingAssembly">The assembly to use as reference</param>
        /// <returns>Full path to assembly's directory</returns>
        public string GetExecAssemblyPath(Assembly ExecutingAssembly)
        {
            string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This method looks for a Trace.cfg file in the current executing directory or the target file path. If found the level 
        /// specified for the component will be set as trace level. If no file was found, the default level of 41 will be set
        /// </summary>
        private int GetTraceLevel()
        {
            int level = 0;
            string[] configContent = null;
            string configFileName = "Trace.cfg";
            string configFileFullPath = LogTargetPath + "\\" + configFileName;

            if (File.Exists(configFileFullPath))
            {
                configContent = new string[File.ReadAllLines(configFileFullPath).Length];
                configContent = File.ReadAllLines(configFileFullPath);
            }
            else
            {
                configFileFullPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\" + configFileName;
                if (File.Exists(configFileFullPath))
                {
                    configContent = new string[File.ReadAllLines(configFileFullPath).Length];
                    configContent = File.ReadAllLines(configFileFullPath);
                }
            }

            if (configContent != null)
            {
                foreach (string s in configContent)
                {
                    // If we find the components name in the config file, we try to parse the value e.g. Logging=42
                    if (s.ToLower().Contains(ComponentName.ToLower()))
                        if (Int32.TryParse(s.Substring(s.IndexOf('=')), out level))
                            return (level);
                }
            }
            return 41;
        }

        #endregion

        #endregion
    }

    #region Nested classes here

    /// <summary>
    /// This class contains events args provided when the dumpQueue event occurs
    /// </summary>
    public class LogManagerDumpQueueEventArgs : EventArgs
    {
        /// <summary>
        /// The log queue to dump
        /// </summary>
        public Queue LogQueue { get; }

        /// <summary>
        /// The size of the queue
        /// </summary>
        public int QueueSize { get { return LogQueue.Count; } }

        /// <summary>
        /// The default constructor for the class
        /// </summary>
        /// <param name="pQueue">The queue to be dumped</param>
        public LogManagerDumpQueueEventArgs(Queue pQueue)
        {
            LogQueue = pQueue;
        }

    }

    /// <summary>
    /// This class contains events args provided when the MessageAdded event occurs
    /// </summary>
    public class LogManagerMessageAddedEventArgs : EventArgs
    {
        /// <summary>
        /// ReadOnly: The log message that was added
        /// </summary>
        public LogMessage Message { get; }

        /// <summary>
        /// ReadOnly: The position of the message in the log queue
        /// </summary>
        public int PositionInQueue { get; }

        /// <summary>
        /// ReadOnly: The index of the queue in the list
        /// </summary>
        public int QueueNumber { get; }

        /// <summary>
        /// The default constructor for the class
        /// </summary>
        /// <param name="pQueue">The queue to be dumped</param>
        public LogManagerMessageAddedEventArgs(LogMessage pMessage, int pPosition, int pQueueNumber)
        {
            Message = pMessage;
            PositionInQueue = pPosition;
            QueueNumber = pQueueNumber;
        }

    }

    /// <summary>
    /// This exception is thrown when adding a message to the queue failed for any reason
    /// </summary>
    public class LogManagerAddMessageException : Exception
    {
        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pMessage">The exception message</param>
        public LogManagerAddMessageException(string pMessage) : base(pMessage) { }
    }

    #endregion
}