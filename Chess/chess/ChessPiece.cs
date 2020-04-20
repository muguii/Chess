using boardgame;

namespace chess
{
    abstract class ChessPiece : Piece
    {

        public Color Color { get; private set; }

        public ChessPiece(Board board, Color color) : base(board)
        {
            Color = color;
        }

        public ChessPosition GetChessPosition()
        {
            return ChessPosition.FromPosition(Position);
        }

        protected internal bool IsThereOpponentePiece(Position position)
        {
            ChessPiece p = (ChessPiece)Board.GetPiece(position);
            return (p != null && p.Color != Color);
        }
    }
}
