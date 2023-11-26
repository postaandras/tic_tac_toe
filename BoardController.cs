using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Team[]> rows = generateRows(x, y, board, Player);
            List<Team[]> cols = generateCols(x, y, board, Player);
            Team[] diag1 = generateDial(0, board);
            Team[] diag2 = generateDial(1, board);

            for(int i = 0; i<rows.Count; i++)
            {
                if(checkRow(rows.ElementAt(i), Player))
                {
                    return true;
                }
            }

            for (int i = 0; i < cols.Count; i++)
            {
                if (checkCol(cols.ElementAt(i), Player))
                {
                    return true;
                }
            }

            return checkDiag(diag1, Player) || checkDiag(diag2, Player);
        }


        private static List<Team[]> generateRows(int x, int y, Board board, Team Player)
        {
            List<Team[]> rowList = new List<Team[]>();
            for (int i = x-(board.GetWinSize()-1);
                i<= x; i++){
                if(i>=0 && (i+board.GetWinSize())<= board.GetFields().GetLength(0))
                {
                    //Console.WriteLine("i: "+i);
                    Team[] row = new Team[board.GetWinSize()];
                    for(int j = 0; j<row.Length; j++)
                    {
                        //Console.WriteLine(board.GetFields()[j+i, y].team);
                        row[j] = board.GetFields()[j + i, y].team;
                    }
                    rowList.Add(row);
                }
            }
            return rowList;
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

        private static List<Team[]> generateCols(int x, int y, Board board, Team Player)
        {
            List<Team[]> colList = new List<Team[]>();
            for (int i = y - (board.GetWinSize() - 1);
                i <= y; i++)
            {
                if (i >= 0 && (i + board.GetWinSize()) <= board.GetFields().GetLength(0))
                {
                    
                    //Console.WriteLine("i: "+i);
                    Team[] col = new Team[board.GetWinSize()];
                    //Console.WriteLine(col.Length);
                    for (int j = 0; j < col.Length; j++)
                    {
                        //Console.WriteLine(board.GetFields()[x, j+i].team);
                        col[j] = board.GetFields()[x,j + i].team;
                    }
                    colList.Add(col);
                }
            }
            return colList;
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
