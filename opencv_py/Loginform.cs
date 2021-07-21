using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opencv_py
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "1" & textBox2.Text == "1")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng ");
            }

            if (DialogResult == DialogResult.OK)
                this.Close();
        }
    }
}
