using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoCap.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.Logging.Tests
{
    [TestClass()]
    public class BinFileLogManagerTests
    {
        [TestMethod()]
        public void BinFileLogManagerCtorTest()
        {
            // Arange
            BinFileLogManager bl = null;
            string pLogName = "MyLog.nbn";
            string pLogPath = @"C:\Temp";
            int pQueueSize = 2;
            string pComponent = "TachMahal";
            bool pUseprefix = true;
            //bl = new BinFileLogManager(pLogName, pLogPath, pQueueSize, pComponent, pUseprefix);
            string message = "Test message";

            // Act
            LogMessage tmp = new LogMessage(message);
            bl.AddMessage(tmp);

            // Assert
            Assert.IsNotNull(bl, "Failed creating LogManager object");
            Assert.AreEqual(pLogName, bl.LogFileName, "LogName does not match {0} {1} {2} {3}",
                bl.LogFileName, bl.LogFileFullPath, bl.LogFileExtension, bl.LogTargetPath);
        }

        [TestMethod()]
        public void BinFileLogManager_MessageAddedTest()
        {
            // Arange
            BinFileLogManager bl = null;
            string pLogName = "MyLog.nbn";
            string pLogPath = "";
            int pQueueSize = 2;
            string pComponent = "TachMahal";
            bool pUseprefix = true;
            //bl = new BinFileLogManager(pLogName, pLogPath, pQueueSize, pComponent, pUseprefix);
            string message = "Test message";

            // Act
            LogMessage tmp = new LogMessage(message, MessageType.Detail, 40);
            bl.AddMessage(tmp);

            // Assert
            Assert.IsNotNull(bl, "Failed creating LogManager object");
            Assert.AreEqual(pLogName, bl.LogFileName, "LogName does not match {0} {1} {2} {3}",
                bl.LogFileName, bl.LogFileFullPath, bl.LogFileExtension, bl.LogTargetPath);
        }

        [TestMethod()]
        public void BinFileLogManager_WriteStreamTest()
        {
            // Arange
            BinFileLogManager bl = null;
            string pLogName = "MyLog.nbn";
            string pLogPath = @"C:\Temp";
            int pQueueSize = 2;
            string pComponent = "TachMahal";
            bool pUseprefix = true;
            //bl = new BinFileLogManager(pLogName, pLogPath, pQueueSize, pComponent, pUseprefix);

            // Act
            bl.AddMessage(new LogMessage("First message", MessageType.Detail, 40));
            bl.AddMessage(new LogMessage("Second message", MessageType.Detail, 40));
            bl.AddMessage(new LogMessage("Third message", MessageType.Detail, 40));
            System.IO.FileStream fs = System.IO.File.Open(bl.LogFileFullPath, System.IO.FileMode.Open);

            // Assert
            Assert.IsNotNull(fs, "File is empty");
        }

        [TestMethod()]
        public void BinFileLogManager_ReadStreamTest()
        {
            // Arange
            BinFileLogManager bl = null;
            string pLogName = "MyLog.nbn";
            string pLogPath = @"C:\Temp";
            int pQueueSize = 2;
            string pComponent = "TachMahal";
            bool pUseprefix = true;
            //bl = new BinFileLogManager(pLogName, pLogPath, pQueueSize, pComponent, pUseprefix);

            // Act
            try { bl.ReadStream(); }
            catch (Exception exp) { }

            // Assert
            Assert.IsNotNull(bl, "Failed creating LogManager object");
        }
    }
}