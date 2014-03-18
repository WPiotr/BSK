using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK1
{
    public class VigenereEncrypt
    {
        public static String encrypt(String message, String key)
        {
            String encrypted = "";
            for (int i = 0; i < message.Length; i++)
            {
                encrypted += (char)(((message[i] - 'A' + key[i % key.Length] - 'A') % 26) + 'A');
            }
            return encrypted;
        }

        public static String descrypt(String message, String key)
        {
            String descrypted = "";
            for (int i = 0; i < message.Length; i++)
            {
                descrypted += (char)(modul((message[i] - 'A' - key[i % key.Length] + 'A') % 26,26) + 'A');
            }
            return descrypted;
        }
        private static int modul(int x, int n)
        {
            if(x>=0)
                return x;
            return n + x;
        }

    }
}
