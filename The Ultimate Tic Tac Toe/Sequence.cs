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
    public partial class Sequence : Form
    {
        public Sequence()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(numericUpDown1.Value);
            StaticData.sequence = s;
            //MessageBox.Show("The sequence will be modified after the game ends or after changing the board size");
            this.Close();
        }
    }
}
