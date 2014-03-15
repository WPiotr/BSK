using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class Utils
    {

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
            for (int i = 0; i * ((2 * k) - 2 + k - 1) < text.Length; i++)
            {
                result += text[i * ((2 * k) - 2 + k - 1)];
            }
            return result;
        }

        private static String RailFenceEncryptMid(int k, String text)
        {
            String result = "";
            for (int i = 0; i < k - 2; i++)
            {
                for (int j = 0; j * ((2 * k) - 2) < text.Length; j++)
                {
                    int index = j * ((2 * k) - 2);
                    if (text[index - 1] > 0)
                    {
                        result += text[index - 1];
                    }
                    if (text[index + 1] < text.Length)
                    {
                        result += text[index + 1];
                    }
                }
            }
            return result;
        }


     
    }
}
