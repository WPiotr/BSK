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

            CollectionAssert.AreEqual(excepted_key, test_key.bit_key, "Excepted:\n" + this.bitArrayToString(excepted_key) + " Actual\n" + this.bitArrayToString(test_key.bit_key));
        }
        [TestMethod]
        public void initialPermutationKey()
        {
            string key = "133457799BBCDFF1";

            BitArray excepted_key = new BitArray(56);
            string given_key_table = "1111000 0110011 0010101 0101111 0101010 1011001 1001111 0001111";
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
            test_key.initialPermutation();
            CollectionAssert.AreEqual(excepted_key, test_key.key_plus, "Excepted:\n" + this.bitArrayToString(excepted_key) + " Actual\n" + this.bitArrayToString(test_key.bit_key));
        }
        [TestMethod]
        public void splittingKey()
        {
            string key = "133457799BBCDFF1";

            BitArray excepted_left_key;
            BitArray excepted_right_key;
            string key_left_side = "1111000 0110011 0010101 0101111";
            string key_right_side = "0101010 1011001 1001111 0001111";
            excepted_left_key = this.fromStringToBitArray(key_left_side, 28);
            excepted_right_key = this.fromStringToBitArray(key_right_side, 28);

            Key test_key = new Key(key);
            test_key.initialPermutation();
            test_key.splitting();
            CollectionAssert.AreEqual(excepted_left_key, test_key.key_left_side, "Excepted:\n" + this.bitArrayToString(excepted_left_key) + " Actual\n" + this.bitArrayToString(test_key.key_left_side));
            CollectionAssert.AreEqual(excepted_right_key, test_key.key_right_side, "Excepted:\n" + this.bitArrayToString(excepted_right_key) + " Actual\n" + this.bitArrayToString(test_key.key_right_side));
        }
        [TestMethod]
        public void shiftsKey()
        {
            string key = "133457799BBCDFF1";
            string[] c_string = new string[17];
            string[] d_string = new string[17];

            c_string[0] = " 1111000011001100101010101111"; d_string[0] = " 0101010101100110011110001111";
            c_string[1] = " 1110000110011001010101011111"; d_string[1] = " 1010101011001100111100011110";
            c_string[2] = " 1100001100110010101010111111"; d_string[2] = " 0101010110011001111000111101";
            c_string[3] = " 0000110011001010101011111111"; d_string[3] = " 0101011001100111100011110101";
            c_string[4] = " 0011001100101010101111111100"; d_string[4] = " 0101100110011110001111010101";
            c_string[5] = " 1100110010101010111111110000"; d_string[5] = " 0110011001111000111101010101";
            c_string[6] = " 0011001010101011111111000011"; d_string[6] = " 1001100111100011110101010101";
            c_string[7] = " 1100101010101111111100001100"; d_string[7] = " 0110011110001111010101010110";
            c_string[8] = " 0010101010111111110000110011"; d_string[8] = " 1001111000111101010101011001";
            c_string[9] = " 0101010101111111100001100110"; d_string[9] = " 0011110001111010101010110011";
            c_string[10] = " 0101010111111110000110011001"; d_string[10] = " 1111000111101010101011001100";
            c_string[11] = " 0101011111111000011001100101"; d_string[11] = " 1100011110101010101100110011";
            c_string[12] = " 0101111111100001100110010101"; d_string[12] = " 0001111010101010110011001111";
            c_string[13] = " 0111111110000110011001010101"; d_string[13] = " 0111101010101011001100111100";
            c_string[14] = " 1111111000011001100101010101"; d_string[14] = " 1110101010101100110011110001";
            c_string[15] = " 1111100001100110010101010111"; d_string[15] = " 1010101010110011001111000111";
            c_string[16] = " 1111000011001100101010101111"; d_string[16] = " 0101010101100110011110001111";

            BitArray[] excepted_c_keys = new BitArray[17];
            BitArray[] excepted_d_keys = new BitArray[17];

            for (int i = 0; i < 17; i++)
            {
                excepted_c_keys[i] = this.fromStringToBitArray(c_string[i], 28);
                excepted_d_keys[i] = this.fromStringToBitArray(d_string[i], 28);
            }
            Key test_key = new Key(key);
            test_key.initialPermutation();
            test_key.splitting();
            test_key.shifts();
            for (int i = 0; i < 17; i++)
            {
                CollectionAssert.AreEqual(excepted_c_keys[i], test_key.c_key[i], "Excepted:\n" + this.bitArrayToString(excepted_c_keys[i]) + " Actual\n" + this.bitArrayToString(test_key.c_key[i]));
                CollectionAssert.AreEqual(excepted_d_keys[i], test_key.d_key[i], "Excepted:\n" + this.bitArrayToString(excepted_d_keys[i]) + " Actual\n" + this.bitArrayToString(test_key.d_key[i]));

            }
        }
        [TestMethod]
        public void finalPermutationKey()
        {
            string key = "133457799BBCDFF1";
            string[] key_string = new string[17];


            key_string[1] = " 000110 110000 001011 101111 111111 000111 000001 110010";
            key_string[2] = " 011110 011010 111011 011001 110110 111100 100111 100101";
            key_string[3] = " 010101 011111 110010 001010 010000 101100 111110 011001";
            key_string[4] = " 011100 101010 110111 010110 110110 110011 010100 011101";
            key_string[5] = " 011111 001110 110000 000111 111010 110101 001110 101000";
            key_string[6] = " 011000 111010 010100 111110 010100 000111 101100 101111";
            key_string[7] = " 111011 001000 010010 110111 111101 100001 100010 111100";
            key_string[8] = " 111101 111000 101000 111010 110000 010011 101111 111011";
            key_string[9] = " 111000 001101 101111 101011 111011 011110 011110 000001";
            key_string[10] = " 101100 011111 001101 000111 101110 100100 011001 001111";
            key_string[11] = " 001000 010101 111111 010011 110111 101101 001110 000110";
            key_string[12] = " 011101 010111 000111 110101 100101 000110 011111 101001";
            key_string[13] = " 100101 111100 010111 010001 111110 101011 101001 000001";
            key_string[14] = " 010111 110100 001110 110111 111100 101110 011100 111010";
            key_string[15] = " 101111 111001 000110 001101 001111 010011 111100 001010";
            key_string[16] = " 110010 110011 110110 001011 000011 100001 011111 110101";

            BitArray[] excepted_keys = new BitArray[17];

            for (int i = 1; i < 17; i++)
            {
                excepted_keys[i] = this.fromStringToBitArray(key_string[i], 48);
            }
            Key test_key = new Key(key);
            test_key.initialPermutation();
            test_key.splitting();
            test_key.shifts();
            test_key.finalPermutation();
            for (int i = 1; i < 17; i++)
            {
                CollectionAssert.AreEqual(excepted_keys[i], test_key.keys[i], "Excepted:\n" + this.bitArrayToString(excepted_keys[i]) + " Actual\n" + this.bitArrayToString(test_key.keys[i]));
            }
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
            return this.fromStringToBitArray(key, length);
        }
    }
}
