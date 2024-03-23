using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static int linesCounter(string URL)
        {
            int lines = 0;
            using (var reader = new StreamReader(URL))
            {
                while (reader.ReadLine() != null)
                {
                    lines++;
                }
            }
            return lines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();

                textBox2.Text = ofd.FileName;

                textBox1.Text = ofd.SafeFileName;

                StreamReader sr = new StreamReader(ofd.FileName);

                textBox3.Text = linesCounter(ofd.FileName).ToString();

                string content = sr.ReadToEnd();
                richTextBox1.Text = content;

                string[] words = content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                textBox5.Text = words.Length.ToString();

                textBox4.Text = content.Length.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quá trình đọc file đã xảy ra lỗi!\n" + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
