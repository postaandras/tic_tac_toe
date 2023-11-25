using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace tic_tac_toe
{
    public class Game
    {

        private Board board;
        private Team Player;
        private bool GameOver;
        private int NumRounds;
        private int BoardSize;
        
        public const ConsoleColor baseColor = ConsoleColor.White;
        public const ConsoleColor tieColor = ConsoleColor.Yellow;

        public bool getGameOver()
        {
            return GameOver;
        }

        public Game()
        {
            BoardSize = 4;
            board = new Board(BoardSize);
            Player = Team.X;
            GameOver = false;
            NumRounds = 0;
            
        }

        public void messager()
        {
            BoardPrinter.printBoard(board.GetFields());
            writeCurrentPlayer();
            makeMove();
        }
    
        private void writeCurrentPlayer()
        {
            Console.WriteLine("Current player is <" + Player + ">. Make a move!");
        }

        private void switchPlayer()
        {
            Player = (Player == Team.X)? Team.O : Team.X;
        }

        private void makeMove()
        {
            
            Console.Write("x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            int y = int.Parse(Console.ReadLine());
            if (!BoardController.tryToMakeMove(x-1, y-1, Player, board))
            {
                Console.WriteLine("Invalid move!");
                return;
            }
            if(BoardController.winCondition(x-1, y-1, Player, board))
            {
                GameOver = true;
                return;
            }

            NumRounds++;

            if (NumRounds == Math.Pow(BoardSize,2))
            {
                GameOver = true;
                Player = Team.None;
                return;
            }
            
            switchPlayer();
            return;
        }

        
        public void GameEnder()
        {
            if(Player == Team.None)
            {
                Console.WriteLine("Game over! It's a tie");
                for(int i = 0; i<BoardSize; i++)
                {
                    for(int  j = 0; j < BoardSize; j++)
                    {
                        board.GetFields()[i, j].color = tieColor;
                    }
                }

            }
            else
            {
                Console.WriteLine("Game over! The winner is: " + Player);
            }
            BoardPrinter.printBoard(board.GetFields());
            return;

        }
    }



    
}

