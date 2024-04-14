using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB3
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Xử lý lỗi InvalidOperationException
            CheckForIllegalCrossThreadCalls = false;

            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            try
            {
                listView1.Items.Add(new ListViewItem("Waiting for connetion..."));

                int bytesReceived = 0;

                // Khởi tạo mảng byte nhận dữ liệu
                byte[] recv = new byte[1];

                // Tạo socket bên gửi
                Socket clientSocket;

                /* 
                 * Tạo socket bên nhận, socket này là socket lắng nghe các kết nối tới nó tại địa chỉ IP của máy và port 8080. 
                 * Đây là 1 TCP / IP socket.
                 * AddressFamily: Với địa chỉ Ipv4 cần chọn AddressFamily.InterNetwork
                 * SocketType: kiểu kết nối socket, ở đây dùng luồng Stream để nhận dữ liệu
                */
                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                // Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
                listenerSocket.Bind(ipepServer);

                // bắt đầu lắng nghe. Socket.Listen(int backlog) 
                listenerSocket.Listen(-1);
                button1.Text = "Listening";

                //Đồng ý kết nối
                clientSocket = listenerSocket.Accept();

                //Nhận dữ liệu
                listView1.Items.Add(new ListViewItem("Telnet running on " + ipepServer.Address + ":" + ipepServer.Port));

                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        text += Encoding.UTF8.GetString(recv, 0, bytesReceived);
                    }
                    while (text[text.Length - 1] != '\n');

                    // Kiểm tra nếu kết nối đã bị đóng từ phía client
                    if (bytesReceived == 0)
                    {
                        listView1.Items.Add(new ListViewItem("Connection closed by client."));
                        button1.Text = "Listen";
                        break;
                    }

                    listView1.Items.Add(new ListViewItem(ipepServer.Address + ":" + ipepServer.Port + ": " + text));
                }

                // Đóng socket lắng nghe khi kết thúc quá trình
                listenerSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}