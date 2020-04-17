using System;

namespace boardgame
{
    class BoardException : ApplicationException
    {
        public BoardException(string msg) : base(msg)
        {
        }

    }
}
