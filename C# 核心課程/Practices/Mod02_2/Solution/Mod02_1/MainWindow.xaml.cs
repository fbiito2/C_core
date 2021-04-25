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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
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
            //Employee obj = new Employee();
            Employee2 obj = new Employee2();
            obj.Name = "Mary";
            obj.Level = 3;
            obj.Salary = 30000;

            //BinaryFormatter formatter = new BinaryFormatter();
            ////FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.bin", FileMode.Create);
            //FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.txt", FileMode.Create);

            //------------------------------------------------------
            SoapFormatter formatter = new SoapFormatter();
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.xml", FileMode.Create);
            //------------------------------------------------------
            formatter.Serialize(fs, obj);
            fs.Close();
            MessageBox.Show("序列化完成!");

        }

        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            //BinaryFormatter formatter = new BinaryFormatter();
            ////FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.bin", FileMode.Open);
            //FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.txt", FileMode.Open);
            //-------------------------------------
            SoapFormatter formatter = new SoapFormatter();
            FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Employee.xml", FileMode.Open);

            //--------------------------------

            //Employee obj = ((Employee)(formatter.Deserialize(fs)));
            Employee2 obj = ((Employee2)(formatter.Deserialize(fs)));
            fs.Close();
            lblName.Content = obj.Name;
            lblLevel.Content = obj.Level;
            lblSalary.Content = obj.Salary;

        }
    }
}
