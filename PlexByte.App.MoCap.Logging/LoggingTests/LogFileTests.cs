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
    public class LogFileTests
    {
        [TestMethod()]
        public void LogFileTest()
        {
            LogFile file = new LogFile("Test.dat", "E:\\tmp", "Temp");

            Assert.IsNotNull(file);
        }

        [TestMethod()]
        public void WriteLogTest()
        {
            LogFile file = new LogFile("Test.dat", "E:\\tmp", "Temp");
            List<LogMessage> msgs = new List<LogMessage>();
            msgs.Add(new LogMessage("The text one"+DateTime.Now.ToString()));
            msgs.Add(new LogMessage("The text two"+DateTime.Now.ToString()));
            msgs.Add(new LogMessage("The text three" + DateTime.Now.ToString()));

            file.WriteLog(msgs);
            //file.WriteLog(new LogMessage("ANother Text" + DateTime.Now.ToString()));

            Assert.IsNotNull(file);
        }

        [TestMethod()]
        public void ReadFileTest()
        {
            LogFile file = new LogFile("Test.dat", "E:\\tmp", "Temp");
            List<LogMessage> msgs = file.ReadFile();

            Assert.AreEqual(4, msgs.Count);
        }   
    }
}