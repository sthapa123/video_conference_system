using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace videoPro
{
    public partial class Choose_Peer : Form
    {
        public static int choosenPeer ; 
        public Choose_Peer()
        {
            InitializeComponent();
        }

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            choosenPeer = 1;
            Form1 startSession1 = new Form1();
            this.Hide();
            startSession1.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            choosenPeer = 2;
            Form1 startSession2 = new Form1();
            this.Hide();
            startSession2.Show();
        }

        private void Choose_Peer_Load(object sender, EventArgs e)
        {

        }
    }
}
