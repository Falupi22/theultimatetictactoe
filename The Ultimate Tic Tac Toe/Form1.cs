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
    public partial class Form1 : Form
    {
        Game game;
        string name1, name2;
        public Form1(string name1, string name2)
        {
            this.name1 = name1;
            this.name2 = name2;
            InitializeComponent();
            label2.Text = name1 + " -X";
            label3.Text = name2 + " -O";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(this,P1S, P2S, TurnOf, name1, name2);
            StaticData.gamePointer = game;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X.ToString() + "," + e.Y.ToString());
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.newGame(true);
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.resetScore();
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void modifySequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sequence s = new Sequence();
            s.ShowDialog();
        }

        private void modifyBoardSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Side s = new Side();
            s.ShowDialog();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

    }
}
