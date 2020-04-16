using boardgame;

namespace chess
{
    class ChessPiece : Piece
    {

        public Color Color { get; private set; }

        public ChessPiece(Color color, Board board) : base(board)
        {
            Color = color;
        }


    }
}
