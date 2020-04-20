using boardgame;

namespace chess
{
    abstract class ChessPiece : Piece
    {
        public Color Color { get; private set; }
        public int MoveCount { get; set; }

        public ChessPiece(Board board, Color color) : base(board)
        {
            Color = color;
            MoveCount = 0;
        }

        public void IncreaseMoveCount()
        {
            MoveCount++;
        }

        public void DecreaseMoveCount()
        {
            MoveCount--;
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
