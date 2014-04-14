using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using BSK2.Properties;
using BSK2;
using System.Diagnostics;
namespace Tests
{

    // Given message (in hex):
    //  0123456789ABCDEF

    // Given message M:
    //  00000001 00100011 01000101 01100111 10001001 10101011 11001101 11101111
    // IP:
    //  11001100 00000000 11001100 11111111 11110000 10101010 11110000 10101010
    // L0:
    //  11001100 00000000 11001100 11111111
    // R0:
    //  11110000 10101010 11110000 10101010
    // e permutation method
    // E(R0):
    //  011110 100001 010101 010101 011110 100001 010101 010101
    // xor method   
    // K1 XOR E(R0):
    //  011000 010001 011110 111010 100001 100110 010100 100111
    // s box method
    // S(B1)S(B2)S(B3)S(B4)S(B5)S(B6)S(B7)S(B8):
    //  0101 1100 1000 0010 1011 0101 1001 0111
    // p permutation method
    // f = P[S(B1)S(B2)S(B3)S(B4)S(B5)S(B6)S(B7)S(B8)]:
    //  0010 0011 0100 1010 1010 1001 1011 1011
    // afterIteration method
    // R1 = L0 XOR f(R0,K1):
    //  1110 1111 0100 1010 0110 0101 0100 0100
    // L1 = R0:
    //  1111 0000 1010 1010 1111 0000 1010 1010
    // L1:
    //  1111 0000 1010 1010 1111 0000 1010 1010
    // R1:
    //  1110 1111 0100 1010 0110 0101 0100 0100
    // L16:
    //  0100 0011 0100 0010 0011 0010 0011 0100
    // R16:
    //  0000 1010 0100 1100 1101 1001 1001 0101
    // giveSBoxRow
    // 0 1 0 2 3 2 0 3
    // giveSBoxColumn
    // 12 8 15 13 0 3 10 3
    [TestClass]
    public class IterationTest
    {
        private static String left_side_string;
        private static String right_side_string;

        private static BitArray left_side_test;
        private static BitArray right_side_test;

        private static TestContext context;
        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        private static BitArray[] keys;

        Iteration iteration_test;

        [ClassInitialize()]
        public static void iterationClassInitialize(TestContext context)
        {
            left_side_string = "11001100 00000000 11001100 11111111";
            right_side_string = "11110000 10101010 11110000 10101010";

            left_side_test = fromStringToBitArray(left_side_string, 32);
            right_side_test = fromStringToBitArray(right_side_string, 32);

            makeKey();
            Iteration.setKeys(keys);

            IterationTest.context = context;
        }
        [TestInitialize()]
        public void iterationTestInitialize()
        {
            this.iteration_test = new Iteration(left_side_test, right_side_test);

            Debug.WriteLine("Name: " + context.TestName);
        }
        // e permutation method
        // E(R0):
        //  011110 100001 010101 010101 011110 100001 010101 010101

        [TestMethod]
        public void ePermutationTest()
        {
            string exceptedResultString = "011110 100001 010101 010101 011110 100001 010101 010101";
            BitArray expectedResult = fromStringToBitArray(exceptedResultString, 48);

            this.iteration_test.ePermutation(1);

            CollectionAssert.AreEqual(expectedResult, this.iteration_test.rightSide[1], "Excepted:\n" +
                bitArrayToString(expectedResult) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[1]));

        }
        // xor method   
        // K1 XOR E(R0):
        //  011000 010001 011110 111010 100001 100110 010100 100111

        [TestMethod]
        public void xorWithKeyTest()
        {
            string exceptedResultString = "011000 010001 011110 111010 100001 100110 010100 100111";
            BitArray expectedResult = fromStringToBitArray(exceptedResultString);

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);

