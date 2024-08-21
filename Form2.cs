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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string path = "D:\\HarimData.txt";
            if (File.Exists(path))
            {
                textBox2.Enabled = false;
                button1.Text = "بررسی";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string path = "D:\\HarimData.txt";
            if (!File.Exists(path))
            {
                if (textBox1.Text == textBox2.Text)
                {
                    using (var stream = File.Create(path))
                    {
                        using (TextWriter tw = new StreamWriter(stream))
                        {
                            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                            {
                                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
                                byte[] hashBytes = md5.ComputeHash(inputBytes);

                                StringBuilder sb = new StringBuilder();
                                for (int i = 0; i < hashBytes.Length; i++)
                                {
                                    sb.Append(hashBytes[i].ToString("X2"));
                                }
                                tw.WriteLine(sb.ToString() + "$" + "0");
                            }

                            tw.Close();
                        }
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("رمز عبور و تکرار آن برابر نیست", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                using (TextReader tr = new StreamReader(path))
                {
                    string res = tr.ReadLine();
                    string[] result = res.Split('$');

                    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                    {
                        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
                        byte[] hashBytes = md5.ComputeHash(inputBytes);

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < hashBytes.Length; i++)
                        {
                            sb.Append(hashBytes[i].ToString("X2"));
                        }
                        if (result[0] == sb.ToString())
                        {
                            this.Hide();
                            //Form1 frm1 = new Form1();
                            //frm1.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("رمز عبور صحیح نیست", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }


                }
            }

         

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
