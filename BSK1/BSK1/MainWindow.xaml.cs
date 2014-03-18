using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSK1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Encrypt1(object sender, RoutedEventArgs e)
        {
            if (key1.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                result.Text = Utils.RailFenceEncrypt(int.Parse(key1.Text), input.Text);
            }
        }

        private void Decryption1(object sender, RoutedEventArgs e)
        {
            if (key1.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                result.Text = Utils.RailFenceDecrypt(int.Parse(key1.Text), input.Text);
            }
        }

        private void Encrypt2(object sender, RoutedEventArgs e)
        {
            if (key2.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                int[] key = makeKey(key2.Text);

                result.Text = SwitchingMatrix.encrypt(input.Text, key);
            }
        }
        private int[] makeKey(String key)
        {
            int[] newKey = new int[key.Length];

            for (int i = 0, globalMin = 0; i < key.Length; i++)
            {
                int minIndex = globalMin;
                for (int j = 0; j < key2.Text.Length; j++)
                {
                    if (key[j] < key[globalMin] && key[j] < key[minIndex])
                    {
                        minIndex = j;
                    }
                }
                newKey[minIndex] = i;
            }
            return newKey;
        }

        private void Decryption2(object sender, RoutedEventArgs e)
        {
            if (key2.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                int[] key = new int[key2.Text.Length];
                for (int i = 0; i < key.Length; i++)
                {
                    key[i] = key2.Text[i] - 'A';
                }
                result.Text = SwitchingMatrix.encrypt(SwitchingMatrix.transformMessage(input.Text, key), SwitchingMatrix.transformKey(key));
            }

        }

        private void Encrypt3(object sender, RoutedEventArgs e)
        {
            if (key1.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
            }

        }

        private void Decryption3(object sender, RoutedEventArgs e)
        {
            if (key1.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
            }

        }

        private void Encrypt4(object sender, RoutedEventArgs e)
        {
            if (key41.Text == "" || key42.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                result.Text = Caesar.Encrypt(input.Text, int.Parse(key41.Text), int.Parse(key42.Text));
            }

        }

        private void Decryption4(object sender, RoutedEventArgs e)
        {
            if (key41.Text == "" || key42.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                result.Text = Caesar.Decrypt(input.Text,int.Parse(key41.Text),int.Parse(key42.Text));
            }

        }

        private void Encrypt5(object sender, RoutedEventArgs e)
        {

        }

        private void Decryption5(object sender, RoutedEventArgs e)
        {

        }
    }
}
