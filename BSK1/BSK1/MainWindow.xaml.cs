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

        private void Decryption1(object sender, RoutedEventArgs e)
        {
            if (k.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else
            {
                result.Text = Utils.RailFenceDecrypt(int.Parse(k.Text), input.Text);
            }
        }

        private void Encrypt1(object sender, RoutedEventArgs e)
        {
            if (k.Text == "" || input.Text == "")
            {
                MessageBox.Show("Wprowadz poprawne dane !");
            }
            else 
            {
                result.Text = Utils.RailFenceEncrypt(int.Parse(k.Text), input.Text);
            }
        }

        private void Encrypt2(object sender, RoutedEventArgs e)
        {

        }

        private void Decryption2(object sender, RoutedEventArgs e)
        {

        }

        private void Encrypt3(object sender, RoutedEventArgs e)
        {

        }

        private void Decryption3(object sender, RoutedEventArgs e)
        {

        }

        private void Encrypt4(object sender, RoutedEventArgs e)
        {

        }

        private void Decryption4(object sender, RoutedEventArgs e)
        {

        }

        private void Encrypt5(object sender, RoutedEventArgs e)
        {

        }

        private void Decryption5(object sender, RoutedEventArgs e)
        {

        }
    }
}
