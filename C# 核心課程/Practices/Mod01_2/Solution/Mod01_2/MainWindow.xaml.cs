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
using System.IO;
namespace Mod01_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();  //這樣在執行時會有兩個執行續(1.視窗執行的主執行續  2.watcher事件時會再開另一個工作執行續)
            watcher.Path = @"c:\temp";
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.*";
            watcher.NotifyFilter = NotifyFilters.LastAccess
              | NotifyFilters.LastWrite | NotifyFilters.FileName
              | NotifyFilters.Size | NotifyFilters.DirectoryName;
            watcher.Created += Watcher_Changed;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            watcher.EnableRaisingEvents = true;


        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string s = String.Format("{0}: {1}-{2}",
                e.ChangeType, e.OldFullPath, e.FullPath);
            //this.Dispatcher.Invoke(() => { UpdateUI(s); });   //因為工作執行續不能直接對主執行續做事，所以必須用this.dispatcher.invoke( ()=>{ 要做的事  } );
            this.Dispatcher.Invoke(()=> { listBox1.Items.Add(s); });
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string s = String.Format("{0}:{1}", e.ChangeType, e.FullPath);
            //this.Dispatcher.Invoke(() => { UpdateUI(s); });
            this.Dispatcher.Invoke(() => { listBox1.Items.Add(s); });

        }

      
        //這段可註解
        //void UpdateUI(string s)
        //{
        //    listBox1.Items.Add(s);
        //}

    }
}
