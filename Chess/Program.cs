using boardgame;
using chess;
using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Clear();
                    UI.PrintBoard(chessMatch.MakeChessPieces());
                    Console.Write("\nSource: ");
                    ChessPosition source = UI.ReadChessPosition();
                    Console.Write("\nTarget: ");
                    ChessPosition target = UI.ReadChessPosition();

                    ChessPiece capturedPiece = chessMatch.PerformChessMove(source, target);
                } catch (ChessException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                } catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }

        }
    }
}
