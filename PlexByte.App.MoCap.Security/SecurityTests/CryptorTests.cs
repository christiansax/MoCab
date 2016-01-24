using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoCap.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCap.Security.Tests
{
    [TestClass()]
    public class CryptorTests
    {
        [TestMethod()]
        public void EncryptStringAESTest()
        {
            string sText = "I'm the mistr m";

            Cryptor cpt = new Cryptor();

            cpt.DecryptStringAES(sText, "This is the secret");

            Assert.Fail();
        }

        [TestMethod()]
        public void DecryptStringAESTest()
        {
            Assert.Fail();
        }
    }
}