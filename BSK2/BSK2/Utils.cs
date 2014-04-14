using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BSK2
{
    public partial class Utils
    {
        private static Key key;

        public static string Encrypt(String inputString, String key)
        {
            if (Utils.key == null && Utils.key.key.CompareTo(key) == 0)
            {
                makeKey(key);
            }
            BitArray encrypted_message = makeMessage(inputString);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encrypted_message.Length / 4; i++)
            {
                Decimal decimalValue = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (encrypted_message[i * 4 + j])
                    {
                        decimalValue += 1;
                    }
                    decimalValue *= 2;
                }
                decimalValue /= 2;
                sb.Append(decimalValue.ToString("X"));
            }

            // foreach (Boolean bit in encrypted_message)
            // {
            //    if (bit)
            //        sb.Append(String.Format("%01x", 0x01));
            //    else
            //        sb.Append(String.Format("%01x", 0x01));
            // }
            return sb.ToString();
        }
        public static string Decrypt(String inputString, String key)
        {
            return null;
        }
        
        
        public static BitArray Encrypt(BitArray Input, BitArray key) {
            return null;
        }

        public static BitArray Decrypt(BitArray Input, BitArray key) {
            return null;
        }

        private static void makeKey(string key)
        {
            Utils.key = new Key(key);
            Utils.key.initialPermutation();
            Utils.key.splitting();
            Utils.key.shifts();
            Utils.key.finalPermutation();
        }
        private static BitArray makeMessage(string message_hexa)
        {
            Message message = new Message(message_hexa, 0);
            message.initialPermutation();
            message.splitting();

            Iteration iteration = new Iteration(message.msg_left_side, message.msg_right_side);
            Iteration.setKeys(key.keys);
            for (int i = 1; i <= 16; i++)
            {
                Utils.oneIteration(iteration, i);
            }
            message.reverseConnecting(iteration.leftSide[16], iteration.rightSide[16]);
            message.finalPermutation();
            return message.bitMsg;
        }
        private static void oneIteration(Iteration iteration, int counter)
        {
            iteration.ePermutation(counter);
            iteration.xorWithKey(counter);
            iteration.sBoxing(counter);
            iteration.pPermutation(counter);
            iteration.afterIteration(counter);
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
    }

}
