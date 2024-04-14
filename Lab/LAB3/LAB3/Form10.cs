using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace LAB3
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        // Khởi tạo mảng byte nhận dữ liệu
        private byte[] recv;

        private int bytesReceived = 0;

        // Danh sách các client đang kết nối đến server
        private List<Socket> ListClient;

        // Tạo socket cho server
        private Socket listenerSocket;

        // IpendPoint cho server
        private IPEndPoint ipepServer;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Xử lý lỗi InvalidOperationException
                CheckForIllegalCrossThreadCalls = false;

                Thread serverThread = new Thread(StartUnsafeThread);

                if (!serverThread.IsAlive)
                {
                    serverThread.Start();
                    button1.Text = "Listening";
                    button2.Visible = true;
                }
                else 
                    MessageBox.Show("Server is listening!");

                if (listView1.Items.Count != 0)
                {
                    listView1.Items.Clear();
                    listView1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Click Button 1:\n" + ex.Message);
            }
        }

        private void StartUnsafeThread()
        {
            try
            {
                bytesReceived = 0;
                recv = new byte[1024];

                // Tạo socket cho server
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // IpendPoint cho server
                ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                // Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
                listenerSocket.Bind(ipepServer);

                // Thông báo
                listView1.Items.Add(new ListViewItem("Listenning on: " + ipepServer.ToString()));
                listView1.Items.Add(new ListViewItem("Waiting for connetion..."));

                // bắt đầu lắng nghe. Socket.Listen(int backlog) 
                listenerSocket.Listen(-1);

                //Đồng ý kết nối
                AcceptClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Server Listening:\n" + ex.Message);
            }
        }

        private void AcceptClient()
        {
            try
            {
                ListClient = new List<Socket>();

                while (true)
                {
                    // Tạo một socket mới cho client mới kết nối
                    Socket clientSocket = listenerSocket.Accept();

                    // Thêm vào danh sách client
                    ListClient.Add(clientSocket);

                    // Gửi thông báo về client và thông báo
                    SendMsg("Server: Welcom to my chatrooom!", clientSocket);

                    // Thêm thông báo vào bảng hiển thị của server
                    listView1.Items.Add(new ListViewItem("New Client Connected: " + clientSocket.RemoteEndPoint.ToString()));

                    // Thông báo với client về một client mới tham gia
                    if (ListClient.Count > 1)
                    {
                        Broadcast_add("New Client Connected: " + clientSocket.RemoteEndPoint.ToString(), clientSocket);
                    }

                    // Tạo luồng cho việc nhận message từ client
                    Thread receiver = new Thread(() => ReceiveMsg(clientSocket));
                    receiver.Start();
                }
            }
            catch (Exception)
            {
                ServerCloseListening();
            }
        }

        // Xử lý sự kiện nhận thông điệp từ client
        private void ReceiveMsg(Socket clientSocket)
        {
            try
            {
                while (true && clientSocket.Connected && listenerSocket.LocalEndPoint != null)
                {
                    string msg = string.Empty;

                    // Nhận dữ liệu từ client và xử lý như bình thường
                    bytesReceived = clientSocket.Receive(recv);
                    msg = Encoding.UTF8.GetString(recv, 0, bytesReceived);

                    // Kiểm tra mã để xác định trạng thái kết nối của client
                    if (msg.Contains("#CLIENT_END"))
                    {
                        // In ra thông báo về sự ngắt kết nối của client
                        listView1.Items.Add("Client " + clientSocket.RemoteEndPoint.ToString() + " has left the chat.");

                        // Broadcast cho các client về sự ngắt kết nối này
                        Broadcast_add("Client " + clientSocket.RemoteEndPoint.ToString() + " has left the chat.", clientSocket);

                        // Client đã đóng kết nối
                        CloseClientConnection(clientSocket);
                        break;
                    }

                    // In ra màn hình thông tin từ client
                    listView1.Items.Add(new ListViewItem(clientSocket.RemoteEndPoint.ToString() + ": " + msg));

                    // Broadcast đến tất cả các client đang kết nối
                    Broadcast(msg);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The Server's Connection is Closed!", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void CloseClientConnection(Socket clientSocket)
        {
            // Đóng socket của client
            clientSocket.Close();

            // Tìm và xóa client đóng kết nối khỏi danh sách
            foreach (var item in ListClient.ToArray())
            {
                if (item == clientSocket)
                {
                    ListClient.RemoveAt(ListClient.IndexOf(item));
                    break;
                }
            }
        }

        // Gửi dữ liệu cho client
        private void SendMsg(string msg, Socket client)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            client.Send(data);
        }

        // Broadcast đến tất cả client trong danh sách trừ client mới
        private void Broadcast_add(string msg, Socket socket)
        {
            foreach (var item in ListClient)
            {
                if (item != socket)
                    SendMsg(msg, item);
            }
        }

        // Broadcast đến tất cả client trong danh sách
        private void Broadcast(string msg)
        {
            foreach (var item in ListClient)
            {
                SendMsg(msg, item);
            }
        }

        private void ServerCloseListening()
        {
            // Dừng quá trình nghe
            StopListening();

            // Đóng toàn bộ kết nối với các client
            foreach (var item in ListClient.ToArray())
            {
                CloseClientConnection(item);
            }

            // Xóa danh sách client
            ListClient.Clear();

            // Set các giá trị về mặc định
            recv = null;
            bytesReceived = 0;
            ipepServer = null;
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerCloseListening();
        }

        // Xử lý kết thúc quá trình nghe
        private void StopListening()
        {
            try
            {            
                if (listenerSocket != null)
                {
                    // Thông báo đến các client về sự dừng quá trình nghe
                    Broadcast("#SERVER_END");

                    // Xóa các thông tin tại listview
                    if (listView1.SelectedItems.Count == 0 && listView1.Items.Count != 0)
                    {
                        listView1.Items.Clear();
                    }

                    // Đóng socket listener
                    listenerSocket.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Stop Listening:\n" + ex.Message);
            }
        }  

        // Xử lý sự kiện bấm nút Stop
        private void button2_Click(object sender, EventArgs e)
        {
            StopListening();
            button1.Text = "Listen";
            button1.Enabled = true;
            button2.Visible = true;
        }
        private void Form10_Load(object sender, EventArgs e)
        {
            // Bắt đầu tạo luồng cho quá trình nghe
            Thread ControlListenBtn = new Thread(ListenButton);
            ControlListenBtn.Start();
        }

        // Thay đổi nút Listen trong quá trình nghe
        private void ListenButton()
        {
            while (true)
            {
                if (button1.Text == "Listening")
                {
                    button1.Enabled = false;
                    button2.Visible = true;
                }
                else
                    button2.Visible = false;
            }
        }
    }
}
