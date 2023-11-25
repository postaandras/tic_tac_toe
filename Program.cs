using System;
namespace tic_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            char k;
            do
            {

                game.messager();
                

                k = Console.ReadKey().KeyChar;
            }
            while(k != 'q' && !game.getGameOver());
            
        }

    }
}
