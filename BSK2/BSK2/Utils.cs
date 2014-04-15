using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows;

namespace BSK2
{
    public class Utils
    {
        private static Key key;


        public static void Encrypt(string file_input, string file_output, string key1)
        {

            FileStream input;
            BinaryReader br;
            FileStream output;
            BinaryWriter bw;
            byte[] block;

            key = new Key(key1);
            Utils.key.makeKey();

            try
            {
                input = new FileStream(file_input, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(input);
                output = new FileStream(file_output, FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                while ((block = br.ReadBytes(8)).Length > 0)
                {
                    if (input.Position == input.Length)
                    {
                        byte[] lol = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            if (i < block.Length)
                            {
                                lol[i] = block[i];
                            }
                            else
                            {
                                lol[i] += (byte)0;
                            }
                        }
                        Int64 block_do_zapisu = 8 - block.Length;

                        BitArray encrypted_message = Utils.makeMessage(lol);
                        bw.Write(encrypted_message.ToByteArrayRev());
                        bw.Write(block_do_zapisu);
                    }
                    else
                    {
                        BitArray encrypted_message = Utils.makeMessage(block);
                        bw.Write(encrypted_message.ToByteArrayRev());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                input.Close();
                output.Close();
                br.Close();
                bw.Close();
            }
            finally
            {
                input.Close();
                output.Close();
                br.Close();
                bw.Close();
            }
        }
        public static BitArray makeMessage(string message_hexa)
        {
            Message message = new Message(message_hexa, 0);
            message.initialPermutation();
            message.splitting();

            Iteration iteration = new Iteration(message.msg_left_side, message.msg_right_side);
            Iteration.setKeys(Utils.key.keys);
            for (int i = 1; i <= 16; i++)
            {
                Utils.oneIteration(iteration, i);
            }
            message.reverseConnecting(iteration.leftSide[16], iteration.rightSide[16]);
            message.finalPermutation();
            return message.bitMsg;
        }
        public static BitArray makeMessage(byte[] bit_message)
        {
            Message message = new Message(bit_message);
            message.initialPermutation();
            message.splitting();

            Iteration iteration = new Iteration(message.msg_left_side, message.msg_right_side);
            Iteration.setKeys(Utils.key.keys);
            for (int i = 1; i <= 16; i++)
            {
                Utils.oneIteration(iteration, i);
            }
            message.reverseConnecting(iteration.leftSide[16], iteration.rightSide[16]);
            message.finalPermutation();
            return message.bitMsg;
        }
        public static void oneIteration(Iteration iteration, int counter)
        {
            iteration.ePermutation(counter);
            iteration.xorWithKey(counter);
            iteration.sBoxing(counter);
            iteration.pPermutation(counter);
            iteration.afterIteration(counter);
        }
        public string bitArrayToString(BitArray array)
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

    static class lol
    {

        public static byte[] ToByteArrayRev(this BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }
        public static bool IsBitSet(this byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
        public static BitArray ToBitArrayRev(this byte[] bytes)
        {
            BitArray output = new BitArray(bytes.Length * 8);
            //BitArray output = new BitArray(64);

            for (byte i = 0; i < bytes.Length; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    output[i * 8 + j] = bytes[i].IsBitSet(7 - j);
                }
            }

            return output;
        }
        public static void makeKey(this Key k)
        {
            k.initialPermutation();
            k.splitting();
            k.shifts();
            k.finalPermutation();
        }
    }
}