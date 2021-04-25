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
using System.Runtime.Serialization.Json;
using System.IO;

namespace Mod02_1
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

        private void btnSerial_Click(object sender, RoutedEventArgs e)
        {
            Employee obj = new Employee();
            obj.Name = "Mary";
            obj.Level = 3;
            obj.Salary = 30000;

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(obj.GetType());
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.txt", FileMode.Create);
            formatter.WriteObject(fs, obj);
            fs.Close();
            MessageBox.Show("序列化完成!");


        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Employee));
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.txt", FileMode.Open);
            Employee obj = (Employee)formatter.ReadObject(fs);
            fs.Close();
            lblName.Content = obj.Name;
            lblLevel.Content = obj.Level;


        }
    }
}
