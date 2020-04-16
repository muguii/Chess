using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.boardgame
{
    class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }
    }
}
