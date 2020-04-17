using boardgame;

namespace chess
{
    class ChessException : BoardException
    {
        public ChessException(string msg) : base(msg)
        {
        }

    }
}
