using boardgame;

namespace chess
{
    class ChessPiece : Piece
    {

        public Color Color { get; private set; }

        public ChessPiece(Board board, Color color) : base(board)
        {
            Color = color;
        }


    }
}
