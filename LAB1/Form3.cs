using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1, num2, num3;

                // Kiểm tra định dạng đầu vào
                if (!Regex.IsMatch(textBox1.Text, @"^\d+\.?\d*$") ||
                    !Regex.IsMatch(textBox2.Text, @"^\d+\.?\d*$") ||
                    !Regex.IsMatch(textBox3.Text, @"^\d+\.?\d*$"))
                {
                    throw new FormatException();
                }

                num1 = double.Parse(textBox1.Text);
                num2 = double.Parse(textBox2.Text);
                num3 = double.Parse(textBox3.Text);

                textBox4.Text = Math.Min(num1, Math.Min(num2, num3)).ToString();
                textBox5.Text = Math.Max(num1, Math.Max(num2, num3)).ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào bị tràn số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
