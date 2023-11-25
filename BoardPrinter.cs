using System;


namespace tic_tac_toe
{

    public static class BoardPrinter
    {

        static void resetColor()
        {
            Console.ForegroundColor = tic_tac_toe.Game.baseColor;
        }

        static void setColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void printBoard(Field[,] board)
        {
            WritePerimiter(board.GetLength(0));
            for (int i = board.GetLength(0)-1; i >= 0; i--)
            {
                Console.Write("| ");
                for (int j = 0; j < board.GetLength(0); j++)
                {

                    if (board[j, i].team != Team.None)
                    {
                        setColor(board[j, i].color);
                        Console.Write($"{board[j, i].team}");
                    }
                    else Console.Write(" ");

                    resetColor();
                    Console.Write(" | ");

                }
                Console.WriteLine();
                WritePerimiter(board.GetLength(0));
            }
            
        }

        private static void WritePerimiter(int x)
        {
            
            for(int i = 0; i < x; i++)
            {
                Console.Write("~~~~");
            }
            Console.WriteLine();
        }
    }
}
