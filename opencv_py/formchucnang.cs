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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loginform loginform = new Loginform();
            DialogResult result = loginform.ShowDialog();
            if (result!=DialogResult.OK)
            {
                this.Close();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Loginform loginform = new Loginform();
            DialogResult dialogResult = loginform.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                dynamic cv2 = Py.Import("cv2");
                dynamic cap1 = cv2.VideoCapture(0);



                while (true)
                {
                    dynamic items1 = cap1.read();
                    dynamic frame1 = items1[1];
                    dynamic gray3 = cv2.cvtColor(frame1, cv2.COLOR_BGR2GRAY);
                    gray3 = cv2.resize(gray3, null, fx: 1.0 / 2, fy: 1.0 / 2);
                    cv2.imshow("hoge1", frame1);
                    cv2.imshow("hoge3", gray3);


                    int item = cv2.waitKey(20);
                    if (item == 113)
                    {
                        cv2.destroyAllWindows(  );
                        break;
                    }

                }
                Console.ReadKey();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Carform carform = new Carform();
            carform.ShowDialog();
        }
    }
}
