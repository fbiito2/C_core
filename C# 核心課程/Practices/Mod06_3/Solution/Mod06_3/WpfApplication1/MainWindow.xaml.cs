using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
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

namespace WpfApplication1 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }
    string serviceUri = "http://localhost:10999/Service1.svc/";


    private void btnSync_Click( object sender, RoutedEventArgs e ) {
      var request = HttpWebRequest.Create(serviceUri + "Player?id=101") as HttpWebRequest;

      var response = request.GetResponse();
      var resultStream = response.GetResponseStream();
      DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
      var player = json.ReadObject(resultStream) as Player;
      if ( player != null )
        listBox1.Items.Add(string.Format("同步Play's ID={0}, Name={1}", player.ID, player.Name));
    }

    private void btnAPM_Click( object sender, RoutedEventArgs e ) {
      // 建立HttpWebRequest 物件連接到 Service1.svc
      var request = HttpWebRequest.Create(serviceUri + "Player?id=101") as HttpWebRequest;

      // 使用APM 非同步的方法執行，
      // 並傳 AsyncCallback delegate 以處理取回的結果
      // 以下程序會在背景執行緒中執行
      request.BeginGetResponse(new AsyncCallback(( ar ) => {
        // 取得 request 物件
        var req = ar.AsyncState as HttpWebRequest;
        // 呼叫 EndGetResponse 已取得執行結果
        var response = req.EndGetResponse(ar);
        var resultStream = response.GetResponseStream();

        // 將取得的 stream 物件 使用 Json 反序列化的方式取得play 物件
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
        var player = json.ReadObject(resultStream) as Player;
        if ( player != null ) {
          // 切換到 UI 的執行緒
          Dispatcher.BeginInvoke(new Action(( ) => {
            // 將取得的結果呈現在 listBox 清單上
            listBox1.Items.Add(string.Format("Play's ID={0}, Name={1}", player.ID, player.Name));
            btnAPM.IsEnabled = true;
          }), null);
        }
      }), request);
      btnAPM.IsEnabled = false;
    }
  }

  public class Player {
    public int ID { get; set; }
    public string Name { get; set; }
  }
}
