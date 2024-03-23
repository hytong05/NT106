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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace LAB1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        static string[] OCT = { "000", "001", "010", "011", "100", "101", "110", "111" };

        static string[] HEX = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111",
                                "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };

        static bool IsHexDigit(char c)
        {
            return char.IsDigit(c) || (char.IsLetter(c) && char.ToUpper(c) >= 'A' && char.ToUpper(c) <= 'F');
        }

        static string OCT2BIN(string str)
        {
            string res = string.Empty;
            bool isValidInput = true;

            foreach (char c in str)
            {
                if (!char.IsDigit(c) || c > '7')
                {
                    isValidInput = false;
                    break;
                }
                int digit = int.Parse(c.ToString());
                res += OCT[digit];
            }
            if (!isValidInput)
            {
                throw new ArgumentException("Sai định dạng hệ bát phân: " + str);
            }
            return res;
        }

        static string HEX2BIN(string str)
        {
            string res = string.Empty;
            bool isValidInput = true;

            foreach (char c in str)
            {
                if (!IsHexDigit(c))
                {
                    isValidInput = false;
                    break;
                }

                int digit;
                if (char.IsDigit(c))
                {
                    digit = c - '0';
                }
                else
                {
                    digit = c - 'A' + 10;
                }

                res += HEX[digit];
            }
            if (!isValidInput)
            {
                throw new ArgumentException("Sai định dạng hệ thập lục phân: " + str);
            }
            return res;
        }

        static string DEC2BIN(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Giá trị không thể âm: " + num);
            }

            string binaryString = string.Empty;

            while (num > 0)
            {
                int remainder = num % 2;
                binaryString = remainder.ToString() + binaryString;
                num /= 2;
            }

            return binaryString;
        }

        static string BIN2DEC(string binaryString)
        {
            if (binaryString.Length == 0)
            {
                throw new ArgumentException("Chuỗi nhị phân rỗng");
            }

            int decimalNumber = 0;
            int power = 0;

            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] != '0' && binaryString[i] != '1')
                {
                    throw new ArgumentException("Chuỗi nhị phân không hợp lệ: " + binaryString);
                }

                decimalNumber += (int)(Math.Pow(2, power) * (binaryString[i] - '0'));
                power++;
            }
            return decimalNumber.ToString();
        }

        static string BIN2OCT(string binaryString)
        {
            if (binaryString.Length == 0)
            {
                throw new ArgumentException("Chuỗi nhị phân rỗng");
            }

            int paddingLength = 3 - (binaryString.Length % 3);

            if (paddingLength > 0)
            {
                binaryString = new string('0', paddingLength) + binaryString;
            }

            string octalString = "";

            for (int i = 0; i < binaryString.Length; i += 3)
            {
                string triplet = binaryString.Substring(i, 3);
                char octalDigit;

                if (triplet == "000")
                {
                    octalDigit = '0';
                }
                else if (triplet == "001")
                {
                    octalDigit = '1';
                }
                else if (triplet == "010")
                {
                    octalDigit = '2';
                }
                else if (triplet == "011")
                {
                    octalDigit = '3';
                }
                else if (triplet == "100")
                {
                    octalDigit = '4';
                }
                else if (triplet == "101")
                {
                    octalDigit = '5';
                }
                else if (triplet == "110")
                {
                    octalDigit = '6';
                }
                else if (triplet == "111")
                {
                    octalDigit = '7';
                }
                else
                {
                    throw new ArgumentException("Chuỗi nhị phân không hợp lệ: " + binaryString);
                }

                octalString += octalDigit;
            }

            return octalString;
        }

        static string BIN2HEX(string binaryString)
        {
            if (binaryString.Length == 0)
            {
                throw new ArgumentException("Chuỗi nhị phân rỗng");
            }

            int paddingLength = 4 - (binaryString.Length % 4);

            if (paddingLength > 0)
            {
                binaryString = new string('0', paddingLength) + binaryString;
            }

            string hexString = "";

            for (int i = 0; i < binaryString.Length; i += 4)
            {
                string quartet = binaryString.Substring(i, 4);
                char hexDigit;

                if (quartet == "0000")
                {
                    hexDigit = '0';
                }
                else if (quartet == "0001")
                {
                    hexDigit = '1';
                }
                else if (quartet == "0010")
                {
                    hexDigit = '2';
                }
                else if (quartet == "0011")
                {
                    hexDigit = '3';
                }
                else if (quartet == "0100")
                {
                    hexDigit = '4';
                }
                else if (quartet == "0101")
                {
                    hexDigit = '5';
                }
                else if (quartet == "0110")
                {
                    hexDigit = '6';
                }
                else if (quartet == "0111")
                {
                    hexDigit = '7';
                }
                else if (quartet == "1000")
                {
                    hexDigit = '8';
                }
                else if (quartet == "1001")
                {
                    hexDigit = '9';
                }
                else if (quartet == "1010")
                {
                    hexDigit = 'A';
                }
                else if (quartet == "1011")
                {
                    hexDigit = 'B';
                }
                else if (quartet == "1100")
                {
                    hexDigit = 'C';
                }
                else if (quartet == "1101")
                {
                    hexDigit = 'D';
                }
                else if (quartet == "1110")
                {
                    hexDigit = 'E';
                }
                else if (quartet == "1111")
                {
                    hexDigit = 'F';
                }
                else
                {
                    throw new ArgumentException("Chuỗi nhị phân không hợp lệ: " + binaryString);
                }

                hexString += hexDigit;
            }

            return hexString.TrimStart('0');
        }

        static string DEC2OCT(int num)
        {
            return BIN2OCT(DEC2BIN(num));
        }

        static string DEC2HEX(int num)
        {
            return BIN2HEX(DEC2BIN(num));
        }

        static string OCT2DEC(string octalString)
        {
            return BIN2DEC(OCT2BIN(octalString));
        }

        static string OCT2HEX(string octalString)
        {
            return BIN2HEX(OCT2BIN(octalString));
        }

        static string HEX2OCT(string octalString)
        {
            return BIN2OCT(HEX2BIN(octalString));
        }

        static string HEX2DEC(string octalString)
        {
            return BIN2DEC(HEX2BIN(octalString));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string type1 = comboBox1.Text;
                string type2 = comboBox2.Text;
                string input = textBox1.Text;

                if (type1 == "Octal" && type2 == "Binary")
                {
                    richTextBox1.Text = OCT2BIN(input);
                }

                else if (type1 == "Hexadecimal" && type2 == "Binary")
                {
                    richTextBox1.Text = HEX2BIN(input);
                }

                else if (type1 == "Decimal" && type2 == "Binary")
                {
                    richTextBox1.Text = DEC2BIN(Int32.Parse(input));
                }

                else if (type1 == "Binary" && type2 == "Decimal")
                {
                    richTextBox1.Text = BIN2DEC(input);
                }

                else if (type1 == "Binary" && type2 == "Octal")
                {
                    richTextBox1.Text = BIN2OCT(input);
                }

                else if (type1 == "Binary" && type2 == "Hexadecimal")
                {
                    richTextBox1.Text = BIN2HEX(input);
                }

                else if (type1 == "Decimal" && type2 == "Octal")
                {
                    richTextBox1.Text = DEC2OCT(Int32.Parse(input));
                }

                else if (type1 == "Decimal" && type2 == "Hexadecimal")
                {
                    richTextBox1.Text = DEC2HEX(Int32.Parse(input));
                }

                else if (type1 == "Octal" && type2 == "Decimal")
                {
                    richTextBox1.Text = OCT2DEC(input);
                }

                else if (type1 == "Octal" && type2 == "Hexadecimal")
                {
                    richTextBox1.Text = OCT2HEX(input);
                }

                else if (type1 == "Hexadecimal" && type2 == "Octal")
                {
                    richTextBox1.Text = HEX2OCT(input);
                }

                else if (type1 == "Hexadecimal" && type2 == "Decimal")
                {
                    richTextBox1.Text = HEX2DEC(input);
                }

                else if (type1 == type2)
                {
                    richTextBox1.Text = input;
                }

                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi dữ liệu nhập vào", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi do số liệu quá lớn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
