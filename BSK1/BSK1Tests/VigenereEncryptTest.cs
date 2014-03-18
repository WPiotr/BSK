using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSK1;

namespace BSK1Tests
{
    [TestClass]
    public class VigenereEncryptTest
    {
        [TestMethod]
        public void encryptTest()
        {

            String message = "CRYPTOGRAPHY";
            String key = "BREAKBREAKBR";
            String result_excepted = "DICPDPXVAZIP";

            String result_actual = VigenereEncrypt.encrypt(message, key);

            Assert.AreEqual(result_excepted, result_actual);
        }
        [TestMethod]
        public void descryptTest()
        {

            String message = "DICPDPXVAZIP";
            String key = "BREAKBREAKBR";
            String result_excepted = "CRYPTOGRAPHY";

            String result_actual = VigenereEncrypt.descrypt(message, key);

            Assert.AreEqual(result_excepted, result_actual);
        }
    }
}