            CollectionAssert.AreEqual(expectedResult, this.iteration_test.rightSide[1], "Excepted:\n" +
                bitArrayToString(expectedResult) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[1]));

        }
        // s box method
        // S(B1)S(B2)S(B3)S(B4)S(B5)S(B6)S(B7)S(B8):
        //  0101 1100 1000 0010 1011 0101 1001 0111

        [TestMethod]
        public void sBoxingTest()
        {
            string exceptedResultString = "0101 1100 1000 0010 1011 0101 1001 0111";
            BitArray expectedResult = fromStringToBitArray(exceptedResultString);

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);
            this.iteration_test.sBoxing(1);

            CollectionAssert.AreEqual(expectedResult, this.iteration_test.rightSide[1], "Excepted:\n" +
                bitArrayToString(expectedResult) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[1]));

        }
        // p permutation method
        // f = P[S(B1)S(B2)S(B3)S(B4)S(B5)S(B6)S(B7)S(B8)]:
        //  0010 0011 0100 1010 1010 1001 1011 1011
        [TestMethod]
        public void pPermutationTest()
        {
            string exceptedResultString = "0010 0011 0100 1010 1010 1001 1011 1011";
            BitArray expectedResult = fromStringToBitArray(exceptedResultString);

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);
            this.iteration_test.sBoxing(1);
            this.iteration_test.pPermutation(1);

            CollectionAssert.AreEqual(expectedResult, this.iteration_test.rightSide[1], "Excepted:\n" +
                bitArrayToString(expectedResult) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[1]));

        }
        // afterIteration method
        // R1 = L0 XOR f(R0,K1):
        //  1110 1111 0100 1010 0110 0101 0100 0100
        // L1 = R0:
        //  1111 0000 1010 1010 1111 0000 1010 1010
        // L1:
        //  1111 0000 1010 1010 1111 0000 1010 1010
        // R1:
        //  1110 1111 0100 1010 0110 0101 0100 0100
        [TestMethod]
        public void afterIterationTest()
        {
            string excepted_left_side_string = "1111 0000 1010 1010 1111 0000 1010 1010";
            string excepted_right_side_string = "1110 1111 0100 1010 0110 0101 0100 0100";

            BitArray expected_left_side = fromStringToBitArray(excepted_left_side_string);
            BitArray expected_right_side = fromStringToBitArray(excepted_right_side_string);

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);
            this.iteration_test.sBoxing(1);
            this.iteration_test.pPermutation(1);
            this.iteration_test.afterIteration(1);

            CollectionAssert.AreEqual(expected_left_side, this.iteration_test.leftSide[1], "Excepted:\n" +
                bitArrayToString(expected_left_side) + " Actual\n" + bitArrayToString(this.iteration_test.leftSide[1]));
            CollectionAssert.AreEqual(expected_right_side, this.iteration_test.rightSide[1], "Excepted:\n" +
                bitArrayToString(expected_right_side) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[1]));
        }
        // L16:
        //  0100 0011 0100 0010 0011 0010 0011 0100
        // R16:
        //  0000 1010 0100 1100 1101 1001 1001 0101

        [TestMethod]
        public void afterLastIterationTest()
        {
            string excepted_left_side_string = "0100 0011 0100 0010 0011 0010 0011 0100";
            string excepted_right_side_string = "0000 1010 0100 1100 1101 1001 1001 0101";

            BitArray expected_left_side = fromStringToBitArray(excepted_left_side_string);
            BitArray expected_right_side = fromStringToBitArray(excepted_right_side_string);
            for (int i = 1; i <= 16; i++)
            {
                this.iteration_test.ePermutation(i);
                this.iteration_test.xorWithKey(i);
                this.iteration_test.sBoxing(i);
                this.iteration_test.pPermutation(i);
                this.iteration_test.afterIteration(i);
            }

            CollectionAssert.AreEqual(expected_left_side, this.iteration_test.leftSide[16], "Excepted:\n" +
                bitArrayToString(expected_left_side) + " Actual\n" + bitArrayToString(this.iteration_test.leftSide[16]));
            CollectionAssert.AreEqual(expected_right_side, this.iteration_test.rightSide[16], "Excepted:\n" +
                bitArrayToString(expected_right_side) + " Actual\n" + bitArrayToString(this.iteration_test.rightSide[16]));
        }

        // giveSBoxRow
        // 0 1 0 2 3 2 0 3
        [TestMethod]
        public void sBoxrRowsTest()
        {
            int[] except_rows = { 0, 1, 0, 2, 3, 2, 0, 3 };

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);

            int[] rows_in_s_box_test = new int[except_rows.Length];

            for (int i = 0; i < 8; i++)
            {
                rows_in_s_box_test[i] = Iteration.giveSBoxRow(this.iteration_test.rightSide[1][i * 6],
                    this.iteration_test.rightSide[1][i * 6 + 5]);
            }
            CollectionAssert.AreEqual(except_rows, rows_in_s_box_test, "Excepted:\n" + except_rows.ToString() + " Actual\n" +
                rows_in_s_box_test.ToString());
        }
        // giveSBoxColumn
        // 12 8 15 13 0 3 10 3
        [TestMethod]
        public void sBoxrColumnsTest()
        {
            int[] except_columns = { 12, 8, 15, 13, 0, 3, 10, 3 };

            this.iteration_test.ePermutation(1);
            this.iteration_test.xorWithKey(1);

            int[] columns_in_s_box_test = new int[except_columns.Length];

            for (int i = 0; i < 8; i++)
            {
                columns_in_s_box_test[i] = Iteration.giveSBoxColumn(this.iteration_test.rightSide[1], i);
            }
            CollectionAssert.AreEqual(except_columns, columns_in_s_box_test, "Excepted:\n" + except_columns.ToString() + " Actual\n" +
                columns_in_s_box_test.ToString());
        }
        private static void makeKey()
        {
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

            keys = new BitArray[17];

            for (int i = 1; i < 17; i++)
            {
                keys[i] = fromStringToBitArray(key_string[i], 48);
            }
        }

        private static string bitArrayToString(BitArray array)
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
        private static BitArray fromStringToBitArray(string string_key, int length)
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
        private static BitArray fromStringToBitArray(string key)
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
