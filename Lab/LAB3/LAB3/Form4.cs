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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace LAB3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void serverThread()
        {
            try
            {
                int port = Convert.ToInt32(textBox1.Text);
                UdpClient udpClient = new UdpClient(port);
                while (true)
                {
                    IPEndPoint IpEnd = new IPEndPoint(IPAddress.Any, port);
                    button1.Text = "Listening";
                    textBox1.ReadOnly = true;
                    var recvByte = new Byte[1];
                    recvByte = udpClient.Receive(ref IpEnd);
                    string Data = Encoding.UTF8.GetString(recvByte);
                    string mess = IpEnd.Address.ToString() + ": " + Data.ToString();
                    richTextBox1.Invoke(new Action(() => richTextBox1.Text += mess + "\r\n"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Thread server;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                server = new Thread(serverThread);
                server.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
