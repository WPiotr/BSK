using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSK1;

namespace BSK1Tests
{
    [TestClass]
    public class SwitchingMatrixTest
    {
        [TestMethod]
        public void makeKeyFromLetter_correctRetrun()
        {
            String key1 = "ABCDEF";
            String key2 = "FEDCBA";
            String key3 = "CONVENIENCE";

            int[] key1_shouldreturn = { 0, 1, 2, 3, 4, 5 };
            int[] key2_shouldreturn = { 5, 4, 3, 2, 1, 0 };
            int[] key3_shouldreturn = { 1, 10, 7, 11, 3, 8, 6, 4, 9, 2, 5 };

            for (int i = 0; i < key3_shouldreturn.Length; i++)
            {
                key3_shouldreturn[i]--;
            }

            int[] key1_retrun = SwitchingMatrix.makeKeyFromLetter(key1);
            int[] key2_retrun = SwitchingMatrix.makeKeyFromLetter(key2);
            int[] key3_retrun = SwitchingMatrix.makeKeyFromLetter(key3);

            CollectionAssert.AreEqual(key1_shouldreturn, key1_retrun, "");
            CollectionAssert.AreEqual(key2_shouldreturn, key2_retrun, "");
            CollectionAssert.AreEqual(key3_shouldreturn, key3_retrun, "");
        }
        [TestMethod]
        public void transfromKeyTest_forDescrypt1()
        {
            String key = "3142";
            int[] result_excepted = { 2, 4, 1, 3 };

            for (int i = 0; i < result_excepted.Length; i++)
            {
                result_excepted[i]--;
            }

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            int[] result_actual = SwitchingMatrix.transformKey(key_table);

            CollectionAssert.AreEqual(result_excepted, result_actual, "");

        }
        [TestMethod]
        public void transfromMessageTest_ForDescrypt1()
        {
            String message = "YCPRGTROHAYPAOS";
            String key = "3142";
            String result_excepted = "YCPRGTROHAYPAO S";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            String result_actual = SwitchingMatrix.transformMessageForEncrypt1(message, key_table);

            Assert.AreEqual(result_excepted, result_actual);
        }
        [TestMethod]
        public void transfromKeyTest_forEncrypt2()
        {
            String key = "CONVENIENCE";
            int[] result_excepted = { 1, 10, 5, 8, 11, 7, 3, 6, 9, 2, 4 };



            for (int i = 0; i < result_excepted.Length; i++)
            {
                result_excepted[i]--;
            }

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            int[] result_actual = SwitchingMatrix.transformKey(key_table);

            CollectionAssert.AreEqual(result_excepted, result_actual, "");

        }
        [TestMethod]
        public void transfromMessageTest_ForDescrypt2()
        {
            String message = "HECRNCEYIISEPSGDIRNTOAAESRMPNSSROEEBTETIAEEHS";
            String key = "CONVENIENCE";
            String result_excepted = "HECRNCEYI ISEP SGDI RNTO AAES RMPN SSRO EEBT ETIA EEHS ";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            String result_actual = SwitchingMatrix.transformMessageForDescrypt2(message, key_table);

            Assert.AreEqual(result_excepted, result_actual);
        }
        [TestMethod]
        public void encrypt1_test()
        {
            String message = "CRYPTOGRAPHYOSA";
            String key = "3142";
            String result_excepted = "YCPRGTROHAYPAOS";

            String result_actual = SwitchingMatrix.encrypt(message, SwitchingMatrix.makeKeyFromLetter(key));

            Assert.AreEqual(result_excepted, result_actual);
        }
        [TestMethod]
        public void descrypt1_test()
        {
            String encrypted = "YCPRGTROHAYPAOS";
            String key = "3142";
            String result_excepted = "CRYPTOGRAPHYOSA";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
            String result_actual = SwitchingMatrix.encrypt(SwitchingMatrix.transformMessageForEncrypt1(encrypted, key_table), SwitchingMatrix.transformKey(key_table));
            result_actual = result_actual.Remove(result_actual.IndexOf(' '), result_actual.Length - result_actual.IndexOf(' '));
            Assert.AreEqual(result_excepted, result_actual);
        }
        // Zadanie drugie
        // encryptB(message,transformKey(key));
        // descryptB(transformMessageForEncrypt1(message),key); 
        [TestMethod]
        public void encrypt2_test()
        {
            String message = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";
            String key = "CONVENIENCE";
            String result_excepted = "HECRNCEYIISEPSGDIRNTOAAESRMPNSSROEEBTETIAEEHS";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            String result_actual = SwitchingMatrix.encryptB(message, SwitchingMatrix.transformKey(key_table));

            Assert.AreEqual(result_excepted, result_actual);

        }
        [TestMethod]
        public void descrypt2_test()
        {
            String encrypted = "HECRNCEYIISEPSGDIRNTOAAESRMPNSSROEEBTETIAEEHS";
            String key = "CONVENIENCE";
            String result_excepted = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
            String result_actual = SwitchingMatrix.descryptB(SwitchingMatrix.transformMessageForDescrypt2(encrypted, key_table), key_table);
            result_actual = result_actual.Remove(result_actual.IndexOf(' '), result_actual.Length - result_actual.IndexOf(' '));
            Assert.AreEqual(result_excepted, result_actual);

        }
        [TestMethod]
        public void encrypt3_test()
        {
            String message = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";
            String key = "CONVENIENCE";
            String result_excepted = "HEESPNIRRSSEESEIYASCBTEMGEPNANDICTRTAHSOIEERO";

            int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);

            String result_actual = SwitchingMatrix.encryptC(message, SwitchingMatrix.transformKey(key_table));

            Assert.AreEqual(result_excepted, result_actual);

        }
        [TestMethod]
        public void descrypt3_test()
        {

        }
    }

}
