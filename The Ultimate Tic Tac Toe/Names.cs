using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Ultimate_Tic_Tac_Toe
{
    public partial class Names : Form
    {
        public Names()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(textBox1.Text, textBox2.Text);
            f.Show();
            this.Hide();
        }
    }
}
