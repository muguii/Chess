﻿using chess;
using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessMatch chessMatch = new ChessMatch();
            List<ChessPiece> capturedPieces = new List<ChessPiece>();
            while (!chessMatch.CheckMate)
            {
                try
                {
                    Console.Clear();
                    UI.PrintMatch(chessMatch, capturedPieces);
                    Console.Write("\nSource: ");
                    ChessPosition source = UI.ReadChessPosition();
                    bool[,] possibleMoves = chessMatch.PossibleMoves(source);
                    Console.Clear();
                    UI.PrintBoard(chessMatch.MakeChessPieces(), possibleMoves);
                    Console.Write("\nTarget: ");
                    ChessPosition target = UI.ReadChessPosition();
                   
                    ChessPiece capturedPiece = chessMatch.PerformChessMove(source, target);
                    if (capturedPiece != null)
                    {
                        capturedPieces.Add(capturedPiece);
                    }

                    if (chessMatch.Promoted != null)
                    {
                        Console.Write("Enter piece for promotion (B/N/R/Q): ");
                        string type = Console.ReadLine().ToUpper();
                        while (!type.Equals("B") && !type.Equals("N") && !type.Equals("R") && !type.Equals("Q"))
                        {
                            Console.Write("Invalid value! Enter piece for promotion (B/N/R/Q): ");
                            type = Console.ReadLine().ToUpper();
                        }
                        chessMatch.ReplacePromotedPiece(type);
                    }
                } catch (ChessException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                } catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            UI.PrintMatch(chessMatch, capturedPieces);
        }
    }
}
