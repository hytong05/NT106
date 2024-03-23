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

namespace LAB2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                StreamReader sr = new StreamReader(ofd.FileName);
                string content = sr.ReadToEnd();
                richTextBox1.Text = content;
                MessageBox.Show("Quá trình đọc file đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quá trình đọc file đã xảy ra lỗi!\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text (*.txt) | *.txt";
                sfd.ShowDialog();

                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                byte[] ct = Encoding.UTF8.GetBytes((richTextBox1.Text).ToUpper());
                fs.Write(ct, 0, ct.Length);
                MessageBox.Show("Quá trình ghi file đã hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quá trình ghi file đã xảy ra lỗi!\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
