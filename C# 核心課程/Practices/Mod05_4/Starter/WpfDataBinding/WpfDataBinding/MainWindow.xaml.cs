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

namespace WpfDataBinding {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    private void Window_Loaded( object sender, RoutedEventArgs e ) {
      //LayoutRoot.DataContext = new Player {
      //  ID = 101,
      //  Name = "Mary",
      //  PreferColor = "Yellow"
      //};
      //System.Windows.Data.CollectionViewSource playersViewSource = ( (System.Windows.Data.CollectionViewSource) ( this.FindResource("playersViewSource") ) );
      // Load data by setting the CollectionViewSource.Source property:
      // playersViewSource.Source = [generic data source]
      Players playerList = new Players {
                new Player {ID=101, Name="Mary", PreferColor="Yellow"},
                new Player {ID=102, Name="Jenny", PreferColor="Red"},
                new Player {ID=103, Name="Lisa", PreferColor="White"}
            };

      System.Windows.Data.CollectionViewSource playersViewSource =
          ( (System.Windows.Data.CollectionViewSource) ( this.FindResource("playersViewSource") ) );
      // Load data by setting the CollectionViewSource.Source property:
      playersViewSource.Source = playerList;
    }
  }
}
