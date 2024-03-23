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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox1.Text;
                string[] numbers = input.Split(' ');

                if (numbers.Length != 12)
                {
                    throw new ArgumentException("Dữ liệu đầu vào phải có 12 số thực.");
                }

                double[] nums = new double[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    double number;
                    if (!double.TryParse(numbers[i], out number))
                    {
                        throw new ArgumentException($"Số thứ {i + 1} không hợp lệ.");
                    }
                    if (number < 0 || number > 10)
                    {
                        throw new ArgumentException($"Số thứ {i + 1} phải nằm trong khoảng từ 0 đến 10.");
                    }
                    nums[i] = number;
                }

                mon1.Text = "Điểm môn 1: " + numbers[0] + "đ";
                mon2.Text = "Điểm môn 2: " + numbers[1] + "đ";
                mon3.Text = "Điểm môn 3: " + numbers[2] + "đ";
                mon4.Text = "Điểm môn 4: " + numbers[3] + "đ";
                mon5.Text = "Điểm môn 5: " + numbers[4] + "đ";
                mon6.Text = "Điểm môn 6: " + numbers[5] + "đ";
                mon7.Text = "Điểm môn 7: " + numbers[6] + "đ";
                mon8.Text = "Điểm môn 8: " + numbers[7] + "đ";
                mon9.Text = "Điểm môn 9: " + numbers[8] + "đ";
                mon10.Text = "Điểm môn 10: " + numbers[9] + "đ";
                mon11.Text = "Điểm môn 11: " + numbers[10] + "đ";
                mon12.Text = "Điểm môn 12: " + numbers[11] + "đ";

                double gpa = 0;
                double max = 0;
                double min = 10;
                int pass = 0;
                int less65 = 0, less5 = 0, less35 = 0, less2 = 0;
                foreach (double num in nums) 
                {
                    gpa = gpa + num / 12;
                    max = Math.Max(max, num);  
                    min = Math.Min(min, num);
                    if (num >= 5) 
                        pass++;
                }

                foreach (double num in nums)
                {
                    if (num < 2)
                    {
                        less2++;
                    }
                    if (num < 3.5)
                    {
                        less35++;
                    }
                    if (num < 5)
                    {
                        less5++;
                    }
                    if (num < 6.5)
                    {
                        less65++;
                    }
                }

                dtb.Text = "Điểm trung bình: " + Math.Round(gpa, 2).ToString() + "đ";
                caonhat.Text = "Môn có điểm cao nhất: " + max.ToString() + "đ";
                thapnhat.Text = "Môn có điểm thấp nhất: " + min.ToString() + "đ";
                somondau.Text = "Số môn đậu: " + pass.ToString();
                somonrot.Text = "Số môn không đậu: " + (12 - pass).ToString();

                if (gpa >= 8 && less65 == 0)
                    xeploai.Text = "Xếp loại học lực: Giỏi";
                else if (gpa >= 6.5 && less5 == 0)
                    xeploai.Text = "Xếp loại học lực: Khá";
                else if (gpa >= 5 && less35 == 0)
                    xeploai.Text = "Xếp loại học lực: Trung bình";
                else if (gpa >= 3.5 && less2 == 0)
                    xeploai.Text = "Xếp loại học lực: Yếu";
                else xeploai.Text = "Xếp loại học lực: Kém";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra dữ liệu đầu vào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
