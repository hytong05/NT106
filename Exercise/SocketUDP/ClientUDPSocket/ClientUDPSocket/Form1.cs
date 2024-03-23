using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUDPSocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            //Lấy địa chỉ IP từ textbox và chuyển thành kiểu IPAddress
            IPAddress ipadd = IPAddress.Parse(textBox1.Text);
            int port = Convert.ToInt32(textBox2.Text);
            IPEndPoint ipend = new IPEndPoint(ipadd, port);
            //Chuyển chuỗi dữ liệu nhập sang kiểu byte
            Byte[] sendBytes = Encoding.UTF8.GetBytes(textBox3.Text);
            //Gởi dữ liệu đến IPEndPoint đã định nghĩa địa chỉ IP và Port
            udpClient.Send(sendBytes, sendBytes.Length, ipend);
            //Xóa dữ liệu vừa gửi ở ô nhập
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
