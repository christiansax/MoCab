//////////////////////////////////////////////////////////////////////////////
//                            ILogManager                                   //
//      Author:     Christian B. Sax            Date:       04.01.2016      //
//      Project:    MoCap                       Reviewed:   <Name>          //
//      Component:  Logging                     Owner:      SAXC            //
//      Description: Interface defining required methods to read / write    //
//                   log messages to a destination sink and manage the      //
//                   file.                                                  //
//////////////////////////////////////////////////////////////////////////////

#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
using System;
using System.Collections;
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

namespace MoCap.CodeTemplate
{
    #region Delegates are declared here

    #endregion

    #region Global variables are declared here

    #endregion

    #region Enum(-s) or type(-s) declaration here

    #endregion

    /// <summary>
    /// This is the summary of the interface
    /// </summary>
    public interface ILogManager :IDisposable
    {
        #region Class members

        #region Events

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
        /// ReadOnly: The number of logmessages before writing to destination
        /// </summary>
        int SinkCache { get; }

        #endregion

        #endregion

        #region Methods

        #region Event handlers (methods)

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a message to the queue
        /// </summary>
        void AddMessage();

        /// <summary>
        /// Writes the messages from the queue to the target stream
        /// </summary>
        void WriteStream();

        /// <summary>
        /// Reads messages from a stream and loads it into the queue
        /// </summary>
        void ReadStream();

        #endregion

        #endregion
    }
}