using boardgame;
using System;
using System.Collections.Generic;
using System.Text;


namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
        }

        public ChessPiece[,] MakeChessPieces()
        {
            ChessPiece[,] mat = new ChessPiece[Board.Rows, Board.Columns];
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = (ChessPiece)Board.GetPiece(i, j);
                }
            }
            return mat;
        }

    }
}
