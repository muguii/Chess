using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.boardgame
{
    class Piece
    {
        public Position Position { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board)
        {
            Position = null;
            Board = board;
        }
    }
}
