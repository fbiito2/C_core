using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication1 {
  class Program {
    static string serviceUri = "http://localhost:10999/Service1.svc/";
    static void Main( string[] args ) {
      //GetData();
      GetPlayer();
    }

    private static void GetData( ) {
      var request = WebRequest.Create(serviceUri + "GetData?value=10") as HttpWebRequest;

      var response = request.GetResponse();

      var resultStream = response.GetResponseStream();
      var resultBuffer = new byte[1024];
      var length = 1024;
      var result = new StringBuilder();
      while ( length == 1024 ) {
        length = resultStream.Read(resultBuffer, 0, 1024);
        string resultString = System.Text.Encoding.UTF8.GetString(resultBuffer, 0, length);
        result.Append(resultString);
      }

      Console.WriteLine(result.ToString());
    }

    private static void GetPlayer( ) {
      var request = HttpWebRequest.Create(serviceUri + "Player?id=101") as HttpWebRequest;
      var response = request.GetResponse();
      var resultStream = response.GetResponseStream();
      DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
      var player = json.ReadObject(resultStream) as Player;
      if ( player != null )
        Console.WriteLine("Play's ID={0}, Name={1}", player.ID, player.Name);
    }
  }

  public class Player {
    public int ID { get; set; }
    public string Name { get; set; }
  }
}
