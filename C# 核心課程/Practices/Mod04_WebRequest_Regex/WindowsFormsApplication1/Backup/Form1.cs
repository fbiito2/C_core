using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //1
            WebRequest ws = HttpWebRequest.Create("http://localhost/table.htm");
            Stream st = ws.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("big5"));
            textBox1.Text = sr.ReadToEnd();

            //2
            Match m = Regex.Match(textBox1.Text, "<tr><td>(.*)</td><td>(.*)</td></tr>");
            if (m.Success)
            {
                textBox2.Text = m.Groups[1].Value + m.Groups[2].Value;
            }
        }
    }
}
