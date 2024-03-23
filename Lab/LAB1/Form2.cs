using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB1
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
                int num1, num2;
                long sum;
                num1 = Int32.Parse(textBox1.Text.Trim());
                num2 = Int32.Parse(textBox2.Text.Trim());
                sum = num1 + num2;
                textBox3.Text = sum.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Kết quả phép toán bị tràn số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num1, num2;
                long sub;
                num1 = Int32.Parse(textBox1.Text.Trim());
                num2 = Int32.Parse(textBox2.Text.Trim());
                sub = num1 - num2;
                textBox3.Text = sub.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Kết quả phép toán bị tràn số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int num1, num2;
                long mul;
                num1 = Int32.Parse(textBox1.Text.Trim());
                num2 = Int32.Parse(textBox2.Text.Trim());
                mul = num1 * num2;
                textBox3.Text = mul.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Kết quả phép toán bị tràn số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                float num1, num2;
                float div;
                num1 = float.Parse(textBox1.Text.Trim());
                num2 = float.Parse(textBox2.Text.Trim());
                div = num1 / num2;
                textBox3.Text = div.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Kết quả phép toán bị tràn số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
