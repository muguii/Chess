using boardgame;
using chess.chessPieces;
using Chess.chess;
using System;

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

        private void PlaceNewPiece(char column, int row, ChessPiece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
        }

        private void InitialSetup()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 8, new King(Board, Color.Black));
        }

    }
}
