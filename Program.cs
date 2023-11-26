using System;
namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Tic Tac Toe";
            Game game = Game.gameInitializer();
            char k;
            do
            {
                game.messager();
                k = Console.ReadKey().KeyChar;
                
            }
            while(k != 'q' && !game.getGameOver());
            if(game.getGameOver() )
            {
                game.GameEnder();
            }

            game.InputHandler();

            if(game.getShutdown() ) {
                return;
            }
            
            Main(args);
            
        }

    }
}
