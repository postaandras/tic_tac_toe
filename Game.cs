using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace tic_tac_toe
{
    public class Game
    {

        private Team[,] board;
        private Team Player;
        private bool GameOver;

        public bool getGameOver()
        {
            return GameOver;
        }

        public Game()
        {
            board = new Team[3, 3];
            Player = Team.X;
            GameOver = false;
        }
        public void printBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 2; i >= 0; i--)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    if (board[j, i] != Team.None)
                    {
                        Console.Write($"{board[j, i]} | ");
                    }
                    else Console.Write("  | ");
                    
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        public void messager()
        {
            //hát hogy ez csinálja az egész üzenetezést. JAja, és akkor majd ez hív másokat
            //ilyen gyűjtő
            printBoard();
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

        private bool tryToMakeMove(int x, int y)
        {
            if(x<0 || y<0 || y>=3 || x >= 3)
            {
                return false;
            }



            if (board[x, y] != Team.None)
            {
                return false;
            }
            else
            {
                board[x, y] = Player;
                return true;
            }
        }
        private void makeMove()
        {
            
            Console.Write("x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("y: ");
            int y = int.Parse(Console.ReadLine());
            if (!tryToMakeMove(x-1, y-1))
            {
                Console.WriteLine("Invalid move!");
                return;
            }
            if(winCondition(x-1, y-1))
            {
                Console.WriteLine("Game over! The winner is: " + Player);
                GameOver = true;
                return;
            }
            
            switchPlayer();
            return;
        }

        private bool winCondition(int x, int y)
        {
            
            Team[] row = new Team[3] { board[0, y], board[1,y], board[2,y] };
            Team[] col = new Team[3] { board[x, 0], board[x,1], board[x,2] };
            Team[] diag1 = new Team[3] { board[0, 0], board[1, 1], board[2, 2] };
            Team[] diag2 = new Team[3] { board[0, 2], board[1, 1], board[2, 0] };

            if (checkRow(row) || checkCol(col) || checkDiag(diag1) || checkDiag(diag2))
            {
                return true;
            }
            return false;
        }

        private bool checkRow(Team[] row)
        {
            for(int i = 0; i < row.Length; i++) {
                if (row[i] != Player)
                {
                    return false;
                }
            }
            
            return true;
        }

        private bool checkCol(Team[] col)
        {
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i] != Player)
                {
                    return false;
                }
            }

            return true;
        }

        private bool checkDiag(Team[] diag)
        {
            
            for (int i = 0; i < diag.Length; i++)
            {
                if (diag[i] != Player)
                {

                    return false;
                }
            }
            return true;
        }
    }



    public enum Team
    {
        None, X, O
    }
}

