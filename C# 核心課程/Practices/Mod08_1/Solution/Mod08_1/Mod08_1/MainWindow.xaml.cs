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


namespace Mod08_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Byte[] key;
        Byte[] iv;
        Byte[] cipherMessage;
        string pwd = "Pa$$w0rd";
        string salt = "S@lt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var alogorithm = new AesManaged();
            //給明文密碼與sal生出key and iv
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(pwd, Encoding.Unicode.GetBytes(salt));
            key = rfc.GetBytes(alogorithm.KeySize / 8);
            iv = rfc.GetBytes(alogorithm.BlockSize / 8);

            //也可以不用key and iv的方法
            ICryptoTransform objCrytpo = alogorithm.CreateEncryptor(key, iv);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Write);
            //
            StreamWriter sw = new StreamWriter(cs);
            sw.WriteLine(txt.Text);
            sw.Flush();
            cs.FlushFinalBlock();

            ms.Position = 0;
            cipherMessage = new Byte[ms.Length];
            ms.Read(cipherMessage, 0, (int)ms.Length);
            tb1.Text = BitConverter.ToString(cipherMessage);
            cs.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var alogorithm = new AesManaged();

            ICryptoTransform objCrytpo = alogorithm.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(cipherMessage);
            CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cs);
            tb2.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}
