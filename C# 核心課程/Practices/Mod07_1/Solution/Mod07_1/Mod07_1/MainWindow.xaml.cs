using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Mod07_1 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    private void button_Click( object sender, RoutedEventArgs e ) {
      // 建立動態物件
      Type excelType = Type.GetTypeFromProgID("Excel.Application");
      dynamic excelApp = Activator.CreateInstance(excelType);
      excelApp.Visible = true;

      string xlsFile = @"c:\temp\mytext.xlsx";
      string outPDF = @"c:\temp\mytext.pdf";
      // 使用動態物件的成員，Open 方法可以開啟Excel 的Workbook，並傳回Workbook 物件
      dynamic workbook = excelApp.Workbooks.Open(xlsFile);
      // 使用 workbook 物件的 ExportAsFixedFormat方法可以匯出PDF或XPS 文件
      // 參數1: 0 -> PDF, 1-> XPS
      // 參數2: 輸出的檔名，其他參數可以省略不傳
      workbook.ExportAsFixedFormat(0, outPDF);
      // 顯示 Excel 應用程式
      excelApp.Visible = true;
      // 開啟輸出的文件
      Process.Start(outPDF);
    }
  }
}
