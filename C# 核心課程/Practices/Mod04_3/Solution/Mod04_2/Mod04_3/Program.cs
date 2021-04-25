using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mod04_3
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50535/api/Players/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("取得ID=2 的玩家：");
            HttpResponseMessage resp = await client.GetAsync("2");
            if (resp.IsSuccessStatusCode)
            {
                Player play = await resp.Content.ReadAsAsync<Player>();
                Console.WriteLine("{0}, {1}", play.ID, play.Name);
            }
            Console.WriteLine("取得所有玩家：");
            resp = await client.GetAsync("");
            if (resp.IsSuccessStatusCode)
            {
                Player[] players = await resp.Content.ReadAsAsync<Player[]>();
                foreach (var play in players)
                {
                    Console.WriteLine("{0}, {1}", play.ID, play.Name);

                }
            }
            Console.ReadLine();
        }

        
    }
    public class Player
    {
        public int ID { get; set; }

        public string Name { get; set; }

    }
}
