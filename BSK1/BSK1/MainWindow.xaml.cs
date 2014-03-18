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
                String key = key2.Text;
                String message = input.Text;
                result.Text = SwitchingMatrix.encrypt(message, SwitchingMatrix.makeKeyFromLetter(key));
            }
        }

        private void Decryption2(object sender, RoutedEventArgs e)
        {
            if (key2.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                String key = key2.Text;
                String encrypted = input.Text;

                int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
                result.Text = SwitchingMatrix.encrypt(SwitchingMatrix.transformMessageForEncrypt1(encrypted, key_table), SwitchingMatrix.transformKey(key_table));
            }

        }

        private void Encrypt3(object sender, RoutedEventArgs e)
        {
            if (key3.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                String key = key3.Text;
                String message = input.Text;

                int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
                result.Text = SwitchingMatrix.encryptB(message, SwitchingMatrix.transformKey(key_table));
            }

        }

        private void Decryption3(object sender, RoutedEventArgs e)
        {
            if (key3.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                String key = key3.Text;
                String encrypted = input.Text;

                int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
                result.Text = SwitchingMatrix.descryptB(SwitchingMatrix.transformMessageForDescrypt2(encrypted, key_table), key_table);
            }

        }

        private void Encrypt3b(object sender, RoutedEventArgs e)
        {
            if (key3b.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                String key = key3b.Text;
                String message = input.Text;

                int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
                result.Text =  SwitchingMatrix.encryptC(message, SwitchingMatrix.transformKey(key_table));


            }

        }

        private void Decryption3b(object sender, RoutedEventArgs e)
        {
            if (key3b.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                
                String key = key3b.Text;
                String encrypted = input.Text;

                int[] key_table = SwitchingMatrix.makeKeyFromLetter(key);
                result.Text = SwitchingMatrix.descryptC(encrypted, SwitchingMatrix.transformKey(key_table));
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

            if (key5.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {

                String key = key5.Text;
                String message = input.Text;

                result.Text = VigenereEncrypt.encrypt(message, key);
            }
        }

        private void Decryption5(object sender, RoutedEventArgs e)
        {

            if (key5.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {

                String key = key5.Text;
                String message = input.Text;

                result.Text = VigenereEncrypt.descrypt(message, key);
            }
        }
    }
}
