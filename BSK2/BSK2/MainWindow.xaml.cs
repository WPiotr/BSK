

namespace BSK2
{
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
    using Microsoft.Win32;
    using System.IO;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void File1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                input.Text = dlg.FileName;
            }
        }

        private void File2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                s1.Text = dlg.FileName;
            }

        }

        private void File3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                s2.Text = dlg.FileName;
            }

        }

        private void CheckBoxMsg(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckBox1.IsChecked)
            {
                msgButton.IsEnabled = true;
            }
            else
            {
                msgButton.IsEnabled = false;
            }

            //if ((bool)CheckBox2.IsChecked)
            //{
            //    buttonS1.IsEnabled = true;
            //    buttonS2.IsEnabled = true;
            //}
            //else
            //{
            //    buttonS1.IsEnabled = false;
            //    buttonS2.IsEnabled = false;
            //}
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckBox1.IsChecked)
            {
                FileStream fs = File.Create("Input_text.bin", 2048);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(input.Text);
                bw.Close();
                Utils.EncryptWithAddZero("Input_text.bin", "output1.bin", s1.Text);
                //Utils.Decrypt("output1.bin", "output2.bin", s2.Text);
                //Utils.Encrypt("output2.bin", "output3.bin", s1.Text);
            }
            else
            {
                Utils.EncryptWithAddZero(input.Text, "output1.bin", s1.Text);
                //Utils.Decrypt("output1.bin", "output2.bin", s2.Text);
                //Utils.Encrypt("output2.bin", "output3.bin", s1.Text);
            }
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
                //Utils.Decrypt("output3.bin", "output4.bin", s1.Text);
                //Utils.Encrypt("output4.bin", "output5.bin", s2.Text);
                Utils.DecryptWithDeletingZero("output1.bin", "result.bin", s1.Text);
        }
    }
}
