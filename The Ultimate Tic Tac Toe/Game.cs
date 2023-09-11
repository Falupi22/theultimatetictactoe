using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Ultimate_Tic_Tac_Toe
{
    
    class Game
    {
        int side;
        int sequence;
        public Button[,] buttonBoard; //Board made of buttons - each button represents a cell
        Form form;
        string player1Name, player2Name;
        bool player1Starts = true;
        string turn = "";
        int p1Score = 0, p2Score = 0;
        Label p1s, p2s, turnOf; //Labels for the scoreboard
        public Game(Form form, Label p1s, Label p2s, Label turnOf, string name1, string name2)
        {
            player1Name = name1;
            player2Name = name2;
            this.p1s = p1s;
            this.p2s = p2s;
            this.turnOf = turnOf;
            this.side = StaticData.side;
            this.form = form;
            this.sequence = StaticData.sequence;
            turn = player1Name;
            initializeBoard();
            
            //StaticData.gamePointer = this;
        }
        /// <summary>
        /// Initializes the board. Attaching events to the buttons and adding the buttons to the form
        /// </summary>
        private void initializeBoard()
        {
            buttonBoard = new Button[side, side];
            //Panel boardArea = new Panel();
            //boardArea.Location = new Point(260, 197);
            //boardArea.Size = new Size(300, 300);
            int x = 188, y = 83;
            int bSide = 500 / side; //Determines the size of the button

            //Creating the buttons
            for(int row = 0; row < side; row++)
                for (int column = 0; column < side; column++)
                {
                    Button cell = new Button();
                    cell.Text = "";
                    cell.Font = new Font("Arial", 16, GraphicsUnit.Pixel);
                    cell.Location = new Point(x + bSide * column, y + bSide * row);
                    cell.Size = new Size(bSide, bSide);
                    form.Controls.Add(cell);
                    cell.Click += doTurn; //Attaching the event
                    buttonBoard[row, column] = cell;
                }
            p1s.Text = p1Score.ToString();
            p2s.Text = p2Score.ToString();
            turnOf.Text = turn;
        }

        private void doTurn(object sender, EventArgs e)
        {
            Button current = sender as Button;
            current.Enabled = false;
            //if(player1Starts)
                if (turn.Equals(player1Name))
                    current.Text = "X";
                else
                    current.Text = "O";
            

                if (check_Winning())
                {
                    MessageBox.Show(turn + " Wins!");
                    if (turn.Equals(player1Name))
                        p1Score++;
                    else
                        p2Score++;
                    newGame();
                    return;
                }
                if (isFull())
                {
                    MessageBox.Show("Tie!");
                    newGame();
                    return;
                }
            if (turn.Equals(player1Name))
                turn = player2Name;
            else
                turn = player1Name;
            turnOf.Text = turn;
            
        }

        private bool isFull()
        {
            for (int row = 0; row < side; row++)
                for (int column = 0; column < side; column++)
                    if (buttonBoard[row, column].Text.Equals(""))
                        return false;
            return true;
        }

        public void newGame(bool changeSize = false)
        {
            p1s.Text = p1Score.ToString();
            p2s.Text = p2Score.ToString();
            sequence = StaticData.sequence;
            if (!changeSize)
            {
                //Clears the board
                for (int row = 0; row < side; row++)
                    for (int column = 0; column < side; column++)
                    {
                        buttonBoard[row, column].Text = "";
                        buttonBoard[row, column].Enabled = true;
                    }
                player1Starts = !player1Starts; //Every new game a different player starts
                if (player1Starts)
                    turn = player1Name;
                else
                    turn = player2Name;
                turnOf.Text = turn;
            }
            else
            {
                deleteBoard();
                side = StaticData.side;
                player1Starts = true;
                turn = player1Name;
                initializeBoard();
            }
        }

        private void deleteBoard()
        {
            for (int row = 0; row < side; row++)
                for (int column = 0; column < side; column++)
                {
                    buttonBoard[row, column].Dispose();
                }
        }
        public void resetScore()
        {
            p1Score = 0;
            p2Score = 0;
            p1s.Text = p1Score.ToString();
            p2s.Text = p2Score.ToString();
        }
        private bool check_Winning()
        {
            sequence = StaticData.sequence;
            string current;
            int steps = 0;
            for (int count = 0; count < 2; count++) //Checks for both players (X,O)
            {
                if(count == 0)
                    current = "X";
                else 
                    current = "O";
                //Part 1 - Checking horizontally
                for (int row = 0; row < buttonBoard.GetLength(0); row++)
                    for (int item = 0; item < buttonBoard.GetLength(1); item++)
                        if (buttonBoard[row, item].Text.Equals(current.ToString()))
                        {
                            steps++; //Calculate the same block sequence 
                            if (steps == sequence)
                                return true;
                        }
                        else
                            steps = 0;
                steps = 0;
                //Part 2 - Checking vertically
                for (int column = 0; column < buttonBoard.GetLength(1); column++)
                    for (int row = 0; row < buttonBoard.GetLength(0); row++)
                        if (buttonBoard[row, column].Text.Equals(current.ToString()))
                        {
                            steps++;
                            if (steps == sequence)
                                return true;
                        }
                        else
                            steps = 0;
                steps = 0;

                #region Corrected Code that may be problematic
                //Part 3 - Checking diagonally
                //Part 3.1 - Detecting right crosses - positive incline
                for (int row = sequence - 1; row < buttonBoard.GetLength(0); row++)
                {
                    for (int item = 0; item < buttonBoard.GetLength(1) - (sequence - 1); item++)
                    {
                        for (int cRow = row, cItem = item; cRow > row - sequence; cRow--, cItem++)
                        {
                            //if (cRow == 0 && cItem == 8) MessageBox.Show("Test");
                            if (buttonBoard[cRow, cItem].Text.Equals(current.ToString()))
                            {
                                steps++;

                                if (steps == sequence)
                                    return true;
                            }
                            else
                                steps = 0;
                        }
                        steps = 0;
                    }
                    steps = 0;
                }
                //Part 3.2 - Detecting left crosses - negative incline
                for (int row = 0; row < buttonBoard.GetLength(0) - (sequence - 1); row++)
                {
                    for (int item = 0; item < buttonBoard.GetLength(1) - (sequence - 1); item++)
                    {
                        for (int cRow = row, cItem = item; cRow < row + sequence; cRow++, cItem++)
                        {
                            //if (cRow == 9 && cItem == 9) MessageBox.Show("Test");
                            if (buttonBoard[cRow, cItem].Text.Equals(current.ToString()))
                            {
                                steps++;
                                if (steps == sequence)
                                    return true;
                            }
                            else
                                steps = 0;
                        }
                        steps = 0; 
                    }
                    steps = 0; //May be problematic or insignificant
                }
            }
            return false;   
            #endregion
        }
        
    }
}
