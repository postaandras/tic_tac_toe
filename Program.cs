using System;
namespace tic_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tic Tac Toe";
            Game game = new Game();
            char k;
            do
            {
                game.messager();
                k = Console.ReadKey().KeyChar;
                
            }
            while(k != 'q' && !game.getGameOver());
            game.GameEnder();
            Console.ReadKey();
            
        }

    }
}
