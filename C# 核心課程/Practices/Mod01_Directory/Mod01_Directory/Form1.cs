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

namespace Mod01_Directory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Directory.Delete(textBox1.Text);  //刪除檔案directory.Delete(完整路徑名)，這個不會問也不會放到回收桶直接消失!!!!!!
            
            //VB提供可操作深層元件(win32API)的方法，功能比較多microsoft.VisualBasic.FileIO.Filesystem.DeleteDirectory(完整路徑名,出現對話方塊,放到回收桶)
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                textBox1.Text,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(path)) return;

            DirectoryInfo root = new DirectoryInfo(path);

            foreach (DirectoryInfo di in root.GetDirectories())
            {
                listBox1.Items.Add(
                    String.Format("{0}, Attributes:{1}.", di.Name, di.Attributes));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(path)) return;

            var dirs = from dir in Directory.EnumerateDirectories(path)
                       select dir;

            foreach (var dir in dirs)
            {
                listBox1.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
            }

        }
    }
}
