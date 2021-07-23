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
using System.IO;
using System.Reflection;
using System.Security.Policy;

namespace opencv_py
{
    public partial class Carform : Form
    {
        String path;
        public Carform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.white;
            string pathev = System.AppDomain.CurrentDomain.BaseDirectory;
            string pat = @"bin\Debug\";
            pathev = pathev.Replace(pat, string.Empty);
            path = pathev + @"Resources\white.jpeg";

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.blue;
            string pathev = System.AppDomain.CurrentDomain.BaseDirectory;
            string pat = @"bin\Debug\";
            pathev = pathev.Replace(pat, string.Empty);
            path = pathev + @"Resources\blue.jpg";
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
                pictureBox4.Image = Properties.Resources.red;
                string pathev = System.AppDomain.CurrentDomain.BaseDirectory;
                string pat = @"bin\Debug\";
                pathev = pathev.Replace(pat, string.Empty);
                path = pathev + @"Resources\red.png";
         }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image File (*.bmp,*.png,*.jpg,*.jpeg)| *.bmp;*.png;*.jpg;*.jpeg";
            if (DialogResult.OK == openFile.ShowDialog())
            {
                this.pictureBox4.Image = new Bitmap(openFile.FileName);
                pictureBox4.Tag = openFile.FileName;
                path = pictureBox4.Tag as string;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                dynamic cv2 = Py.Import("cv2");
                dynamic np = Py.Import("numpy");

                dynamic img = cv2.imread(path);
                cv2.imshow("img", img);
                cv2.waitKey(20);

            }
        }
    }
}
