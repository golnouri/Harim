using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string filepath;
        public static class ControlID
        {
            public static string TextData { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "D:\\HarimData.txt";
                string folderPath = filepath;


                string[] result;
                int num;
                using (TextReader tr = new StreamReader(path))
                {
                    string res = tr.ReadLine();
                    result = res.Split('$');
                    num = Convert.ToInt32(result[1]) + 1;
                    if (result[1] != "00")
                    {

                        if (num == 10)
                        {
                            Form3 frm3 = new Form3();
                            frm3.ShowDialog();                         
                        }
                    }
                   
                    tr.Close();                            
                }

                if (ControlID.TextData == "false")
                {
                    byebye();
                }
                if (ControlID.TextData == "true")
                {
                    System.IO.File.Delete(path);
                    using (var stream = File.Create(path))
                    {
                        using (TextWriter tw = new StreamWriter(stream))
                        {
                            tw.WriteLine(result[0] + "$" + "00");
                            tw.Close();
                        }
                    }

                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.AddAccessRule(fsa);
                    Directory.SetAccessControl(folderPath, ds);
                    MessageBox.Show("کد شارژ اعمال شد", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("قفل شد", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ControlID.TextData = "9";
                }
                if (result[1] == "00")
                {

                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.AddAccessRule(fsa);
                    Directory.SetAccessControl(folderPath, ds);

                    MessageBox.Show("قفل شد", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ControlID.TextData = "1";
                }
                if(ControlID.TextData == null)
                {
                    System.IO.File.Delete(path);
                    using (var stream = File.Create(path))
                    {
                        using (TextWriter tw = new StreamWriter(stream))
                        {
                            tw.WriteLine(result[0] + "$" + num);
                            tw.Close();
                        }
                    }

                    string adminUserName = Environment.UserName;// getting your adminUserName
                    DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                    FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                    ds.AddAccessRule(fsa);
                    Directory.SetAccessControl(folderPath, ds);

                    MessageBox.Show("قفل شد", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("خطایی رخ داده است");
            }
        }
        public void byebye()
        {
            Application.Exit();
            Environment.Exit(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = filepath;
                string adminUserName = Environment.UserName;// getting your adminUserName
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
                ds.RemoveAccessRule(fsa);
                Directory.SetAccessControl(folderPath, ds);
                MessageBox.Show("قفل فایل برداشته شد", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Select the folder to lock
                filepath = folderBrowserDialog1.SelectedPath;
                button1.Enabled = true;
                button2.Enabled = true;
                pictureBox2.Visible = true;

                Form1.ActiveForm.Text = filepath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            Form2 frm2 = new Form2();
            frm2.ShowDialog();


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2();
            frm2.ShowDialog();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://golnouri.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = "D:\\HarimData.txt";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            MessageBox.Show("برای درج رمز عبور جدید، حریم را دوباره باز کنید", "حریم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
