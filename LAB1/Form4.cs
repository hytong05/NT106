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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        static string[] units = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
        static string[] tens = { "", "Mười", "Hai mươi", "Ba mươi", "Bốn mươi", "Năm mươi", "Sáu mươi", "Bảy mươi", "Tám mươi", "Chín mươi" };

        static string NumberToWords(int number)
        {
            if (number == 0) return "Không";

            if (number < 0) return "Âm " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Nghìn ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += units[number / 100] + " Trăm ";
                number %= 100;
            }

            if ((number / 10) > 0)
            {
                words += tens[number / 10] + " ";
                number %= 10;
            }
            else if (number > 0)
            {
                words += "Lẻ ";
            }

            if (number > 0)
            {
                words += units[number];
            }

            return words.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Int32.Parse(textBox1.Text);
                richTextBox1.Text = NumberToWords(num);
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
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
