using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSK2;

namespace Tests
{
    [TestClass]
    public class KeyTest
    {
        [TestMethod]
        public void createKey()
        {
            string key = "133457799BBCDFF1";

            BitArray excepted_key = new BitArray(64);
            string given_key_table = "00010011 00110100 01010111 01111001 10011011 10111100 11011111 11110001";
            for (int i = 0, j = 0; i < given_key_table.Length; i++)
            {
                if (given_key_table[i] == '0')
                {
                    excepted_key[j++] = false;
                }
                else if (given_key_table[i] == '1')
                {
                    excepted_key[j++] = true;
                }
            }
            Key test_key = new Key(key);

            CollectionAssert.AreEqual(excepted_key, test_key.bit_key, "Excepted:\n" + bitArrayToString(excepted_key) + " Actual\n" + bitArrayToString(test_key.bit_key));
            /*
            Key test_key = new Key(key);
            Assert.AreEqual(excepted_key.Length, test_key.key_plus.Length, "Excepted: length = " + excepted_key.Length + "\n" + bitArrayToString(excepted_key) + " Actual:length = " + test_key.bit_key.Length + "\n" + bitArrayToString(test_key.bit_key));
            for (int i = 0; i < excepted_key.Length;i++ )
            {
                Assert.AreEqual(excepted_key[i], test_key.key_plus[i], "Excepted:\n" + bitArrayToString(excepted_key) + " Actual\n" + bitArrayToString(test_key.bit_key));
            }*/
        }

        private string bitArrayToString(BitArray array)
        {
            string bitArray = "";
            for (int i = 0; i < array.Length; i++)
            {
                bool bit = array.Get(i);
                bitArray += (bit ? '1' : '0');
                if (i % 8 == 7 && i!=0)
                {
                    bitArray += ' ';
                }
            }
            return bitArray;
        }
    }
}
