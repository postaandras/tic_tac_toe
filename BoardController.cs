using System;
using System.Media;

namespace tic_tac_toe
{
    public static class BoardController
    {

        public const ConsoleColor xColor = ConsoleColor.Green;
        public const ConsoleColor oColor = ConsoleColor.Red;
        public const ConsoleColor oWinColor = ConsoleColor.DarkRed;
        public const ConsoleColor xWinColor = ConsoleColor.DarkGreen;

        public static bool tryToMakeMove(int x, int y, Team Player, Board board)
        {
            if (x < 0 || y < 0 ||
                y >= board.GetFields().GetLength(0) ||
                x >= board.GetFields().GetLength(0))
            {
                return false;
            }


            
            if (board.GetFields()[x, y].team != Team.None)
            {
                return false;
            }
            else
            {
                UpdateField(x, y, Player, board);
                return true;
            }
        }

        private static void UpdateField(int x, int y, Team Player, Board board)
        {
            board.GetFields()[x, y].team = Player;
            board.GetFields()[x, y].color = Player==Team.O ? oColor : xColor;
        }

        public static bool winCondition(int x, int y, Team Player, Board board)
        {
            Team[] row = generateRow(y, board);
            Team[] col = generateCol(x, board);
            Team[] diag1 = generateDial(0, board);
            Team[] diag2 = generateDial(1, board);

            return (checkRow(row, Player) || checkCol(col, Player)
                || checkDiag(diag1, Player) || checkDiag(diag2, Player));
        }


        private static Team[] generateRow(int y, Board board)
        {
            Team[] row = new Team[board.GetFields().GetLength(0)];
            for(int i = 0; i< board.GetFields().GetLength(0); i++)
            {
                row[i] = board.GetFields()[i,y].team;
            }
            return row;
        }

        private static bool checkRow(Team[] row, Team Player)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != Player)
                {
                    return false;
                }
            }
            return true;
        }

        private static Team[] generateCol(int x, Board board)
        {
            Team[] col = new Team[board.GetFields().GetLength(0)];
            for (int i = 0; i < board.GetFields().GetLength(0); i++)
            {
                col[i] = board.GetFields()[x, i].team;
            }
            return col;
        }


        private static bool checkCol(Team[] col, Team Player)
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

        private static Team[] generateDial(int orient, Board board)
        {
            Team[] dial = new Team[board.GetFields().GetLength(0)];
            switch (orient)
            {
                case 0:
                    for(int i = 0; i< board.GetFields().GetLength(0); i++)
                    {
                        dial[i] = board.GetFields()[i,i].team;
                    }
                    break;
                case 1:
                    for (int i = board.GetFields().GetLength(0)-1; i >= 0; i--)
                    {
                        dial[i] = board.GetFields()[i, board.GetFields().GetLength(0)-1-i].team;
                    }
                    break;
                default:
                    break;
                    
            }
            return dial;
            

        }

        private static bool checkDiag(Team[] diag, Team Player)
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
}
