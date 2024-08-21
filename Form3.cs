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
using static WindowsFormsApplication1.Form1;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "MMMMnnMM2313")
            {               
                this.Hide();
                this.Close();
                ControlID.TextData = "true";
            }
            else
            {
                MessageBox.Show("کد شارژ صحیح نیست","حریم",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
            Application.Exit();
            Form1 frm1 = new Form1();
            ControlID.TextData = "false";
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
                //Close your app
                ControlID.TextData = "false";
            }
        }
    }
}
