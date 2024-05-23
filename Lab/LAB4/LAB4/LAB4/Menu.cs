using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bai1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai1 bai1 = new Bai1();
            bai1.ShowDialog();
            bai1 = null;
            this.Show();
        }

        private void bai2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai2 bai2 = new Bai2();
            bai2.ShowDialog();
            bai2 = null;
            this.Show();
        }

        private void bai3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai3 bai3 = new Bai3();
            bai3.ShowDialog();
            bai3 = null;
            this.Show();
        }

        private void bai4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai4 bai4 = new Bai4();
            bai4.ShowDialog();
            bai4 = null;
            this.Show();
        }
    }
}
