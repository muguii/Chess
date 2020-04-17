using chess;
using System;

namespace Chess
{
    class UI
    {
        //Console.ResetColor();
	    //Console.BackgroundColor = ConsoleColor.Blue;
	    //Console.ForegroundColor = ConsoleColor.Blue;

        

        public static ChessPosition ReadChessPosition()
        {
            try
            {
                string aux = Console.ReadLine();
                char column = char.Parse(aux.Substring(0, 1));
                int row = int.Parse(aux.Substring(1));
                return new ChessPosition(column, row);
            } catch (ApplicationException e)
            {
                throw new ArgumentException("Error reading the Chess Position. Valid values are a1 to h8.");
            }

        }

        public static void PrintBoard(ChessPiece[,] chessPieces)
        {
            for (int i = 0; i < chessPieces.GetLength(0); i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessPieces.GetLength(1); j++)
                {
                    PrintPiece(chessPieces[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        private static void PrintPiece(ChessPiece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(piece + " ");
                    Console.ResetColor();
                } else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(piece + " ");
                    Console.ResetColor();
                }
            }
        }

    }
}
