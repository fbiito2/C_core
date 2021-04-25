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

using System.Data;
using System.Data.Entity.Core.EntityClient;

namespace Mod03_1 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    private void button_Click( object sender, RoutedEventArgs e ) {
      var cn = new EntityConnection();
      cn.ConnectionString = "Name=pubsEntities";
      var cmd = cn.CreateCommand();
      cmd.CommandText = "Select VALUE s from pubsEntities.stores as s ";
      cn.Open();
      var dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
      while ( dr.Read() ) {
        listbox1.Items.Add(dr[0].ToString() + "\t" + dr[1].ToString());
      }
    }

    private void button1_Click( object sender, RoutedEventArgs e ) {
      var ctx = new pubsEntities();
      var allStores = ctx.stores;
      foreach ( var s in allStores ) {
        listbox1.Items.Add(s.stor_id.ToString() + "\t" + s.stor_name);
      }
    }

    private void button2_Click( object sender, RoutedEventArgs e ) {
      var ctx = new pubsEntities();
      var newStore = new store();
      newStore.stor_id = "9998";
      newStore.stor_name = "UUU";
      newStore.state = "WA";
      newStore.stor_address = "FuSing N.Rd No. 99";
      newStore.zip = "105";
      ctx.stores.Add(newStore);
      ctx.SaveChanges();
    }

    private void button3_Click( object sender, RoutedEventArgs e ) {
      var ctx = new pubsEntities();
      var storeToUpdate = ( from s in ctx.stores
                            where s.stor_id == "9998"
                            select s ).First();
      storeToUpdate.stor_name = "UUU and Systex";
      ctx.SaveChanges();
    }

    private void button4_Click( object sender, RoutedEventArgs e ) {
      var ctx = new pubsEntities();
      var storeToDelete = ( from s in ctx.stores
                            where s.stor_id == "9998"
                            select s ).First();
      ctx.stores.Remove(storeToDelete);
      ctx.SaveChanges();
    }
  }
}
