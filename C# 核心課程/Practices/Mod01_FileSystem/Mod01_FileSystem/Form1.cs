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

namespace Mod01_FileSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                listBox1.Items.Add("磁碟:" + drive.Name);
                listBox1.Items.Add("  種類:" + drive.DriveType.ToString());
                if (drive.IsReady)
                {
                    listBox1.Items.Add("  標籤名稱:" + drive.VolumeLabel);
                    listBox1.Items.Add("  檔案系統:" + drive.DriveFormat);
                    listBox1.Items.Add("  容量:" + drive.TotalSize);
                }
                else
                {
                    listBox1.Items.Add("  目前無法使用.");
                }
            }
        }
    }
}
