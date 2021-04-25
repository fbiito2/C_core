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
using System.Threading;

namespace WpfApplication1 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    private void Window_Loaded( object sender, RoutedEventArgs e ) {
      // 建立匿名集合物件
      var room = new[] {
        new  { ID = 101, Name = "Room A" , Floor="12" },
        new  { ID = 102, Name = "Room B"  , Floor="12"},
        new  { ID = 103, Name = "Room C"  , Floor="14"},
        new  { ID = 104, Name = "Room D" , Floor="14" }
    };

      // 建立隨機存取物件
      Random rnd = new Random();
      // 使用平行處理，
      // ForEach 傳入 要被處理的集合物件及處理單一項目的程序使用Lambda
      Parallel.ForEach(room, item => {
        // 讓這個執行緒暫停半秒鐘以內< 500 毫秒
        Thread.Sleep(rnd.Next(500));
        // 切換到 UI 的執行緒上
        this.Dispatcher.BeginInvoke(new Action(( ) => {
          // 顯示於畫面上
          listbox1.Items.Add(
                        string.Format("{0} - {1} - {2}",
                        item.ID, item.Name, item.Floor)
                    );
        }), null);

      });
    }
  }
}
