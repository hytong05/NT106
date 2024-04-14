using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Form9 : Form
    {
        // Tạo đối tương TcpClient
        TcpClient tcpClient;

        // Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
        NetworkStream ns;

        // Tạo luồng để cập nhật thông báo
        Thread UpdateUI;

        // Tạo một IPEndPoint mới cho mỗi client
        private IPEndPoint ipEndPoint;

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (!ConnectToServer()) this.Close();
        }

        private bool ConnectToServer()
        {
            try
            {
                // Tạo đối tượng TCPClient
                tcpClient = new TcpClient();

                // Thực hiện kết nối tới server
                ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                tcpClient.Connect(ipEndPoint);

                // Tạo luồng cho nhận dữ liệu
                Thread Receiver = new Thread(ReceiveFromSever);
                Receiver.Start();

                // Thông báo về việc kết nối thành công
                listView1.Items.Add("Connected to server!");

                // Thực hiện tạo luồng nhận và gửi dữ liệu 
                ns = tcpClient.GetStream();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                // Thông báo về việc kết nối không thành công
                listView1.Items.Add("No connected to server!");

                // Set các giá trị về mặc định
                tcpClient = null;
                ipEndPoint = null;

                this.Close();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMsg(textBox2.Text);
        }

        private void SendMsg(string msg)
        {
            try
            {
                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0) 
                {
                    // Tạo luồng để đọc và ghi dữ liệu 
                    ns = tcpClient.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(textBox1.Text + ": " + msg);
                    ns.Write(data, 0, data.Length);
                    textBox2.Clear();
                }
                else if (msg != "End Because Server Stop Listenning!") throw new Exception("Please write your name and your messages!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void UpdateUIThread(string text)
        {
            listView1.Items.Add(new ListViewItem(text));
        }

        private void ReceiveFromSever()
        {
            try
            {
                // Mảng byte đển chứa dữ liệu
                byte[] recv = new byte[1024];

                while (true)
                {
                    string text = string.Empty;

                    // Nhận dữ liệu
                    int bytesReceived = tcpClient.Client.Receive(recv);
                    text = Encoding.UTF8.GetString(recv, 0, bytesReceived);

                    if (text.Contains("#SERVER_END"))
                    {
                        listView1.Items.Add(new ListViewItem("SERVER IS STOPPED!"));
                        byte[] data = Encoding.UTF8.GetBytes("#CLIENT_END");
                        SendMsg("End Because Server Stop Listenning!");
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        button1.Enabled = false;
                        tcpClient.Close();
                        this.Dispose();
                        this.Close();
                        break;
                    }
                    UpdateUI = new Thread(() => UpdateUIThread(text));
                    UpdateUI.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The Client's Connection is Closed!", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            
        }

        private bool Disconnect()
        {
            try
            {
                if (tcpClient != null)
                {
                    // Gửi thông báo về việc đóng kết nối với server
                    byte[] data = Encoding.UTF8.GetBytes("#CLIENT_END");
                    ns = tcpClient.GetStream();
                    ns.Write(data, 0, data.Length);

                    // Đóng luồng dữ liệu trước khi đóng kết nối
                    ns.Close();

                    // Đóng kết nối với client
                    tcpClient.Close();

                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while disconnecting: " + ex.Message);
                this.Close();
                return true;
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!Disconnect())
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Closing: " + ex.Message);
            }
        }
    }
}