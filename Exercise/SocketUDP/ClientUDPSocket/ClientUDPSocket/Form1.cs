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
using System.IO;
using System.Security.Cryptography;

namespace ClientUDPSocket
{
    public partial class Form1 : Form
    {
        private readonly byte[] aesKey = new byte[32]; // Khóa AES có độ dài 256-bit (32 byte)
        private readonly byte[] aesIV = new byte[16]; // IV cho mã hóa AES (có thể tạo một IV ngẫu nhiên)

        public Form1()
        {
            InitializeComponent();

            // Chuyển đổi chuỗi "YourSecretKey" thành một mảng byte có độ dài 32 byte
            string keyString = "YourSecretKeyYourSecretKeyYourSecretKeyYourSecretKey";
            Array.Copy(Encoding.UTF8.GetBytes(keyString), aesKey, aesKey.Length);
        }

        private byte[] EncryptAES(byte[] plainTextBytes, byte[] key, byte[] iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Tạo bộ mã hóa để thực hiện AES
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Tạo dữ liệu đầu ra để lưu trữ dữ liệu đã mã hóa
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy địa chỉ IP từ textbox và chuyển thành kiểu IPAddress
            IPAddress ipadd = IPAddress.Parse(textBox1.Text);
            int port = Convert.ToInt32(textBox2.Text);
            IPEndPoint ipend = new IPEndPoint(ipadd, port);

            // Chuyển chuỗi dữ liệu nhập sang kiểu byte
            Byte[] plainTextBytes = Encoding.UTF8.GetBytes(textBox3.Text);

            // Thực hiện mã hóa AES
            byte[] iv = new byte[16]; // IV cho mã hóa AES (có thể tạo một IV ngẫu nhiên)
            byte[] encryptedBytes = EncryptAES(plainTextBytes, aesKey, iv);

            // Gởi dữ liệu đã mã hóa đến IPEndPoint đã định nghĩa địa chỉ IP và Port
            using (UdpClient udpClient = new UdpClient())
            {
                udpClient.Send(encryptedBytes, encryptedBytes.Length, ipend);
            }

            // Xóa dữ liệu vừa gửi ở ô nhập
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
