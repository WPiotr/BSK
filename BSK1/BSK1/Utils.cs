using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace :P
namespace BSK1
{
    public class Utils
    {
        // Szyfrowanie RailFence
        public static String RailFenceEncrypt(int k, String text)
        {
            return RailFenceEncryptUp(k, text) + RailFenceEncryptMid(k, text) + RailFenceEncryptDown(k, text);
            
        }

        private static String RailFenceEncryptUp(int k, String text)
        {
            String result = "";
            for (int i = 0; i * ((2 * k) - 2) < text.Length; i++)
            {
                result += text[i * ((2 * k) - 2)];
            }
            return result;
        }

        private static String RailFenceEncryptDown(int k, String text)
        {
            String result = "";
            for (int i = 0; i * ((2 * k) - 2) + k - 1 < text.Length; i++)
            {
                result += text[i * ((2 * k) - 2) + k - 1];
            }
            return result;
        }

        private static String RailFenceEncryptMid(int k, String text)
        {
            String result = "";
            for (int i = 1; i <= k - 2; i++)
            {
                for (int j = 0; j * ((2 * k) - 2) < text.Length; j++)
                {
                    int index = j * ((2 * k) - 2);
                    if (index - i > 0)
                    {
                        result += text[index - i];
                    }
                    if (index + i < text.Length)
                    {
                        result += text[index + i];
                    }
                }
            }
            return result;
        }
        // Deszyfrowanie RailFence

        public static String RailFenceDecrypt(int k, String text) {
            Char[] result = new Char[text.Length];
            int nextIndex = 0;
            // Znalezienie górnych liter
            for (int i = 0; i * (2 * k - 2) < text.Length; i++) {
                result[i * (2 * k - 2)] = text[nextIndex];
                nextIndex++;
            }
            
            //Znalezienie środkowych liter
            for (int i = 1; i <= k - 2; i++) {
                for (int j = 0; j * ((2 * k) - 2) < text.Length; j++) {
                    int index = j * ((2 * k) - 2);
                    if (index - i > 0) {
                        result[index - i] = text[nextIndex];
                        nextIndex++;
                    }
                    if (index + i < text.Length) {
                        result[index + i] = text[nextIndex];
                        nextIndex++;
                    }
                }
            }

            //znalezienie dolnych liter
            for (int i = 0; i * (2 * k - 2)+k-1 < text.Length; i++)
            {
                result[i * (2 * k - 2)+k-1] = text[nextIndex];
                nextIndex++;
            }


            return new String(result);
        }

     
    }
}
