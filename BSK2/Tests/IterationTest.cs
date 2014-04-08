using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using BSK2.Properties;
using BSK2;
namespace Tests
{
    [TestClass]
    public class IterationTest
    {
        [TestMethod]
        public void ePermutationTest()
        {
            String inputString = "1111 0000 1010 1010 1111 0000 1010 1010";
            BitArray input = new BitArray(32);
            for (int j = 0, i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '0') {
                    input[j++] = false;
                }

                if (inputString[i] == '1') {
                    input[j++] = true;
                }
            }


            BitArray expectedResult = new BitArray(64);
            string exceptedResultString = "011110 100001 010101 010101 011110 100001 010101 010101";
            for (int i = 0, j = 0; i < exceptedResultString.Length; i++)
            {
                if (exceptedResultString[i] == '0')
                {
                    expectedResult[j++] = false;
                }
                else if (exceptedResultString[i] == '1')
                {
                    expectedResult[j++] = true;
                }
            }

            Iteration it = new Iteration(input, input);
            it.ePermutation(1);
            CollectionAssert.AreEqual(it.rightSide[1], expectedResult);

        }
    }
}
