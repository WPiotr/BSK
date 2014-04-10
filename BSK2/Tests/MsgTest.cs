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

        [TestMethod]
        public void splittingMessage()
        {
            string message = "0123456789ABCDEF";

            BitArray excepted_left_message;
            BitArray excepted_right_message;
            string message_left_side = "11001100 00000000 11001100 11111111";
            string message_right_side = "11110000 10101010 11110000 10101010";

            excepted_left_message = fromStringToBitArray(message_left_side, 32);
            excepted_right_message = fromStringToBitArray(message_right_side, 32);

            Message test_message = new Message(message,0);
            test_message.initialPermutation();
            test_message.splitting();
            CollectionAssert.AreEqual(excepted_left_message, test_message.msg_left_side, "Excepted:\n" + bitArrayToString(excepted_left_message) + " Actual\n" + bitArrayToString(test_message.msg_left_side));
            CollectionAssert.AreEqual(excepted_right_message, test_message.msg_right_side, "Excepted:\n" + bitArrayToString(excepted_right_message) + " Actual\n" + bitArrayToString(test_message.msg_right_side));
        }

        [TestMethod]
        public void reverseConnectingMessage()
        {
            string message = "0123456789ABCDEF";

            BitArray excepted_message;
            string excepted_message_string = "00001010 01001100 11011001 10010101 01000011 01000010 00110010 00110100";

            excepted_message = fromStringToBitArray(excepted_message_string);


            Key key = new Key("133457799BBCDFF1");
            key.initialPermutation();
            key.splitting();
            key.shifts();
            key.finalPermutation();

            Message test_message = new Message(message, 0);
            test_message.initialPermutation();
            test_message.splitting();

            Iteration.setKeys(key.keys);
            Iteration iteration = new Iteration(test_message.msg_left_side, test_message.msg_right_side);
            for (int i = 1; i <= 16; i++)
            {
                iteration.ePermutation(i);
                iteration.xorWithKey(i);
                iteration.sBoxing(i);
                iteration.pPermutation(i);
                iteration.afterIteration(i);
            }
            test_message.reverseConnecting(iteration.leftSide[16], iteration.rightSide[16]);

            CollectionAssert.AreEqual(excepted_message, test_message.bitMsg, "Excepted:\n" + bitArrayToString(excepted_message) + " Actual\n" + bitArrayToString(test_message.bitMsg));
        }

        [TestMethod]
        public void finalPermutationMessage()
        {
            string message = "0123456789ABCDEF";

            BitArray excepted_message;
            string excepted_message_string = "10000101 11101000 00010011 01010100 00001111 00001010 10110100 00000101";

            excepted_message = fromStringToBitArray(excepted_message_string);


            Key key = new Key("133457799BBCDFF1");
            key.initialPermutation();
            key.splitting();
            key.shifts();
            key.finalPermutation();

            Message test_message = new Message(message, 0);
            test_message.initialPermutation();
            test_message.splitting();

            Iteration.setKeys(key.keys);
            Iteration iteration = new Iteration(test_message.msg_left_side, test_message.msg_right_side);
            for (int i = 1; i <= 16; i++)
            {
                iteration.ePermutation(i);
                iteration.xorWithKey(i);
                iteration.sBoxing(i);
                iteration.pPermutation(i);
                iteration.afterIteration(i);
            }
            test_message.reverseConnecting(iteration.leftSide[16], iteration.rightSide[16]);
            test_message.finalPermutation();

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
