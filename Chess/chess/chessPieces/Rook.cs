using boardgame;
using chess;

namespace chess.chessPieces
{
    class Rook : ChessPiece
    {

        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position aux = new Position(0, 0);

            //Above
            aux.SetValues(Position.Row - 1, Position.Column);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Row--;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Right
            aux.SetValues(Position.Row, Position.Column + 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Column++;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Below
            aux.SetValues(Position.Row + 1, Position.Column);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Row++;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            //Left
            aux.SetValues(Position.Row, Position.Column - 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Column--;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
