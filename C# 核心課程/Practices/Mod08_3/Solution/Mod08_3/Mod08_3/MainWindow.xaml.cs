using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Mod08_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Byte[] Hash1;
        Byte[] k;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Byte[] Message = Encoding.Unicode.GetBytes(textBox1.Text);
            //Encoding.這裡可以選編碼模式UTF-8中文可用

            HMACSHA1 hma = new HMACSHA1();
            k = hma.Key;
            Byte[] HashValue = hma.ComputeHash(Message);
            Hash1 = HashValue;

            textBox2.Text = BitConverter.ToString(HashValue);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Byte[] Message = Encoding.Unicode.GetBytes(textBox3.Text);
            HMACSHA1 hma = new HMACSHA1(k);
            Byte[] Hash2;

            Hash2 = hma.ComputeHash(Message);

            bool bSame = true;
            for (int i = 0; i < Hash1.Length; i++)
            {
                if (Hash1[i] != Hash2[i])
                {
                    bSame = false;
                    break;
                }
            }


            if (bSame)
                textBox4.Text = "比對正確";
            else
                textBox4.Text = "比對不正確";
        }
    }
}
