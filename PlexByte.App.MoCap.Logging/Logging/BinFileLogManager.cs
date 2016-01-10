//////////////////////////////////////////////////////////////////////////////
//      <ClassTemplate>
//      Author:     <AuthorName>
//      Project:    <ProjectName>
//      Component:  <ComponentName>
#region usings
#region Includes (Microsoft based)
//////////////////////////////////////////////
//      using includes here (Microsoft)     //
//////////////////////////////////////////////
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

using System;

namespace MoCap.Logging
{
    #region Delegates are declared here

    #endregion

    #region Global variables are declared here

    #endregion

    #region Enum(-s) or type(-s) declaration here

    #endregion

    /// <summary>
    /// This implementation uses a biary file to write the log messages to
    /// </summary>
    public class BinFileLogManager : LogManager
    {
        #region Class members

        #region Events

        #endregion

        #region Properties

        #endregion

        #region Private variables

        #endregion

        #endregion

        #region Methods

        #region Constructor(-s) & Destructor

        public BinFileLogManager(string pLogName, string pLogPath, int pQueueSize, string pComponent, bool pUseFolderPrefix)
            : base(pLogName, pLogPath, false, pQueueSize, pComponent, pUseFolderPrefix, false)
        {
        }

        #endregion

        #region Private Methods

        #endregion

        #region Event handlers (methods)

        #endregion

        #region Public Methods

        public override void MessageAdded(LogManagerMessageAddedEventArgs e)
        {
            // No need to react on message added event
        }

        public override void ReadStream()
        {
            using (Stream stream = File.Open(LogFileFullPath, FileMode.Open))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                Queue logMesg = (Queue)binFmt.Deserialize(stream);
            }
        }

        public override void WriteStream(LogManagerDumpQueueEventArgs e)
        {
            // Check if the directory exists and create it if requires
            if (!Directory.Exists(LogTargetPath))
                Directory.CreateDirectory(LogTargetPath);
            using (Stream stream = File.Open(LogFileFullPath, FileMode.Create))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binFmt.Serialize(stream, e.LogQueue);
                /*foreach (LogMessage message in e.LogQueue)
                {
                    binFmt.Serialize(stream, message);
                }
                */
                stream.Flush();
            }
        }

        #endregion

        #endregion

        #region Nested classes here (indentical structure here)

        #endregion
    }
}