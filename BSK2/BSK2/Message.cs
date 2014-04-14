

namespace BSK2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Message
    {


        public BitArray bitMsg;
        public BitArray msg_left_side;
        public BitArray msg_right_side;

        private static int[] ipTable = { 58, 50, 42, 34, 26, 18, 10, 2,
                                 60, 52, 44, 36, 28, 20, 12, 4,
                                 62, 54, 46, 38, 30, 22, 14, 6,
                                 64, 56, 48, 40, 32, 24, 16, 8,
                                 57, 49, 41, 33, 25, 17, 9, 1,
                                 59, 51, 43, 35, 27, 19, 11, 3,
                                 61, 53, 45, 37, 29, 21, 13, 5,
                                 63, 55, 47, 39, 31, 23, 15, 7 };
        private static int[] ipTableReserve = { 40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31, 38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29, 36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27, 34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25 };

        private string msg;

        public Message(string pathToFile)
        {
            string input = File.ReadAllText(pathToFile);
            bool[] boolArray = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('1'))
                {
                    boolArray[i] = true;
                }
                else
                {
                    boolArray[i] = false;
                }
            }
            this.bitMsg = new BitArray(boolArray);
        }

        public Message(byte[] testArray)
        {
            this.bitMsg = new BitArray(testArray);
        }

        public Message(string message_in_hexa, int hexa)
        {
            this.msg = message_in_hexa;
            this.bitMsg = new BitArray(message_in_hexa.Length * 4);
            int j = 0;
            foreach (char c in message_in_hexa)
            {
                byte[] byte_msg = BitConverter.GetBytes(c);
                if (char.IsDigit(c))
                {
                    byte_msg[0] -= (int)'0';
                }
                else
                {
                    byte_msg[0] -= (int)'A';
                    byte_msg[0] += 10;
                }
                BitArray one_byte = new BitArray(byte_msg);
                for (int i = 3; i >= 0; i--, j++)
                {
                    this.bitMsg.Set(j, one_byte[i]);
                }
            }
        }

        public void initialPermutation()
        {
            BitArray copy_message = new BitArray(this.bitMsg);
            for (int i = 0; i < 64; i++)
            {
                this.bitMsg[i] = copy_message[ipTable[i] - 1];
            }
        }
        public void splitting()
        {
            this.msg_left_side = new BitArray(32);
            this.msg_right_side = new BitArray(32);
            for (int i = 0; i < 32; i++)
            {
                this.msg_left_side[i] = this.bitMsg[i];
            }
            for (int i = 32; i < 64; i++)
            {
                this.msg_right_side[i - 32] = this.bitMsg[i];
            }
        }
        public void reverseConnecting(BitArray left_side, BitArray right_side)
        {
            this.msg_left_side = new BitArray(left_side);
            this.msg_right_side = new BitArray(right_side);
            this.bitMsg = new BitArray(left_side.Length + right_side.Length);
            for (int i = 0; i < 32; i++)
            {
                this.bitMsg[i] = this.msg_right_side[i];
            }
            for (int i = 32; i < 64; i++)
            {
                this.bitMsg[i] = this.msg_left_side[i - 32];
            }
        }
        public void finalPermutation()
        {
            BitArray copy_message = new BitArray(this.bitMsg);
            for (int i = 0; i < 64; i++)
            {
                this.bitMsg[i] = copy_message[ipTableReserve[i] - 1];
            }
        }


    }
}
