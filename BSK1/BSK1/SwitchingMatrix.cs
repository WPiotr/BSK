using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    // Zadanie pierwsze
    // encrypt(message,key); szyfrowanie
    // encrypt(transformMessage(message),transformKey(key)); rozszyfrowanie

    // Zadanie drugie
    // encryptB(message,transformKey(key));
    // descryptB(transformMessage(message),key); // nei wiem czy zadziala, trzeba chyba zmienic transformMessage

    class SwitchingMatrix
    {
        public static String encrypt(String message, int[] key)
        {
            String encrypted = "";
            for (int i = 0, j = 0; i < message.Length; i++, j++)
            {
                if (key[j % key.Length] + (j / key.Length) * key.Length < message.Length)
                    encrypted += message[key[j % key.Length] + (j / key.Length) * key.Length];
                else
                    i--;
            }
            return encrypted;
        }
        public static int[] transformKey(int[] key)
        {
            int[] newKey = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                newKey[key[i]] = i;
            }
            return newKey;
        }
        public static String transformMessage(String message, int[] key)
        {
            String transformMessage = "";
            for (int i = 0; i < ((message.Length / key.Length) * key.Length); i++)
            {
                transformMessage += message[i];
            }
            for (int i = ((message.Length / key.Length) * key.Length), j = ((message.Length / key.Length) * key.Length);
            i < ((message.Length / key.Length + 1) * key.Length);
            i++)
            {
                if (key[i % key.Length] >= message.Length % key.Length)
                {
                    transformMessage += ' ';
                }
                else
                {
                    transformMessage += message[j++];
                }
            }
            return transformMessage;
        }
        public static String encryptB(String message, int[] key)
        {
            String encrypted = "";

            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; key[i] + j * key.Length < message.Length; j++)
                {
                    encrypted += message[key[i] + j * key.Length];
                }
            }
            return encrypted;
        }
        public static String descryptB(String message, int[] key)
        {
            String descrypted = "";
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < message.Length / key.Length; j++)
                {
                    descrypted += message[key[j] * (message.Length / key.Length) + i];
                }
            }
            return descrypted;
        }
        public static String encryptC(String message, int[] key)
        {
            String encrypted = "";

            for (int i = 0, length = 0; encrypted.Length < message.Length; i=(i+1)%key.Length)
            {
                length += key[i] + 1;
                for (int n = length + key[i], j = i; n < message.Length;n+=key[j]+1,j= (j+1)%key.Length)
                {
                    if(key[i]<key[j]){
                        encrypted+=message[n];
                    }
                }
            }
            return encrypted;
        }
        public static String descryptC(String message, int[] key)
        {
            String descrypted = "";
            Dictionary<int,char> descryptedMap = new Dictionary<int,char>();

            for (int i = 0, length = 0, l=0; l < message.Length; i=(i+1)%key.Length)
            {
                length += key[i] + 1;
                for (int n = length + key[i], j = i; n < message.Length;n+=key[j]+1,j=(j+1)%key.Length)
                {
                    if(key[i]<key[j]){
                        descryptedMap[n] = message[l++];
                    }
                }
            }
            for(int i = 0;i<message.Length;i++){
                descrypted += descryptedMap[i];
            }
            return descrypted;
        }
    }
}
