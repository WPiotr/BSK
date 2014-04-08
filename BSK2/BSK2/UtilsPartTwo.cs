using System;
using System.Collections;
using System.IO;
namespace BSK2
{
    public partial class Utils
    {

    }

    public class Message
    {
        private string msg;
        private int[] ipTable = {58, 50, 42, 34, 26, 18, 10, 2,
                                 60, 52, 44, 36, 28, 20, 12, 4,
                                 62, 54, 46, 38, 30, 22, 14, 6,
                                 64, 56, 48, 40, 32, 24, 16, 8,
                                 57, 49, 41, 33, 25, 17, 9, 1,
                                 59, 51, 43, 35, 27, 19, 11, 3,
                                 61, 53, 45, 37, 29, 21, 13, 5,
                                 63, 55, 47, 39, 31, 23, 15, 7};
        public BitArray bitMsg;

        public Message(string pathToFile) {
            string input = File.ReadAllText(pathToFile);
            bool[] boolArray = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
			{
			    if(input[i].Equals('1')){
                    boolArray[i]=true;
                }    
                else
                {
                    boolArray[i]=false;
                } 
			}
            bitMsg = new BitArray(boolArray);
        }

        public Message(byte[] testArray){
            bitMsg = new BitArray(testArray);
        }

        public Message(string message_in_hexa, int hexa)
        {
            bitMsg = new BitArray(message_in_hexa.Length * 4);
            int j = 0;
            foreach (char c in message_in_hexa)
            {
                byte[] byte_msg = BitConverter.GetBytes(c);
                if (Char.IsDigit(c))
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
                    bitMsg.Set(j, one_byte[i]);
                }
            }
        }

        public void initialPermutation()
        {
            BitArray copy_message = new BitArray(bitMsg);
            for (int i = 0; i < 64; i++)
            {
                bitMsg[i] = copy_message[ipTable[i] - 1];
            }
        }
        public void splitting()
        {

        }
        public void reverseConnecting()
        {
        }
        public void finalPermutation()
        {
        }


    }

}
