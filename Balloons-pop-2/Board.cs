﻿using System;
using System.Text;

namespace BalloonsPops
{
    public class Board
    {
        private const int MaxRowsCount = 20;
        private const int MaxColsCount = 10;
        private int rowsCount;
        private int colsCount;
        private Balloon[,] board;

        public Board(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.board = new Balloon[this.Rows, this.Cols];
            this.Fill();
        }

        public int Rows
        {
            get
            {
                return rowsCount;
            }

            set
            {
                if (value < 1 || value > Board.MaxRowsCount)
                {
                    throw new ArgumentOutOfRangeException("board rows");
                }

                rowsCount = value;
            }
        }


        public int Cols
        {
            get
            {
                return colsCount;
            }

            set
            {
                if (value < 1 || value > Board.MaxColsCount)
                {
                    throw new ArgumentOutOfRangeException("board cols");
                }

                colsCount = value;
            }
        }

        public Balloon this[int row, int col]
        {
            get
            {
                return board[row, col];
            }

            set
            {
                board[row, col] = value;
            }
        }

        public void Reset()
        {
            this.Fill();
        }

        private void Fill()
        {
            int randomValue;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    randomValue = int.Parse(RandomGenerator.GetRandomInt());
                    this[row, col] = new Balloon(randomValue);

                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string leftPadding = new String(' ', 4);

            output.Append(leftPadding);
            for (int col = 0; col < this.Cols; col++)
            {
                output.Append(col + " ");
            }

            output.AppendLine();
            string separator = leftPadding + new string('-', 21);
            output.AppendLine(separator);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(row + " | ");

                for (int col = 0; col < this.Cols; col++)
                {
                    if (board[row, col] == null)
                    {
                        output.Append(". ");
                        continue;
                    }
                    output.Append(board[row, col].Value + " ");
                }
                output.AppendLine("| ");
            }

            output.AppendLine(separator);
            
            return output.ToString();
        }
    }
}
