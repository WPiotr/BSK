using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BSK2
{
    public partial class Utils
    {
        public static string Encrypt(String inputString, String key)
        {
            return null;
        }
        public static string Decrypt(String inputString, String key)
        {
            return null;
        }
    }
    public class Key
    {
        string key;
        int[] PC_1 =        {57,49,41,33,25,17,9,
                            1,58,50,42,34,26,18,
                            10,2,59,51,43,35,27,
                            19,11,3,60,52,44,36,
                            63,55,47,39,31,23,15,
                            7,62,54,46,38,30,22,
                            14,6,61,53,45,37,29,
                            21,13,5,28,20,12,4};
        public BitArray bit_key;
        public BitArray key_plus;
        public Key(string key){
            this.key = key;
            bit_key = new BitArray(key.Length * 4);
            int j = 0;
            foreach (char c in key)
            {
                byte[] byte_key = BitConverter.GetBytes(c);
                if (Char.IsDigit(c))
                {
                    byte_key[0] -= (int)'0';
                }
                else
                {
                    byte_key[0] -= (int)'A';
                    byte_key[0] += 10;
                }
                BitArray one_byte = new BitArray(byte_key);
                for (int i = 3; i >= 0; i--,j++)
                {
                    bit_key.Set(j, one_byte[i]);
                }
            }
        }
        public void initialPermutation()
        {
        }
        public void splitting()
        {
        }
        public void shifts()
        {
        }
        public void finalPermutation()
        {
        }
    }
    public class Message
    {
        public void initialPermutation()
        {
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
