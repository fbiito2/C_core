using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
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

namespace Mod03_1 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cn = new EntityConnection();
            cn.ConnectionString = "Name=pubsEntities";
            var cmd = cn.CreateCommand();
            cmd.CommandText = "select value s from pubsEntities.stores as s";
            cn.Open();
            var dr = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);

            while (dr.Read())
            {
                test.Items.Add(dr[0]);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ctx = new pubsEntities();
            //var q=(from s in ctx.store
            //       select nes{ })
        }
    }
}
