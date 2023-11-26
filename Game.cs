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
        private int WinSize;
        private bool shutDown;
        
        public const ConsoleColor baseColor = ConsoleColor.White;
        public const ConsoleColor tieColor = ConsoleColor.Yellow;

        public bool getGameOver()
        {
            return GameOver;
        }

        public int getWinSize()
        {
            return WinSize;
        }

        public bool getShutdown()
        {
            return shutDown;
        }

        public Game(int BoardSize, int WinSize)
        {
            this.BoardSize = BoardSize;
            this.WinSize = WinSize;
            board = new Board(BoardSize, WinSize);
            Player = Team.X;
            GameOver = false;
            NumRounds = 0;
            shutDown = false;
        }

        public Game()
        {
            board = new Board();
            Player = Team.X;
            GameOver = false;
            NumRounds = 0;
            shutDown = false;
        }

        public static Game gameInitializer()
        {
            try
            {
                Console.Write("Size of the board:");
                int BoardSize = int.Parse(Console.ReadLine());
                Console.Write("Number of sigils needed to win:");
                int WinSize = int.Parse(Console.ReadLine());

                if(BoardSize < 4 || WinSize < 4)
                {
                    throw new ArithmeticException("The number of marks needed for win and the size of the board" +
                        "must be at least 4!\n");

                }
                if (WinSize >= BoardSize)
                {
                    throw new ArithmeticException("The number of marks needed for win must be" +
                        "smaller than the size of the board!\n");
                }

                return new Game(BoardSize, WinSize);

            }
            catch(ArithmeticException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bad format! You can only use integers.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return gameInitializer();
            
        }

        public void InputHandler()
        {
            Console.WriteLine("Press 'q' to quit, or 'c' to start the game again");
            char Char = Console.ReadKey().KeyChar;
            switch(Char)
            {
                case 'q':
                    shutDown = true;
                    break;
                case 'c':
                    shutDown= false;
                    break;
                default:
                    InputHandler();
                    break;
            }
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

