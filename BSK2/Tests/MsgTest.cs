namespace Tests
{
    using System;
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BSK2;

    [TestClass]
    public class MsgTest
    {
        [TestMethod]
        public void loadMsg()
        {
            string path = "test.bin";
            Message msg = new Message(path);
            CollectionAssert.AllItemsAreNotNull(msg.bitMsg);
        }

        [TestMethod]
        public void initialPermutation()
        {
            Message msg = new Message("testowanie.bin");
            msg.initialPermutation();
            Message expected = new Message("expected.bin");

            CollectionAssert.AreEqual(expected.bitMsg, msg.bitMsg, "expected:" + expected.bitMsg.ToString() + "result:" + msg.bitMsg.ToString());
        }
        [TestMethod]
        public void createMessage()
        {
            string message = "0123456789ABCDEF";

            BitArray excepted_message;
            string given_message_table = "00000001 00100011 01000101 01100111 10001001 10101011 11001101 11101111";
            //message
            excepted_message = fromStringToBitArray(given_message_table, 64);
            Message test_message  = new Message(message,0);

            CollectionAssert.AreEqual(excepted_message, test_message.bitMsg, "Excepted:\n" + bitArrayToString(excepted_message) + " Actual\n" + bitArrayToString(test_message.bitMsg));

        }
        [TestMethod]
        public void initialPermutationMessage()
        {
            string message = "0123456789ABCDEF";

            BitArray excepted_message;
            string given_message_table = "11001100 00000000 11001100 11111111 11110000 10101010 11110000 10101010";
            excepted_message = fromStringToBitArray(given_message_table, 64);

            Message test_message = new Message(message, 0);
            test_message.initialPermutation();
            CollectionAssert.AreEqual(excepted_message, test_message.bitMsg, "Excepted:\n" + bitArrayToString(excepted_message) + " Actual\n" + bitArrayToString(test_message.bitMsg));
        }



        private string bitArrayToString(BitArray array)
        {
            string bitArray = "";
            for (int i = 0; i < array.Length; i++)
            {
                bool bit = array.Get(i);
                bitArray += (bit ? '1' : '0');
                if (i % 8 == 7 && i != 0)
                {
                    bitArray += ' ';
                }
            }
            return bitArray;
        }
        private BitArray fromStringToBitArray(string string_key, int length)
        {
            BitArray bit_key = new BitArray(length);
            for (int i = 0, j = 0; i < string_key.Length; i++)
            {
                if (string_key[i] == '0')
                {
                    bit_key[j++] = false;
                }
                else if (string_key[i] == '1')
                {
                    bit_key[j++] = true;
                }
            }
            return bit_key;
        }
        private BitArray fromStringToBitArray(string key)
        {
            int length = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] == '1' || key[i] == '0') length++;
            }
            return fromStringToBitArray(key, length);
        }
    }
}
