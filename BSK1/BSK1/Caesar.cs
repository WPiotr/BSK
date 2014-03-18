using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public static class Caesar
    {


        public static String Encrypt(String text, int k0, int k1)
        {
            String result = "";
            char[] alphabet = new char[26];
            for (int i = 0; i < 26; i++)
            {
                alphabet[i] = (char)(i + 97);
            }
            text = text.ToLower();

            int newIndex = 0;

            foreach (char c in text)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (c == alphabet[i])
                    {
                        newIndex = (i * k1 + k0) % 26;
                        result += alphabet[newIndex];
                        break;
                    }

                }
                if (c == (char)32)
                {
                    result += " ";
                }
            }
            


            return result;
        }
        public static String Decrypt(String text, int k0, int k1)
        {
            String result = "";
            char[] alphabet = new char[26];
            for (int i = 1; i < 26; i++)
            {
                alphabet[i] = (char)(i + 96);
            }
            // https://www.wolframalpha.com/input/?i=%CF%86%2826%29 φ(26) - 1 = 11 
            Double kk = (int)Math.Pow(k1, 11) % 26;
            // 10 bo za pierwszą iteracją jest juz 2 potega
            int newIndex = 0;
            foreach (char c in text)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (c == alphabet[i])
                    {
                        
                        //newIndex = ((i - k) / k1)%26;

                        newIndex = (int)(((i + (26 - k0)) * kk) % 26);

                        result += alphabet[newIndex];
                        break;
                    }

                }
                if (c == (char)32)
                {
                    result += " ";
                }
            }

            return result;
        }
    }
}
