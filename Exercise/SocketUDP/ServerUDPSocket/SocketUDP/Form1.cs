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
using System.IO;
using System.Security.Cryptography;

namespace SocketUDP
{
    public partial class Form1 : Form
    {
        // private readonly byte[] aesKey = Encoding.UTF8.GetBytes("YourSecretKey");
        private readonly byte[] aesKey = new byte[32];
        private readonly byte[] aesIV = new byte[16]; // IV cho mã hóa AES (có thể tạo một IV ngẫu nhiên)

        public Form1()
        {
            InitializeComponent();
            string keyString = "YourSecretKeyYourSecretKeyYourSecretKeyYourSecretKey";
            Array.Copy(Encoding.UTF8.GetBytes(keyString), aesKey, aesKey.Length);
        }

        private string DecryptReceivedData(byte[] cipherTextBytes)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = aesKey;
                aesAlg.IV = aesIV;

                // Tạo bộ giải mã để thực hiện AES
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public void serverThread()
        {
            int port = Convert.ToInt32(textBox1.Text);
            UdpClient udpClient = new UdpClient(port);
            while (true)
            {
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
                byte[] recvBytes = udpClient.Receive(ref ipEnd);

                // Giải mã dữ liệu nhận được
                string decryptedData = DecryptReceivedData(recvBytes);

                // Hiển thị thông tin đã giải mã trên giao diện
                string message = $"{ipEnd.Address}:{ipEnd.Port}: {decryptedData}";
                richTextBox1.Invoke(new Action(() => richTextBox1.Text += message + "\r\n"));
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
            if (server != null && server.IsAlive)
            {
                server.Interrupt();
                server.Join();
            }
        }
    }

}
