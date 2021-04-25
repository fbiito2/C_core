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
using System.Windows.Shapes;

using System.Data.Entity;

namespace Mod03_1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //建立Grid時自動幫你建好
            System.Windows.Data.CollectionViewSource storeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("storeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // storeViewSource.Source = [generic data source]
            var ctx = new pubsEntities();
            //DbSet<store> s = ctx.stores;  
            storeViewSource.Source = ctx.stores.ToList();
        }
    }
}
