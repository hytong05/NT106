using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Http;
using System.Text;

namespace LAB3
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        // Khởi tạo mảng byte nhận dữ liệu
        private byte[] recv = new byte[1024];

        private int bytesReceived = 0;

        // Tạo socket bên gửi
        Socket clientSocket;

        // Tạo socket cho server
        private Socket listenerSocket;

        // IpendPoint cho server
        private IPEndPoint ipepServer;

        void StartUnsafeThread()
        {
            try
            {
                listView1.Items.Add(new ListViewItem("Waiting for connetion..."));                

                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAddres = IPAddress.Parse(textBox1.Text);
                int port = Convert.ToInt32(textBox2.Text);
                
                ipepServer = new IPEndPoint(ipAddres, port);

                // Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
                listenerSocket.Bind(ipepServer);

                // bắt đầu lắng nghe. Socket.Listen(int backlog) 
                listenerSocket.Listen(-1);
                button1.Text = "Listening";
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;

                //Đồng ý kết nối
                clientSocket = listenerSocket.Accept();

                //Nhận dữ liệu
                listView1.Items.Add(new ListViewItem("Connected!"));

                while (clientSocket.Connected)
                {
                    string text = "";

                    // Nhận message từ client
                    bytesReceived = clientSocket.Receive(recv);
                    text = Encoding.UTF8.GetString(recv, 0, bytesReceived);

                    if (!string.IsNullOrEmpty(text))
                    {
                        listView1.Items.Add(new ListViewItem(ipepServer.Address + ": " + text));
                    }

                    if (text.Contains("Quit!"))
                    {
                        listView1.Items.Add(new ListViewItem("Connection closed by client."));
                        button1.Text = "Listen";
                        textBox1.ReadOnly = false;
                        textBox2.ReadOnly = false;
                        listenerSocket.Close();
                        break;
                    }                        
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Xử lý lỗi InvalidOperationException
            CheckForIllegalCrossThreadCalls = false;

            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }
    }
}
