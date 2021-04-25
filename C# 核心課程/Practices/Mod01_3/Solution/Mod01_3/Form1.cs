using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Mod01_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            using (FileStream fs =
            new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("big5")))
                {
                    sw.Write(textBox2.Text);
                }
                //上面就可以省下.close();
                //StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("big5"));
                // sw.Write(textBox2.Text);
                // sw.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            if (!File.Exists(fileName))
            {
                MessageBox.Show("檔案不存在");
                return;
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open,
            FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                textBox2.Text = sr.ReadToEnd();
                sr.Close();
            }


        }
    }
}
