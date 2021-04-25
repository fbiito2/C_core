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

namespace Mod01_BinaryReaderWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //物件陣列
            Student[] students = new Student[]
                {new Student{ ID = 1, Name = "Lisa", AvgScore = 88 },
                new Student { ID = 2, Name = "Mickey", AvgScore = 90 }};


            using (FileStream fs = File.Create(@"c:\test\students.bin"))
            {
                BinaryWriter writer = new BinaryWriter(fs);  //二進位

                foreach (Student st in students)
                {
                    writer.Write(st.ID);
                    writer.Write(st.Name);
                    writer.Write(st.AvgScore);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open(@"c:\test\students.bin", FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fs);

                while (reader.PeekChar() != -1)
                {
                    Student st = new Student
                    {
                        ID = reader.ReadInt32(),
                        Name = reader.ReadString(),
                        AvgScore = reader.ReadSingle()
                    };
                    listBox1.Items.Add(st.ID + ", " + st.Name + ", " + st.AvgScore);
                }
            }
        }
    }

    struct Student
    {
        public int ID;
        public string Name;
        public Single AvgScore;
    }
}
