using boardgame;
using chess;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chM = new ChessMatch();
            UI.PrintBoard(chM.MakeChessPieces());

        }
    }
}
