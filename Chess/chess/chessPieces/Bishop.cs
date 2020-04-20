using boardgame;

namespace chess.chessPieces
{
    class Bishop : ChessPiece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            Position aux = new Position(0, 0);

            //Northwest
            aux.SetValues(Position.Row - 1, Position.Column - 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux)) {
                mat[aux.Row, aux.Column] = true;
                aux.Row--;
                aux.Column--;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Northeast
            aux.SetValues(Position.Row - 1, Position.Column + 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Row--;
                aux.Column++;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Southeast
            aux.SetValues(Position.Row + 1, Position.Column + 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Row++;
                aux.Column++;
            }
            if (Board.PositionExists(aux) && IsThereOpponentePiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
            }


            //Southwest
            aux.SetValues(Position.Row + 1, Position.Column - 1);
            while (Board.PositionExists(aux) && !Board.ThereIsAPiece(aux))
            {
                mat[aux.Row, aux.Column] = true;
                aux.Row++;
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
            return "B";
        }
    }
}
