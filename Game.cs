using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace tic_tac_toe
{
    public class Game
    {

        private Field[,] board;
        private Team Player;
        private bool GameOver;
        private int NumRounds;
        
        private const ConsoleColor baseColor = ConsoleColor.White;
        private const ConsoleColor xColor = ConsoleColor.Green;
        private const ConsoleColor xWinColor = ConsoleColor.DarkGreen;
        private const ConsoleColor oColor = ConsoleColor.Red;
        private const ConsoleColor oWinColor = ConsoleColor.Red;
        private const ConsoleColor tieColor = ConsoleColor.Yellow;

        public bool getGameOver()
        {
            return GameOver;
        }

        public Game()
        {
            board = new Field[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i,j] = new Field();
                }
            }
            Player = Team.X;
            GameOver = false;
            NumRounds = 0;
        }

        void resetColor()
        {
            Console.ForegroundColor = baseColor;
        }

        void setColor(ConsoleColor color)
        {
            Console.ForegroundColor= color;
        }

        public void printBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 2; i >= 0; i--)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    
                    if (board[j, i].team != Team.None)
                    {
                        setColor(board[j,i].color);
                        Console.Write($"{board[j, i].team}");
                    }
                    else Console.Write(" ");

                    resetColor();
                    Console.Write(" | ");
                    
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }


        public void messager()
        {
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



            if (board[x, y].team != Team.None)
            {
                return false;
            }
            else
            {
                board[x, y].team = Player;
                if (Player == Team.O)
                {
                    board[x, y].color = oColor;
                }
                else
                {
                    board[x,y].color = xColor;
                }
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
                GameOver = true;
                return;
            }

            NumRounds++;

            if (NumRounds == 9)
            {
                GameOver = true;
                Player = Team.None;
                return;
            }
            
            switchPlayer();
            return;
        }

        private bool winCondition(int x, int y)
        {
            
            Team[] row = new Team[3] { board[0, y].team, board[1, y].team, board[2,y].team };
            Team[] col = new Team[3] { board[x, 0].team, board[x, 1].team, board[x,2].team };
            Team[] diag1 = new Team[3] { board[0, 0].team, board[1, 1].team, board[2, 2].team };
            Team[] diag2 = new Team[3] { board[0, 2].team, board[1, 1].team, board[2, 0].team };

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

        public void GameEnder()
        {
            if(Player == Team.None)
            {
                Console.WriteLine("Game over! It's a tie");
                for(int i = 0; i<3; i++)
                {
                    for(int  j = 0; j < 3; j++)
                    {
                        board[i, j].color = tieColor;
                    }
                }

            }
            else
            {
                Console.WriteLine("Game over! The winner is: " + Player);
            }
            printBoard();
            return;

        }
    }



    
}

