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

namespace Mod05_1
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

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtName.Text + "你好呀!");
        }

        private void preferColorPanel_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = e.Source as RadioButton;
            string colorName = rb.Content.ToString();
            if (colorName == "紅")
            {
                this.Background = new SolidColorBrush(Colors.Red);
            }
            else if (colorName == "黃")
            {
                this.Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                this.Background = new SolidColorBrush(Colors.White);
            }


        }
    }
}
