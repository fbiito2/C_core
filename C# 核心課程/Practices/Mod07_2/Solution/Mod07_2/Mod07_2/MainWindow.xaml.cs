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
using System.Diagnostics;

namespace Mod07_2 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    private void button_Click( object sender, RoutedEventArgs e ) {
      string xlsFile = @"c:\temp\mytext.xlsx";
      string outpdf = @"c:\temp\mytext.pdf";
      ManagedExcel excel = new ManagedExcel(xlsFile);
      excel.ExportToPDF(outpdf);
      excel.Dispose();
      Process.Start(outpdf);
    }

    private void button1_Click( object sender, RoutedEventArgs e ) {
      string xlsFile = @"c:\temp\mytext.xlsx";
      string outpdf = @"c:\temp\mytext.pdf";
      using ( ManagedExcel excel = new ManagedExcel(xlsFile) ) {
        excel.ExportToPDF(outpdf);
      }
      //Process.Start(outpdf);  //註解掉就不會開啟給你看
    }
  }
}
