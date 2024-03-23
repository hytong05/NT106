using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketUDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void serverThread()
        {
            int port = Convert.ToInt32(textBox1.Text);
            UdpClient udpClient = new UdpClient(port);
            while (true)
            {
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Any, port);
                Byte[] recvByte = udpClient.Receive(ref IpEnd);
                string Data = Encoding.UTF8.GetString(recvByte);
                string mess = IpEnd.Address.ToString() + ":" + IpEnd.Port.ToString() + ": " + Data.ToString();
                richTextBox1.Invoke(new Action(() => richTextBox1.Text += mess + "\r\n"));
            }
        }

        private Thread server;

        private void button1_Click(object sender, EventArgs e)
        {
            server = new Thread(serverThread);
            server.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Interrupt();
                server.Join();
            }
        }
    }
}
