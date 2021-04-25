using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod01_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;

            foreach (string file in Directory.GetFiles(path))
            {
               listBox1.Items.Add(file);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            foreach (string file in Directory.GetFiles(path, "test*.txt"))
            {
                File.Delete(file);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Copy(textBox1.Text, textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(textBox1.Text);
            if (fi.Exists)
            {
                string oldName = fi.FullName;
                fi.MoveTo(textBox2.Text);
                MessageBox.Show(oldName + "->" + fi.FullName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(textBox1.Text);

            MessageBox.Show(fi.FullName);

            MessageBox.Show(Path.GetExtension(fi.FullName));

            MessageBox.Show(Path.ChangeExtension(fi.FullName, "jpg"));
        }
    }
}
