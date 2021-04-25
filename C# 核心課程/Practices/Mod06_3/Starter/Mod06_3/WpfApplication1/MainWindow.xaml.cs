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
  }

  public class Player {
    public int ID { get; set; }
    public string Name { get; set; }
  }
}
