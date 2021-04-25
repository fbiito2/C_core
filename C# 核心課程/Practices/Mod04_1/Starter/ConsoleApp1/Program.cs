using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string serviceUrl = "http://localhost:10999/Service1.svc";
        static void Main(string[] args)
        {
            GetData();
        }

        private static void GetData()
        {
            var request = WebRequest.Create(serviceUrl + "GetData?value=10") as HttpWebRequest;

            var response = request.GetResponse().GetResponseStream();
          
            StreamReader sr = new StreamReader(response);

            Console.WriteLine(sr);
        }
    }
}
