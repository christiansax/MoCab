using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace MoCap.Logging
{
    #region Delegates for event handlers

    /// <summary>
    /// Delegate for trace file rollover (day or max size rollover)
    /// </summary>
    /// <param name="sender">This</param>
    /// <param name="e">The event args that come with this event</param>
    public delegate void LogFileRollOverEventHanler(object sender, TraceManagerEventArgs e);
    /// <summary>
    /// Delegate for trace level changed
    /// </summary>
    /// <param name="sender">This</param>
    /// <param name="e">The event args that come with this event</param>
    public delegate void TraceLevelChangedEventHanler(object sender, TraceManagerEventArgs e);
    /// <summary>
    /// Delegate for new messages to be retrieved
    /// </summary>
    /// <param name="sender">This</param>
    /// <param name="e">The event args that come with this event</param>
    public delegate void NewMessagesRetrievedEventHanler(object sender, TraceManagerEventArgs e);

    #endregion

    #region Delegates for Async methods

    /// <summary>
    /// Async method to start zipping a log file
    /// </summary>
    /// <param name="pFullFilePath">The full path including file name and extension to zip</param>
    /// <param name="pLevel">The compression level to use</param>
    /// <returns>Returns the full path including file name and extension to the zip file</returns>
    public delegate string AsyncZipLogFile(string pFullFilePath, CompressionLevel pLevel, out int pThread);
    /// <summary>
    /// Async method to start reading a log file
    /// </summary>
    /// <param name="pFileFullPath">The full file path, including file name and extension to the file to read</param>
    /// <returns>Returns a list of messages read from the file</returns>
    public delegate List<LogMessage> AsyncReadLogFile(string pFullFilePath, out int pThread);
    /// <summary>
    /// Async method to start purging a log file
    /// </summary>
    /// <param name="pMaxAge">The maximum age in days before being purged</param>
    /// <returns>Returning a short operation summary</returns>
    public delegate string AsyncPurgeLogFile(int pMaxAge, out int pThread);

    #endregion

    /// <summary>
    /// Enumeration of the log file columns, used for filtering or searching
    /// </summary>
    public enum LogComlumn
    {
        Text,
        Type,
        Level,
        ThreadId,
        MethodName,
        MethodDefinition,
        Context,
        Component,
        Attribute1
    };

    /// <summary>
    /// Enumeration of the rollover type
    /// </summary>
    public enum RolloverType
    {
        DayRollover,
        SizeRollover,
        Unknown
    };

    public interface ITraceManager
    {
        #region Events

        /// <summary>
        /// This event is raised when the log file rolls over to a new file (day or max size)
        /// </summary>
        event LogFileRollOverEventHanler LogFileRolledOver;
        /// <summary>
        /// This event is raised when the trace level changed
        /// </summary>
        event TraceLevelChangedEventHanler TraceLevelChanged;
        /// <summary>
        /// This event is raised when new messages are being retrieved (either refresh or auto refresh)
        /// </summary>
        event NewMessagesRetrievedEventHanler NewMessagesRetrieved;

        #endregion

        #region Interface properties

        /// <summary>
        /// Date string of the folder currently logging to
        /// </summary>
        string DateFolderName { get; }
        /// <summary>
        /// The log file name currently writing
        /// </summary>
        string RecentLogFileName { get; }
        /// <summary>
        /// The full path to the log file
        /// </summary>
        string LogPath { get; }
        /// <summary>
        /// The component name
        /// </summary>
        string Component { get; }
        /// <summary>
        /// The trace level this is under
        /// </summary>
        int TraceLevel { get; set; }
        /// <summary>
        /// The number of logs to cache before writing
        /// </summary>
        int LogCache { get; }
        /// <summary>
        /// The suffix of the log file index (if multimple)
        /// </summary>
        int LogFileIndex { get; }
        /// <summary>
        /// The maximum size of a log file in bytes
        /// </summary>
        long MaxFileSize { get; }
        /// <summary>
        /// Indicates whether or not the log shall be ziped once completed
        /// </summary>
        bool ZipLogFiles { get; }
        /// <summary>
        /// The indent string to apply
        /// </summary>
        string IndentPrefix { get; }
        /// <summary>
        /// The current indent level
        /// </summary>
        int CurrentIndent { get; }
        /// <summary>
        /// Indicates whether the manager is in read mode or not
        /// </summary>
        bool IsReadMode { get; }
        /// <summary>
        /// Indicated whether the log is automatically refreshed or not
        /// </summary>
        bool AutoRefreshLog { get; set; }
        /// <summary>
        /// The currently applied filters
        /// </summary>
        List<MessageFilter> TraceFilter { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Registers a component name for this instance of trace manager
        /// </summary>
        /// <param name="pComponent">The name of the Component</param>
        void RegisterTopic(string pContext);

        /// <summary>
        /// Sets the log level up to which log messages will be added. Messages having a higher level than 
        /// specified will not make it to the log file
        /// </summary>
        /// <param name="pLevel">The log level to set</param>
        void SetTraceLevel(int pLevel);

        /// <summary>
        /// Adds a log message to the cache
        /// </summary>
        /// <param name="pMessage">The message to be added</param>
        void Log(LogMessage pMessage);

        /// <summary>
        /// Causes the cache to be flushed to file, closes the curent and creates a new file in the updated date folder
        /// </summary>
        void DailyLogFileRollover();

        /// <summary>
        /// Refreshes the messages from the log
        /// </summary>
        /// <param name="pAutoRefresh">True id you want the messages to auto refresh</param>
        void RefreshLogFile(bool pAutoRefresh);

        /// <summary>
        /// Method to purge old logs (async variant available)
        /// </summary>
        /// <param name="pMaxAge">The maximum age in days before being purged</param>
        /// <returns>Returning a short operation summary</returns>
        string PurgeLogs(int pMaxAge);

        /// <summary>
        /// Reads the log file (async variant available)
        /// </summary>
        /// <param name="pFileFullPath">The full file path, including file name and extension to the file to read</param>
        /// <returns>Returns a list of messages read from the file</returns>
        List<LogMessage> ReadLogFile(string pFileFullPath, out long pNumberOfMessages);

        /// <summary>
        /// Filters the list of messages according to the filter specified
        /// </summary>
        /// <param name="pFilter">The filter to apply</param>
        /// <returns>Returns the updated list of messages according to the filter</returns>
        List<LogMessage> FilterLogMessages(List<MessageFilter> pFilter);

        /// <summary>
        /// Removes any filter and reverts the list of messages back all available
        /// </summary>
        List<LogMessage> ClearFilter();

        /// <summary>
        /// Finds the first occurance of the string given in the column specified
        /// </summary>
        /// <param name="pStringToFine">The string value to find</param>
        /// <param name="pColumn">The column to include in the search</param>
        /// <returns>Returns the position in the list</returns>
        int FindLogMessages(string pStringToFine, LogComlumn pColumn);

        /// <summary>
        /// Zips a log file at a level specified (async variant available)
        /// </summary>
        /// <param name="pFullFilePath">The full path including file name and extension to zip</param>
        /// <param name="pLevel">The compression level to use</param>
        /// <returns>Returns the full path including file name and extension to the zip file</returns>
        string ZipLogFile(string pFullFilePath, CompressionLevel pLevel, out int pThread);

        #endregion
    }

    /// <summary>
    /// Trace manager event arguments attached to events raised
    /// </summary>
    public class TraceManagerEventArgs
    {
        #region Class properties

        /// <summary>
        /// The log messages that changed
        /// </summary>
        public List<LogMessage> Messages{ get; set; }
        /// <summary>
        /// The name of the log file
        /// </summary>
        public string LogFileName { get; }
        /// <summary>
        /// The index of the log file
        /// </summary>
        public int LogFileIndex { get; }
        /// <summary>
        /// The level set up to which messages are logged
        /// </summary>
        public int LogLevel { get; }
        /// <summary>
        /// The date and time the event was fired
        /// </summary>
        public DateTime EventDateTime{ get; set; }
        public RolloverType Rollover { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// The event args for traceManager event
        /// </summary>
        /// <param name="pLogFileName">The log file name</param>
        /// <param name="pLogFileIndex">The log file index (if mutliple)</param>
        /// <param name="pLogLevel">The log level the trace manager is on</param>
        /// <param name="pEventDateTime">The event date time</param>
        /// <param name="pRolloverType">The type of rollover that occured</param>
        public TraceManagerEventArgs(string pLogFileName, int pLogFileIndex, int pLogLevel, 
            DateTime pEventDateTime, RolloverType pRolloverType)
        {
            LogFileName = pLogFileName;
            LogFileIndex = pLogFileIndex;
            LogLevel = LogLevel;
            EventDateTime = pEventDateTime;
            Rollover = pRolloverType;
        }

        #endregion
    }
}
