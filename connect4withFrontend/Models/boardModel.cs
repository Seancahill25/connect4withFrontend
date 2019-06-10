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

        public static bool CheckForWinner(State[,] board)
        {
            for (int row = 5; row >= 0; row--)
            {
                for (int column = 6; column >= 0; column--)
                {
                    State currentCell = board[row, column];
                    if (currentCell == State.X || currentCell == State.O)
                    {
                        if (column >= 3 && currentCell == board[row, column - 1] && currentCell == board[row, column - 2] && currentCell == board[row, column - 3])
                            return true;

                        if (row >= 3 && currentCell == board[row - 1, column] && currentCell == board[row - 2, column] && currentCell == board[row - 3, column])
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
