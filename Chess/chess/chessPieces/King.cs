using boardgame;

namespace chess.chessPieces
{
    class King : ChessPiece
    {
        private ChessMatch ChessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        private bool CanMove(Position position)
        {
            ChessPiece p = (ChessPiece)Board.GetPiece(position);
            return (p == null || p.Color != Color);
        }

        private bool TestRookCastling(Position position)
        {
            ChessPiece p = (ChessPiece)Board.GetPiece(position);
            return (p != null && p is Rook && p.Color == Color && p.MoveCount == 0);
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0,0);

            //Above
            aux.SetValues(Position.Row - 1, Position.Column);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Northeast
            aux.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Right
            aux.SetValues(Position.Row, Position.Column + 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Southeast
            aux.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Below
            aux.SetValues(Position.Row + 1, Position.Column);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //South-west
            aux.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Left
            aux.SetValues(Position.Row, Position.Column - 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Northwest
            aux.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.PositionExists(aux) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //SpecialMove Castling
            if (MoveCount == 0 && !ChessMatch.Check)
            {
                //SpecialMove KingSide Rook
                Position positionRook1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookCastling(positionRook1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }

                //SpecialMove QueenSide Rook
                Position positionRook2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookCastling(positionRook2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
