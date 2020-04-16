using boardgame;
using chess.chessPieces;
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
            InitialSetup();
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

        private void InitialSetup()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new Position(2, 1));
            Board.PlacePiece(new King(Board, Color.Black), new Position(0, 4));
            Board.PlacePiece(new King(Board, Color.White), new Position(7, 4));
        }

    }
}
