﻿using chess;
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
                throw new ArgumentException("Error reading the ChessPosition. Valid values are a1 to h8.");
            }

        }

        public static void PrintMatch(ChessMatch chessMatch)
        {
            PrintBoard(chessMatch.MakeChessPieces());
            Console.WriteLine("\nTurn: " + chessMatch.Turn);
            Console.WriteLine("Waiting Player: " + chessMatch.CurrentPlayer);
        }

        public static void PrintBoard(ChessPiece[,] chessPieces)
        {
            for (int i = 0; i < chessPieces.GetLength(0); i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessPieces.GetLength(1); j++)
                {
                    PrintPiece(chessPieces[i, j], false);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(ChessPiece[,] chessPieces, bool[,] possibleMoves)
        {
            for (int i = 0; i < chessPieces.GetLength(0); i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < chessPieces.GetLength(1); j++)
                {
                    PrintPiece(chessPieces[i, j], possibleMoves[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        private static void PrintPiece(ChessPiece piece, bool background)
        {
            if (background)
            {
                Console.BackgroundColor = ConsoleColor.Blue;               
            }
            if (piece == null)
            {
                Console.Write("- ");
                Console.ResetColor();
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
