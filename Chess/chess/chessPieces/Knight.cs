using boardgame;

namespace chess.chessPieces
{
    class Knight : ChessPiece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        private bool CanMove(Position position)
        {
            ChessPiece p = (ChessPiece)Board.GetPiece(position);
            return (p == null || p.Color != Color);
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            //Northwest
            aux.SetValues(Position.Row - 1, Position.Column - 2);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }
            aux.SetValues(Position.Row - 2, Position.Column - 1);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Northeast
            aux.SetValues(Position.Row - 2, Position.Column + 1);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }
            aux.SetValues(Position.Row - 1, Position.Column + 2);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Southeast
            aux.SetValues(Position.Row + 1, Position.Column + 2);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }
            aux.SetValues(Position.Row + 2, Position.Column + 1);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Southwest
            aux.SetValues(Position.Row + 2, Position.Column - 1);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }
            aux.SetValues(Position.Row + 1, Position.Column - 2);
            if ((Board.PositionExists(aux)) && CanMove(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}
