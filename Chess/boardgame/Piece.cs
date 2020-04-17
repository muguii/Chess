namespace boardgame
{
    abstract class Piece
    {
        public Position Position { get; protected internal set; }
        public Board Board { get; protected internal set; }

        public Piece(Board board)
        {
            Position = null;
            Board = board;
        }

        public abstract bool[,] PossibleMoves();

        public bool PossibleMove(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public bool IsThereAnyPossibleMove()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
