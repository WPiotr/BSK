
namespace BSK2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Key
    {
        public string key;
        public BitArray bit_key;
        public BitArray key_plus;
        public BitArray key_left_side;
        public BitArray key_right_side;

        public BitArray[] c_key;
        public BitArray[] d_key;

        public BitArray[] keys;

        private static int[] PC_1 = { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36, 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4 };
        private static int[] PC_2 = { 14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32 };
        int[] shifts_table = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        public Key(string key)
        {
            this.key = key;
            this.bit_key = new BitArray(this.key.Length * 4);
            int j = 0;
            foreach (char c in key)
            {
                byte[] byte_key = BitConverter.GetBytes(c);
                if (char.IsDigit(c))
                {
                    byte_key[0] -= (int)'0';
                }
                else
                {
                    byte_key[0] -= (int)'A';
                    byte_key[0] += 10;
                }
                BitArray one_byte = new BitArray(byte_key);
                for (int i = 3; i >= 0; i--, j++)
                {
                    this.bit_key.Set(j, one_byte[i]);
                }
            }
        }
        public void initialPermutation()
        {
            this.key_plus = new BitArray(56);
            for (int i = 0; i < 56; i++)
            {
                this.key_plus[i] = this.bit_key[PC_1[i] - 1];
            }
        }

        public void reverseKey() 
        {
            BitArray[] keys_tmp = keys;
            keys = new BitArray[keys_tmp.Length];
            for (int i = 1; i < keys.Length; i++)
            {
                keys[i] = keys_tmp[keys.Length-i];

            }
        }

        public void splitting()
        {
            this.key_left_side = new BitArray(28);
            this.key_right_side = new BitArray(28);
            for (int i = 0; i < 28; i++)
            {
                this.key_left_side[i] = this.key_plus[i];
            }
            for (int i = 28; i < 56; i++)
            {
                this.key_right_side[i - 28] = this.key_plus[i];
            }
        }
        public void shifts()
        {
            this.c_key = new BitArray[17];
            this.d_key = new BitArray[17];
            this.c_key[0] = this.key_left_side;
            this.d_key[0] = this.key_right_side;
            for (int i = 1; i < 17; i++)
            {
                BitArray temp_c = new BitArray(28);
                BitArray temp_d = new BitArray(28);
                for (int j = 0; j < 28; j++)
                {
                    temp_c[j] = this.c_key[i - 1][(j + this.shifts_table[i - 1]) % 28];
                    temp_d[j] = this.d_key[i - 1][(j + this.shifts_table[i - 1]) % 28];
                }
                this.c_key[i] = temp_c;
                this.d_key[i] = temp_d;
            }
        }
        public void finalPermutation()
        {
            this.keys = new BitArray[17];
            this.keys[0] = this.key_plus;
            for (int i = 1; i < 17; i++)
            {
                this.keys[i] = new BitArray(48);
                for (int j = 0; j < 24; j++)
                {
                    this.keys[i][j] = this.c_key[i][PC_2[j] - 1];
                }
                for (int j = 24; j < 48; j++)
                {
                    this.keys[i][j] = this.d_key[i][PC_2[j] - 1 - 28];
                }
            }
        }
    }
}
