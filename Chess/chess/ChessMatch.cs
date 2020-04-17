using boardgame;
using chess.chessPieces;
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

        public ChessPiece PerformChessMove(ChessPosition sourceChessPosition, ChessPosition targetChessPosition)
        {
            Position sourcePosition = sourceChessPosition.ToPosition();
            Position targetPosition = targetChessPosition.ToPosition();
            ValidateSourcePosition(sourcePosition);
            ValidateTargetPosition(sourcePosition, targetPosition);
            Piece capturedPiece = MakeMove(sourcePosition, targetPosition);     
            return (ChessPiece)capturedPiece;
        }

        private Piece MakeMove(Position source, Position target)
        {
            Piece sourcePiece = Board.RemovePiece(source);
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(sourcePiece, target);
            return capturedPiece;
        }

        private void ValidateSourcePosition(Position sourcePosition)
        {
            if (!Board.ThereIsAPiece(sourcePosition))
            {
                throw new ChessException("There is no piece in source position.\n");
            }
            if (!Board.GetPiece(sourcePosition).IsThereAnyPossibleMove())
            {
                throw new ChessException("There is no possible movements for this piece.\n");
            }
        }

        private void ValidateTargetPosition(Position sourcePosition, Position targetPosition)
        {        
            if (!Board.GetPiece(sourcePosition).PossibleMove(targetPosition))
            {
                throw new ChessException("The chosen piece can not move to the target position.\n");
            }
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
