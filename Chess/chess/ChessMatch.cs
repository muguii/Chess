using boardgame;
using chess.chessPieces;
using System;
using System.Collections.Generic;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public List<Piece> PiecesOnTheBoard { get; private set; }
        public List<Piece> CapturedPieces { get; private set; }
        public bool Check { get; private set; }
        public bool CheckMate { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PiecesOnTheBoard = new List<Piece>();
            CapturedPieces = new List<Piece>();
            Check = false;
            CheckMate = false;
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

        public ChessPiece PerformChessMove(ChessPosition sourceChessPosition, ChessPosition targetChessPosition)
        {
            Position sourcePosition = sourceChessPosition.ToPosition();
            Position targetPosition = targetChessPosition.ToPosition();
            ValidateSourcePosition(sourcePosition);
            ValidateTargetPosition(sourcePosition, targetPosition);
            Piece capturedPiece = MakeMove(sourcePosition, targetPosition);

            if (TestCheck(CurrentPlayer))
            {
                UndoMove(sourcePosition, targetPosition, capturedPiece);
                throw new ChessException("You cant put yourself in check.\n");
            }

            Check = ((TestCheck(OpponentColor(CurrentPlayer))) ? true : false);

            if (TestCheckMate(OpponentColor(CurrentPlayer))) {
                CheckMate = true;
            } else {
                NextTurn();
            }

            return (ChessPiece)capturedPiece;
        }

        private Piece MakeMove(Position source, Position target)
        {
            ChessPiece sourcePiece = (ChessPiece)Board.RemovePiece(source);
            sourcePiece.IncreaseMoveCount();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(sourcePiece, target);

            if (capturedPiece != null)
            {
                PiecesOnTheBoard.Remove(capturedPiece);
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        private void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            ChessPiece p = (ChessPiece)Board.RemovePiece(target);
            p.DecreaseMoveCount();
            Board.PlacePiece(p, source);

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                CapturedPieces.Remove(capturedPiece);
                PiecesOnTheBoard.Add(capturedPiece);
            }
        }

        private void ValidateSourcePosition(Position sourcePosition)
        {
            if (!Board.ThereIsAPiece(sourcePosition))
            {
                throw new ChessException("There is no piece in source position.\n");
            }
            if (CurrentPlayer != ((ChessPiece)Board.GetPiece(sourcePosition)).Color)
            {
                throw new ChessException("The piece chosen is not yours.\n");
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

        private void NextTurn()
        {
            Turn++;
            CurrentPlayer = (CurrentPlayer == Color.White ? Color.Black : Color.White);
        }

        public bool[,] PossibleMoves(ChessPosition sourceChessPosition)
        {
            Position sourcePosition = sourceChessPosition.ToPosition();
            ValidateSourcePosition(sourcePosition);
            return Board.GetPiece(sourcePosition).PossibleMoves();
        }

        private Color OpponentColor(Color color)
        {           
            return (color == Color.White ? Color.Black : Color.White);
        }

        private ChessPiece GetKing(Color color)
        {
            List<Piece> auxList = PiecesOnTheBoard.FindAll(x => ((ChessPiece)x).Color == color);
            foreach (Piece obj in auxList)
            {
                if (obj is King)
                    {
                    return (ChessPiece)obj;
                    }
            }
            throw new ApplicationException("There is no " + color + " king on the board.\n");
        }

        private bool TestCheck(Color color)
        {
            Position KingPosition = GetKing(color).GetChessPosition().ToPosition(); // GetKing(color).Position; -> Não seria mais pratico?
            List<Piece> opponentPieces = PiecesOnTheBoard.FindAll(x => ((ChessPiece)x).Color == OpponentColor(color));
            foreach (Piece obj in opponentPieces)
            {
                bool[,] mat = obj.PossibleMoves();
                if (mat[KingPosition.Row, KingPosition.Column])
                {
                    return true;
                }
            }
            return false;
        }

        private bool TestCheckMate(Color color)
        {
            if (!TestCheck(color))
            {
                return false;
            }

            List<Piece> pieces = PiecesOnTheBoard.FindAll(x => ((ChessPiece)x).Color == color);
            foreach (Piece obj in pieces)
            {
                bool[,] mat = obj.PossibleMoves();
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (mat[i, j])
                        {
                            Position source = ((ChessPiece)obj).GetChessPosition().ToPosition();
                            Position target = new Position(i, j);
                            Piece capturedPiece = MakeMove(source, target);
                            bool testCheck = TestCheck(color);
                            UndoMove(source, target, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }               
            }

            return true;
        }

        private void PlaceNewPiece(char column, int row, ChessPiece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            PiecesOnTheBoard.Add(piece);
        }

        private void InitialSetup()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));
            /*PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 1, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 1, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 1, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 1, new Pawn(Board, Color.White));*/

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Rook(Board, Color.Black));
            /*PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 8, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 8, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 8, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 8, new Pawn(Board, Color.Black));*/
        }
    }
}
