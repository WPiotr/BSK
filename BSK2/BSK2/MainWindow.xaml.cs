

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

        

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            
                //Utils.EncryptWithAddZero("test3.bin", "output1.bin", "133457799BBCDFF1");
                string s = s1.Text.ToUpper();

                Utils.EncryptWithAddZero(input.Text, "output1.bin", s1.Text.ToUpper());
                Utils.Decrypt("output1.bin", "output2.bin", s2.Text.ToUpper());
                Utils.Encrypt("output2.bin", "output3.bin", s1.Text.ToUpper());

                //Utils.EncryptWithAddZero("ala.bin", "output1.bin", "3B3898371520f75");
                //Utils.Decrypt("output1.bin", "output2.bin", "922fb510c71f436e");
                //Utils.Encrypt("output2.bin", "output3.bin", "3b3898371520f75e");

            
                //Utils.EncryptWithAddZero(input.Text, "output1.bin", s1.Text);
                //Utils.Decrypt("output1.bin", "output2.bin", s2.Text);
                //Utils.Encrypt("output2.bin", "output3.bin", s1.Text);
            
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            
            //Utils.DecryptWithDeletingZero("output1.bin", "result.bin", "133457799BBCDFF1");


            //Utils.Decrypt("output3.bin", "output4.bin", "3b3898371520f75e");
            //Utils.Encrypt("output4.bin", "output5.bin", "922fb510c71f436e");
            //Utils.DecryptWithDeletingZero("output5.bin", "result.bin", "3b3898371520f75e");



            Utils.Decrypt("output3.bin", "output4.bin", s1.Text.ToUpper());
            Utils.Encrypt("output4.bin", "output5.bin", s2.Text.ToUpper());
            Utils.DecryptWithDeletingZero("output5.bin", "result.bin", s1.Text.ToUpper());
        }
    }
}
