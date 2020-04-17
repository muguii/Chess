using boardgame;
using chess;

namespace chess.chessPieces
{
    class King : ChessPiece
    {

        public King(Board board, Color color) : base(board, color)
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

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }

    }
}
