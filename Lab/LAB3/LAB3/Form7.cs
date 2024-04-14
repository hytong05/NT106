using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LAB3
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        // Tạo đối tương TcpClient
        TcpClient tcpClient = new TcpClient();

        // Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
        NetworkStream ns;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {            
                // Kết nối đến Server với 1 địa chỉ Ip và Port xác định 
                IPAddress ipAddress = IPAddress.Parse(textBox1.Text);
                int port = Convert.ToInt32(textBox2.Text);

                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                tcpClient.Connect(ipEndPoint);

                if (tcpClient.Connected)
                {
                    listView1.Items.Add("Successful connection!");
                    button1.Text = "Connected";
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    ns = tcpClient.GetStream();
                }
                else
                { 
                    listView1.Items.Add("Connection failure!"); 
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            
        }

        private void SendMsg(string msg)
        {
            if (msg != null)
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                ns.Write(data, 0, data.Length);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SendMsg(textBox3.Text);
            listView1.Items.Add(new ListViewItem(textBox3.Text));
            textBox3.Clear();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Dùng phương thức Write để gửi dữ liệu mang dấu hiệu kết thúc cho Server biết và đóng kết nối
            if (ns != null)
            {
                SendMsg("Quit\n");
                ns.Close();
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }
    }
}
