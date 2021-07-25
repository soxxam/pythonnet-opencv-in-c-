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
using System.Collections;

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
            ArrayList arrColor = new ArrayList();
            arrColor.Add(new mau(17, 15, 100, 50, 56, 200));
            arrColor.Add(new mau(86, 31, 4, 220, 88, 50));
            arrColor.Add(new mau(25, 146, 190, 62, 174, 250));
            arrColor.Add(new mau(103, 86, 65, 145, 133, 128));
            using (Py.GIL())
            {
                dynamic cv2 = Py.Import("cv2");
                dynamic np = Py.Import("numpy");

                dynamic img = cv2.imread(path);
                cv2.imshow("img", img);
                foreach (mau item in arrColor)
                {
                    dynamic lower = np.array(new List<int> { item.g, item.b, item.r }, dtype: np.uint8);
                    dynamic upper = np.array(new List<int> { item.gl, item.bl, item.rl }, dtype: np.uint8);
                    dynamic mask = cv2.inRange(img, lower, upper);
                    cv2.imshow("mask", mask);
                    cv2.waitKey(0);
                }
                MessageBox.Show("test thu git nay");

            }
        }
    }
}
