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
using System.Security.Cryptography;
using System.IO;


namespace Mod08_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Byte[] key;
        Byte[] arEncrypted;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            textBox1.Text = BitConverter.ToString(des.Key);
            key = des.Key;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //加密是用公鑰加密私鑰解密
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            arEncrypted = RSA.Encrypt(key, false); //加密(明文,fOAPE填補模式，設false即可)  
            textBox2.Text = BitConverter.ToString(arEncrypted); //變成人看得懂得字而已
            Byte[] cspBlob = RSA.ExportCspBlob(true);  //是否要匯出公私鑰 false是匯出私鑰
            File.WriteAllBytes("key.snk", cspBlob);  //公鑰與私鑰存成key.snk檔
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Byte[] cspBlob = File.ReadAllBytes("key.snk");  //讀取公鑰與私鑰存成的key.snk檔
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportCspBlob(cspBlob);  //把key放入準備解密

            Byte[] arDecrypted = RSA.Decrypt(arEncrypted, false);  //解密(密文,fOAPE填補模式，設false即可)
            textBox3.Text = BitConverter.ToString(arDecrypted);  //因為是二進位陣列，再轉成人懂得
        }
    }
}
