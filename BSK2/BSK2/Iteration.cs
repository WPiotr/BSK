using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK2
{
    class Iteration
    {
        #region S-Boxy
        public static int[][] sBox1 = {
                new int[] {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                new int[] {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                new int[] {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0}, 
                new int[] {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}};

        public static int[][] sBox2 = {
                new int[] {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                new int[] {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                new int[] {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                new int[] {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}};

        public static int[][] sBox3 = { 
                new int[] {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8}, 
                new int[] {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                new int[] {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                new int[] {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}};

        public static int[][] sBox4 = { 
                new int[] {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                new int[] {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                new int[] {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                new int[] {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}};

        public static int[][] sBox5 = { 
                new int[] {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                new int[] {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                new int[] {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                new int[] {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}};

        public static int[][] sBox6 = {
                new int[] {12, 1, 10, 15, 9,  2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                new int[] {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                new int[] {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                new int[] {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}};

        public static int[][] sBox7 = { 
                new int[] {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                new int[] {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                new int[] {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                new int[] {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}};

        public static int[][] sBox8 = {
                new int[] {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                new int[] {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                new int[] {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                new int[] {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}};

        #endregion

        public static int[][][] s_box = null;

        public static int[] primitiveFunction = { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23, 26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3, 9, 19, 13, 30, 6, 22, 11, 4, 25 };

        public static int[] eTable = new int[] { 32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9, 8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17, 16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25, 24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1 };

        public BitArray[] leftSide = new BitArray[17];
        public BitArray[] rightSide = new BitArray[17];
        public BitArray[] keys = new BitArray[16];
        public Iteration(BitArray leftSide, BitArray rightSide)
        {
            this.leftSide[0] = leftSide;
            this.rightSide[0] = rightSide;
            if (s_box == null)
            {
                s_box = new int[8][][];
                s_box[0] = sBox1;
                s_box[1] = sBox2;
                s_box[2] = sBox3;
                s_box[3] = sBox4;
                s_box[4] = sBox5;
                s_box[5] = sBox6;
                s_box[6] = sBox7;
                s_box[7] = sBox8;
            }
        }

        public void startIteration()
        {

        }

        public void ePermutation(int iterationIndex)
        {
            BitArray resultArray = new BitArray(48);
            for (int i = 0; i < eTable.Length; i++)
            {
                resultArray[i] = rightSide[iterationIndex - 1][eTable[i]];
            }
            rightSide[iterationIndex] = resultArray;
        }

        public void xorWithKey(int iterationIndex)
        {
            BitArray resultArray = new BitArray(rightSide[iterationIndex]);
            resultArray = resultArray.Xor(keys[iterationIndex]);
            rightSide[iterationIndex] = resultArray;
        }

        public void sBoxing(int iterationIndex)
        {
            BitArray bit_value_form_s_box = new BitArray(32);
            int row_in_s_box;
            int column_in_s_box;

            int bit_counter = 0;
            for (int i = 0; i < 8; i++)
            {
                row_in_s_box = giveSBoxRow(rightSide[iterationIndex][i * 6], rightSide[iterationIndex][i * 6 + 5]);
                column_in_s_box = giveSBoxColumn(rightSide[iterationIndex], i);

                int value_form_s_box = s_box[i][row_in_s_box][column_in_s_box];

                byte[] byte_value_form_s_box = BitConverter.GetBytes(value_form_s_box);

                BitArray one_byte = new BitArray(byte_key);
                for (int j = 3; j >= 0; j--, bit_counter++)
                {
                    bit_value_form_s_box.Set(bit_counter, one_byte[j]);
                }
                
            }
            rightSide = s_box_message;
        }
        public int giveSBoxRow(bool first, bool second)
        {
            if (first && second)
                return 3;
            else if (first)
                return 2;
            else if (second)
                return 1;
            else
                return 0;
        }
        public int giveSBoxRow(BitArray array, int part)
        {
            if (array[part * 6] && array[part * 6 + 5])
                return 3;
            else if (array[part * 6])
                return 2;
            else if (array[part * 6 + 5])
                return 1;
            else
                return 0;
        }
        public int giveSBoxColumn(BitArray array, int part)
        {
            int row = 0;
            for (int i = 0; i < 4; i++)
            {
                if (array[part * 6 + 1 + i])
                {
                    row += 1;
                    row *= 2;
                }
            }
            row /= 2;
            return row;
        }

    }
}
