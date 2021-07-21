using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Python.Runtime;

namespace opencv_py
{
    public partial class Carform : Form
    {
        public Carform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.white;
              
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.blue;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.red;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            pictureBox4.Image = Image.FromFile(filePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                dynamic cv2 = Py.Import("cv2");
                dynamic np = Py.Import("numpy");
                dynamic img = cv2.imread("C:\\Users\\sieut\\source\\repos\\opencv_py\\opencv_py\\Resources\blue.jpg");
                cv2.imshow("img", img);
                cv2.waitkey(0);
                Console.ReadKey();
            }
        }
    }
}
