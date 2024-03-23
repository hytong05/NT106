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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string id = textBox2.Text;
            string phone = textBox3.Text;
            string math = textBox4.Text;
            string literature = textBox5.Text;

            string filePath = "data.txt";

            try
            {
                if (phone.Length != 10 || !phone.All(char.IsDigit))
                {
                    throw new Exception("Số điện thoại phải có 10 số.");
                }

                if (!double.TryParse(math, out double mathScore) || mathScore < 0 || mathScore > 10)
                {
                    throw new Exception("Điểm toán không hợp lệ. Vui lòng nhập số thực từ 0 đến 10.");
                }

                if (!double.TryParse(literature, out double literatureScore) || literatureScore < 0 || literatureScore > 10)
                {
                    throw new Exception("Điểm văn không hợp lệ. Vui lòng nhập số thực từ 0 đến 10.");
                }

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    // Ghi dữ liệu vào file theo định dạng: name;id;phone;math;literature
                    sw.WriteLine($"{name};{id};{phone};{math};{literature}");
                }

                MessageBox.Show("Dữ liệu đã được nhập và lưu vào file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            Form7 form7 = new Form7();
            form7.ShowDialog();
            form7 = null;
            this.Show();
        }
    }
}
