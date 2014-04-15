using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSK2;
using System.Collections;
using System.Text;
namespace Tests
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string key = "133457799BBCDFF1";
            string message = "0123456789ABCDEF";

            //Utils.makeKey(key);
            
            BitArray encrypted_message = Utils.makeMessage(message);
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < encrypted_message.Length / 4; i++)
            {
                Decimal decimalValue = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (encrypted_message[i * 4 + j])
                    {
                        decimalValue += 1;
                    }
                    decimalValue *= 2;
                }
                decimalValue /= 2;
                sb.Append(decimalValue.ToString());
            }
            Assert.Equals("85E813540F0AB405",sb.ToString());
        }
    }
}
