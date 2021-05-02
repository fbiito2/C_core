using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Mod06_3_1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var room = new[] {
                new  { ID = 101, Name = "Room A" , Floor="12" },
                new  { ID = 102, Name = "Room B"  , Floor="12"},
                new  { ID = 103, Name = "Room C"  , Floor="14"},
                new  { ID = 104, Name = "Room D" , Floor="14" }
            };

            //範例用隨機停止的假定是處理時間長，所以印出的是不照順序的，誰先做完誰先印，這是平行處理
            Random rnd = new Random();
            Parallel.ForEach(room, item =>
            {
                Thread.Sleep(rnd.Next(500));
                //Console.WriteLine("{0} - {1} - {2}", item.ID, item.Name, item.Floor);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    mylistbox.Items.Add(string.Format("{0}-{1}-{2}",
                        item.ID, item.Name, item.Floor)
                        );
                }), null);

                
            });

        }
    }
}
