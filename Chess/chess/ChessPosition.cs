using boardgame;

namespace chess
{
    class ChessPosition
    {
        public char Column { get; private set; }
        public int Row { get; private set; }

        public ChessPosition(char column, int row)
        {
            if (column < 'a' || column > 'h' || row < 1 || row > 8)
            {
                throw new ChessException("Error instantiating ChessPosition. Valid values are a1 to h8.\n");
            }
            Column = column;
            Row = row;
        }

        protected internal Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        protected internal static ChessPosition FromPosition(Position position)
        {
            return new ChessPosition((char)('a' + position.Column), 8 - position.Row);
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
