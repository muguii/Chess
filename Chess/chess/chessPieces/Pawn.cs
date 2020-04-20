using boardgame;

namespace chess.chessPieces
{
    class Pawn : ChessPiece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
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
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
