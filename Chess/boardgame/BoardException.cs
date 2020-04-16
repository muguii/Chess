using System;

namespace Chess.boardgame
{
    class BoardException : ApplicationException
    {
        public BoardException(string msg) : base(msg)
        {
        }

    }
}
