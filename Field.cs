using System;


namespace tic_tac_toe
{
    public class Field
    {
        public Team team;
        public ConsoleColor color;

        public Field()
        {
            team = Team.None;
            color = ConsoleColor.White;
        }
    }
}
