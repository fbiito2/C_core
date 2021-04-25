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


namespace Mod08_2 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    Byte[] key;
    Byte[] arEncrypted;

    public MainWindow( ) {
      InitializeComponent();
    }

    private void button1_Click( object sender, RoutedEventArgs e ) {
      DESCryptoServiceProvider des = new DESCryptoServiceProvider();
      textBox1.Text = BitConverter.ToString(des.Key);
      key = des.Key;
    }

    private void button2_Click( object sender, RoutedEventArgs e ) {
      RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

      arEncrypted = RSA.Encrypt(key, false);
      textBox2.Text = BitConverter.ToString(arEncrypted);
      Byte[] cspBlob = RSA.ExportCspBlob(true);
      File.WriteAllBytes("key.snk", cspBlob);
    }

    private void button3_Click( object sender, RoutedEventArgs e ) {
      Byte[] cspBlob = File.ReadAllBytes("key.snk");
      RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
      RSA.ImportCspBlob(cspBlob);

      Byte[] arDecrypted = RSA.Decrypt(arEncrypted, false);
      textBox3.Text = BitConverter.ToString(arDecrypted);
    }
  }
}
