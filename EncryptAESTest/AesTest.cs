using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptAES;

namespace EncryptAESTest
{
    [TestClass]
    public class AesTest
    {
        private readonly AESManager aesManager;

        public AesTest()
        {
            aesManager = new AESManager();
            aesManager.Initialize();
            aesManager.Password = "HelloPassword!=@";
        }

        [TestMethod]
        [Timeout(1000)]
        public void EncryptText()
        {
            string input = "Hello!-@123 World!";
            string encrypted = aesManager.EncryptText(input);
            string decrypted = aesManager.DecryptText(encrypted);

            Assert.AreEqual(input, decrypted);
        }
    }
}
