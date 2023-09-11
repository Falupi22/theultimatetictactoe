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
    public partial class Side : Form
    {
        public Side()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(numericUpDown1.Value);
            if (s < 10 || s > 20)
                s = 10;
            StaticData.side = s;
            StaticData.gamePointer.newGame(true);
            this.Close();
        }
    }
}
