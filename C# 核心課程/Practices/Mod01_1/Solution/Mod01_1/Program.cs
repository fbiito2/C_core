using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Mod01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Environment.CurrentDirectory;  //在程式執行的位置

            Console.WriteLine($"目前的資料夾為: {currentDir}");

            string newDir = Path.Combine($@"{currentDir}\txt");

            if (!Directory.Exists(newDir))
            {
                DirectoryInfo dinfo = Directory.CreateDirectory(newDir);
                Console.WriteLine("建立資料夾: " + dinfo.Name);
            }

            Console.WriteLine("目前的資料夾為:" + newDir);
            string filePath = Path.Combine(newDir, "myCourses.txt");

            if (File.Exists(filePath))
            {
                Console.WriteLine("檔案已存在，檔案將被覆蓋!");
            }

            string[] myCourses = {
                  "Visual Basic",
                  "Visual C#",
                  "ASP.NET",
                  "jQuery",
                  "jQuery Mobile"
                  };

            File.WriteAllLines(filePath, myCourses);  //這可以直接使用字串陣列

            foreach (string course in File.ReadAllLines(filePath))
            {
                Console.WriteLine("課程 : {0}", course);
            }
            Console.ReadLine();

        }
    }
}
