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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        void Client_Thread()
        {
            Form9 form9 = new Form9();
            form9.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread clientThread = new Thread(Client_Thread);
            clientThread.Start();
        }

        private void ServerThread()
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }

        private void isServerAlive(Thread ServerThrd)
        {
            while (true)
            {
                if (ServerThrd.IsAlive)
                {
                    button2.Enabled = false;
                }
                else
                {
                    button2.Enabled = true;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread ServerThrd = new Thread(ServerThread);
            ServerThrd.Start();
            Thread isServerAliv = new Thread(() => isServerAlive(ServerThrd));
            isServerAliv.Start();
        }
    }
}
