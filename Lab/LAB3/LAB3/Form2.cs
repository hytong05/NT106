using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void serverThread()
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void clientThread()
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private Thread server, client;

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            client = new Thread(clientThread);
            client.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            server = new Thread(serverThread);
            server.Start();
        }
    }
}
