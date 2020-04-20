using boardgame;

namespace chess.chessPieces
{
    class Pawn : ChessPiece
    {

        private ChessMatch ChessMatch;

        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            if (Color == Color.White)
            {
                //Above(1 square)
                aux.SetValues(Position.Row - 1, Position.Column);
                if (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //Above(2 square)
                aux.SetValues(Position.Row - 2, Position.Column);
                Position aux2 = new Position(Position.Row - 1, Position.Column);
                if (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux) && Board.PositionExists(aux2) && !Board.ThereIsAPiece(aux2) && MoveCount == 0)
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //Northwest
                aux.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //Northeast
                aux.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //SpecialMove EnPassant (WHITE)
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentePiece(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column ] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentePiece(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                //Below(1 square)
                aux.SetValues(Position.Row + 1, Position.Column);
                if (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //elow(2 square)
                aux.SetValues(Position.Row + 2, Position.Column);
                Position aux2 = new Position(Position.Row + 1, Position.Column);
                if (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux) && Board.PositionExists(aux2) && !Board.ThereIsAPiece(aux2) && MoveCount == 0)
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //Southwest
                aux.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //Southeast
                aux.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
                {
                    mat[aux.Row, aux.Column] = true;
                }


                //SpecialMove EnPassant (BLACK)
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentePiece(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentePiece(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
