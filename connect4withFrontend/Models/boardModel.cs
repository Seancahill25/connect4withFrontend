using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace connect4withFrontend.Models
{
    public class Board
    {
       public State[,] board = new State[6,7];

        public Board(int rows, int columns)
        {
           for(int row = 0; row < board.GetLength(0); row++)
            {
                for(int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = State.B;
                }
            }
        }


        public enum State
        {
            X,
            O,
            B
        }

        public static bool CheckForHorizontalWinner(State[,] board)
        {
            int Xcounter = 0;
            int Ocounter = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if(board[row,column] == State.X)
                        Xcounter++;

                    if (board[row, column] == State.O)
                        Ocounter++;

                    if (Xcounter >= 1 && board[row, column] == State.O)
                    {
                        Xcounter = 0;
                        Ocounter = 1;
                    }   

                    else if (Ocounter >= 1 && board[row, column] == State.X)
                    {
                        Xcounter = 1;
                        Ocounter = 0;
                    }

                    else if (Xcounter >= 1 && board[row, column] == State.B || Ocounter >= 1 && board[row, column] == State.B)
                    {
                        Xcounter = 0;
                        Ocounter = 0;
                    }

                    if(Xcounter == 4 || Ocounter == 4)
                        return true;
                }
            }
            return false;
        }

        public static bool CheckForVerticalWinner(State[,] board)
        {
            int xCounter = 0;
            int oCounter = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {

                    if (board[row, col] == State.X && board[row + 1, col] == State.X)
                    {
                        xCounter++;
                        int nextRow = 1;
                        while (board[row + nextRow, col] == State.X)
                        {
                            xCounter++;
                            nextRow++;
                            if (xCounter == 4)
                                return true;
                        }
                        xCounter = 0;
                    }
                    if (board[row, col] == State.O && board[row + 1, col] == State.O)
                    {
                        oCounter++;
                        int nextRow = 1;
                        while (board[row + nextRow, col] == State.O)
                        {
                            oCounter++;
                            nextRow++;
                            if (oCounter == 4)
                                return true;
                        }
                        oCounter = 0;
                    }
                }
            }
            return false;
        }

    }
}
