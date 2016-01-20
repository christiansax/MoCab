using System;
using System.Collections.Generic;
using System.IO;

namespace MoCap.Logging
{
    /// <summary>
    /// Delegate for trace file messages added
    /// </summary>
    /// <param name="sender">This</param>
    /// <param name="e">The event args that come with this event</param>
    public delegate void MessagesAddedEventHanler(object sender, LogFileEventArgs e);
    public class LogFile
    {
        /// <summary>
        /// This event is raised when new messages are written to file
        /// </summary>
        public event MessagesAddedEventHanler MessagesAdded;

        /// <summary>
        /// The name of the log file
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The full path to the log file
        /// </summary>
        public string FullPath { get; }
        /// <summary>
        /// The size of the log file (in bytes)
        /// </summary>
        public long Size { get { return fileSize; } }
        /// <summary>
        /// The date time this file was created
        /// </summary>
        public DateTime DateTimeCreated { get; }
        /// <summary>
        /// The date time the file was last written to
        /// </summary>
        public DateTime DateTimeLastWritten { get { return dateTimeModified; } }

        private DateTime dateTimeModified = new DateTime(1970, 1, 30);
        private long fileSize = 0;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="pName">The name of the file to write or read (including extension)</param>
        /// <param name="pFullPath">The full path to the file</param>
        public LogFile(string pName, string pFullPath)
        {
            DateTimeCreated = DateTime.Now;
            if (File.Exists(pFullPath + "\\" + pName))
            {
                FileInfo fi = new FileInfo(pFullPath + "\\" + pName);
                dateTimeModified = fi.LastWriteTime;
                DateTimeCreated = fi.CreationTime;
                fileSize = fi.Length;
                fi = null;
            }
            else
            {
                DateTimeCreated = DateTime.Now;
                dateTimeModified = DateTimeCreated;
                fileSize = 0;
            }
            try
            {
                /// Try creating the path if it does not exist yet
                if (!Directory.Exists(pFullPath))
                    Directory.CreateDirectory(pFullPath);
                FullPath = pFullPath;
                Name = pName;
                /// Test if we can open the file...
                using (Stream stream = File.Open(FullPath + "\\" + Name, File.Exists(FullPath + "\\" + Name) ?
                    FileMode.Append : FileMode.Create))
                {
                }
            }
            catch (Exception exp) { throw exp; }
        }

        /// <summary>
        /// This method writes log messages to file
        /// </summary>
        /// <param name="pMessages">The list of LogMessages to write</param>
        /// <returns>Returns the file size (in bytes)</returns>
        public long WriteLog(List<LogMessage> pMessages)
        {
            dateTimeModified = DateTime.Now;
            fileSize = WriteFile(pMessages);
            OnMessagesAdded(pMessages, fileSize);
            return (fileSize);
        }

        /// <summary>
        /// This method writes log messages to file
        /// </summary>
        /// <param name="pMessage">The logMessage to write => if possible avoid this overload!</param>
        /// <returns>Returns the file size (in bytes)</returns>
        public long WriteLog(LogMessage pMessage)
        {
            List<LogMessage> messages = new List<LogMessage>();
            messages.Add(pMessage);
            return WriteFile(messages);
        }

        /// <summary>
        /// This message raises the message added event
        /// </summary>
        /// <param name="pNewMessages">The new messages that are added</param>
        /// <param name="pFileSize">The current size of the log file</param>
        protected virtual void OnMessagesAdded(List<LogMessage> pNewMessages, long pFileSize)
        {
            if (MessagesAdded != null)
            {
                MessagesAdded(this, new LogFileEventArgs(Name, 
                    FullPath, pFileSize, pNewMessages));
            }
        }

        /// <summary>
        /// The method effectively writes the file
        /// </summary>
        /// <param name="pMessages">The logMessages to write to file</param>
        /// <returns>Returns the size of the stream (in bytes)</returns>
        private long WriteFile(List<LogMessage> pMessages)
        {
            long size = 0;
            using (Stream stream = File.Open(FullPath + "\\" + Name, FileMode.Append, FileAccess.Write))
            {
                if (pMessages != null)
                {
                    var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    foreach (LogMessage tmp in pMessages)
                        binFmt.Serialize(stream, tmp);
                    stream.Flush();
                }
                size = stream.Length;
            }
            return (size);
        }

        /// <summary>
        /// This method reads a log file
        /// </summary>
        /// <returns>Returns the list of logMessages</returns>
        public List<LogMessage> ReadFile(out long pNumberOfMessages)
        {
            FileInfo fi = new FileInfo(FullPath + "\\" + Name);
            fileSize = fi.Length;
            dateTimeModified = fi.LastWriteTime;
            using (Stream stream = File.Open(FullPath + "\\" + Name, FileMode.Open, FileAccess.Read))
            {
                var binFmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                List<LogMessage> messages = new List<LogMessage>();
                while (stream.Position != stream.Length)
                {
                    messages.Add((LogMessage)binFmt.Deserialize(stream));
                }
                pNumberOfMessages = messages.Count;
                return messages;
            }
        }
    }

    public class LogFileEventArgs
    {
        public string FileName { get; }
        public string FilePath { get; }
        public long FileSize { get; }
        public DateTime EventDateTime { get; }
        public List<LogMessage> MessagesAdded { get; }

        public LogFileEventArgs(string pFileName, string pFilePath, long pFileSize, List<LogMessage> pMsgAdded)
        {
            FileName = pFileName;
            FilePath = pFilePath;
            FileSize = pFileSize;
            MessagesAdded = pMsgAdded;
            EventDateTime = DateTime.Now;
        }
    }
}
