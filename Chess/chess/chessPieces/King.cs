using boardgame;
using chess;

namespace chess.chessPieces
{
    class King : ChessPiece
    {

        public King(Board board, Color color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];
            return mat;
        }

        public override string ToString()
        {
            return "K";
        }

    }
}
