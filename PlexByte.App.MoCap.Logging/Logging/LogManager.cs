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
using System.IO;
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

    public delegate void DumpQueueEventHandler(object sender, EventArgs e);
    public delegate void AddedMessageEventHandler(object sender, EventArgs e);

    #endregion

    #region Global variables are declared here

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
        #region Class members

        #region Events

        public event DumpQueueEventHandler DumpQueue;
        public event AddedMessageEventHandler AddedMessage;

        #endregion

        #region Properties

        /// <summary>
        /// ReadOnly: The name of the logfile (path is not included) e.g. Log.mcl
        /// </summary>
        string LogFileName { get; }

        /// <summary>
        /// ReadOnly: The path to the logfile e.g. C:\\Logs
        /// </summary>
        string LogFilePath { get; }

        /// <summary>
        /// ReadOnly: The extension of the logfile. Derived from the logfileName
        /// </summary>
        string LogFileExtension { get; }

        /// <summary>
        /// ReadOnly: Holds the log file full path
        /// </summary>
        string LogFileFullPath { get; }

        /// <summary>
        /// ReadOnly: The number of log messages to accumulate before the queue is dumped
        /// </summary>
        int SinkCache { get; }

        /// <summary>
        /// ReadOnly: Indicates whether the manager is in read or write mode
        /// </summary>
        bool ReadMode { get; }

        #endregion

        #region Variables

        private Queue LogQueueA = null;
        private Queue LogQueueB = null;
        private Stream Stream = null;

        #endregion

        #endregion

        #region Methods

        #region Constructor(-s) & Destructor

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="pLogFileName">The name of the log file to create (including extension)</param>
        public LogManager(string pLogFileName, bool pReadMode)
        {

        }

        #endregion

        #region Event handlers (methods)

        protected virtual void OnDumpQueue(EventArgs e)
        {
            //Write the queue to file
        }

        protected virtual void OnAddedMessage(EventArgs e)
        {
            // Check if the queue needs to be dumped
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a message to the queue
        /// </summary>
        public void AddMessage(LogMessage pMessage)
        {
        }

        /// <summary>
        /// Abstract method to write the contents of the queue to a stream
        /// </summary>
        public abstract void WriteStream();

        /// <summary>
        /// Abstract method to read the contents of a stream
        /// </summary>
        public abstract void ReadStream();

        /// <summary>
        /// Disposes the AbstrLogManager and makes sure all resources are being released
        /// </summary>
        public void Dispose()
        {
            if (Stream!=null)
            {
                Stream.Dispose();
                Stream = null;
            }
            if (LogQueueA != null)
            {
                LogQueueA.Clear();
                LogQueueA = null;
            }
            if (LogQueueB != null)
            {
                LogQueueB.Clear();
                LogQueueB = null;
            }
        }

        #endregion

        #endregion
    }
}