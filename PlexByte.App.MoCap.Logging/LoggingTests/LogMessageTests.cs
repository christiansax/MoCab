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
    public class LogMessageTests
    {
        [TestMethod()]
        public void LogMessageCtorTest()
        {
            // Arange
            string message = "Test message";

            // Act
            LogMessage tmp = new LogMessage(message);

            // Assert
            Assert.AreEqual(message, tmp.Text);
        }

        [TestMethod()]
        public void LogMessageCtor1Test()
        {
            // Arange
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            // Act
            LogMessage tmp = new LogMessage(message, messageType);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
        }

        [TestMethod()]
        public void LogMessageCtor2Test()
        {
            // Arange
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            int pLevel = 61;
            // Act
            LogMessage tmp = new LogMessage(message, messageType, pLevel);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
            Assert.AreEqual(pLevel, tmp.Level);
        }

        [TestMethod()]
        public void LogMessageCtor3Test()
        {
            // Arange
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            int pLevel = 61;
            string pThread = "MyThread347889";
            // Act
            LogMessage tmp = new LogMessage(message, messageType, pLevel, pThread);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
            Assert.AreEqual(pLevel, tmp.Level);
            Assert.AreEqual(pThread, tmp.ThreadId);
        }

        [TestMethod()]
        public void LogMessageCtor4Test()
        {
            // Arange
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            int pLevel = 61;
            string pThread = "MyThread347889";
            string pContext = "MyContext";
            // Act
            LogMessage tmp = new LogMessage(message, messageType, pLevel, pThread, pContext);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
            Assert.AreEqual(pLevel, tmp.Level);
            Assert.AreEqual(pThread, tmp.ThreadId);
            Assert.AreEqual(pContext, tmp.Context);
        }

        [TestMethod()]
        public void LogMessageCtor5Test()
        {
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            int pLevel = 61;
            string pThread = "MyThread347889";
            string pContext = "MyContext";
            string pComponent = "MyComponent";
            // Act
            LogMessage tmp = new LogMessage(message, messageType, pLevel, pThread, pContext, pComponent);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
            Assert.AreEqual(pLevel, tmp.Level);
            Assert.AreEqual(pThread, tmp.ThreadId);
            Assert.AreEqual(pContext, tmp.Context);
            Assert.AreEqual(pComponent, tmp.Component);
        }

        [TestMethod()]
        public void LogMessageCtor6Test()
        {
            string message = "Test message";
            MessageType messageType = MessageType.Detail;
            int pLevel = 61;
            string pThread = "MyThread347889";
            string pContext = "MyContext";
            string pComponent = "MyComponent";
            string pAttribute = "MyAttr";
            // Act
            LogMessage tmp = new LogMessage(message, messageType, pLevel, pThread, pContext, pComponent, pAttribute);

            // Assert
            Assert.AreEqual(message, tmp.Text);
            Assert.AreEqual(messageType, tmp.Type);
            Assert.AreEqual(pLevel, tmp.Level);
            Assert.AreEqual(pThread, tmp.ThreadId);
            Assert.AreEqual(pContext, tmp.Context);
            Assert.AreEqual(pComponent, tmp.Component);
            Assert.AreEqual(pAttribute, tmp.Attribute1);
            Assert.IsNotNull(tmp.LineNumber);
        }
    }
}