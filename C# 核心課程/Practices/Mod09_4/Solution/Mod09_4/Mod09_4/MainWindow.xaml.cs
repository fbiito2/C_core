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

namespace Mod09_4 {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow( ) {
      InitializeComponent();
    }

    void ApplyForeColor( ) {
      foreach ( Control ctl in grid1.Children ) {
        Color c = Properties.Settings.Default.ForeColor;
        ctl.Foreground = new SolidColorBrush(c);
      }
    }

    private void Window_Loaded( object sender, RoutedEventArgs e ) {
      depTextBox.Text = Properties.Settings.Default.Department;
      ownerTextBox.Text = Properties.Settings.Default.Owner;
      fontColor.Text = Properties.Settings.Default.ForeColor.ToString();
      ApplyForeColor();
    }

    private void button_Click( object sender, RoutedEventArgs e ) {
      Properties.Settings.Default.Owner = ownerTextBox.Text;
      Properties.Settings.Default.ForeColor =
          (System.Windows.Media.Color)
          ColorConverter.ConvertFromString(fontColor.Text);
      Properties.Settings.Default.Save();
      ApplyForeColor();
    }
  }
}
