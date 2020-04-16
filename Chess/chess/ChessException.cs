using System;

namespace Chess.chess
{
    class ChessException : ApplicationException
    {
        public ChessException(string msg) : base(msg)
        {
        }

    }
}
