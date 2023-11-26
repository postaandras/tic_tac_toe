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
            List<Team[]> diags1 = generateDial(x, y, 0, board);
            List<Team[]> diags2 = generateDial(x, y, 1, board);

            for(int i = 0; i<rows.Count; i++)
            {
                if(checkMark(rows.ElementAt(i), Player))
                {
                    return true;
                }
            }

            for (int i = 0; i < cols.Count; i++)
            {
                if (checkMark(cols.ElementAt(i), Player))
                {
                    return true;
                }
            }

            for (int i = 0; i < diags1.Count; i++)
            {
                if (checkMark(diags1.ElementAt(i), Player))
                {
                    return true;
                }
            }

            for (int i = 0; i < diags2.Count; i++)
            {
                if (checkMark(diags2.ElementAt(i), Player))
                {
                    return true;
                }
            }



            return false;
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

        private static List<Team[]> generateDial(int x, int y, int orient, Board board)
        {
            List<Team[]> dials = new List<Team[]>();
            switch (orient)
            {
                case 0:
                    
                    for (int i = y - (board.GetWinSize() - 1);
                        i <= y; i++)
                    {
                        if(i>= 0 && (i + board.GetWinSize()) <= board.GetFields().GetLength(0))
                        {
                            if (!((x + (i - y)) < 0 ||
                                (x + (i - y)) + board.GetWinSize()>board.GetFields().GetLength(0)))
                            {
                                Team[] innerTeam = new Team[board.GetWinSize()];
                                for(int j = 0; j<board.GetWinSize(); j++)
                                {
                                    innerTeam[j] = board.GetFields()[(j + x + (i - y)), (i + j)].team;
                                }
                                dials.Add(innerTeam);
                            }                         
                        }
                        
                    }
                    break;
                case 1:
                    for (int i = y + (board.GetWinSize() - 1);
                       i >= y; i--)
                    {
                        
                        if (i < board.GetFields().GetLength(0) &&
                            ((i+1-board.GetWinSize())>=0))
                        {
                            
                            if(((x + (y - i)) >= 0)&&(((x + (y - i)) + board.GetWinSize())<=board.GetFields().GetLength(0)))
                            {
                                //Console.WriteLine(i);
                                Team[] innerTeam = new Team[board.GetWinSize()];
                                for (int j = 0; j < board.GetWinSize(); j++)
                                {
                                    //Console.WriteLine(" x:"+ (j + x + (y - i)) + " y:"+ (i-j));
                                    innerTeam[j] = board.GetFields()[(j + x + (y-i)), (i-j)].team;
                                }
                                dials.Add(innerTeam);
                            }
                        }
                        
                    }
                    break;
                default:
                    break;
                    
            }
            return dials;
            

        }

        private static bool checkMark(Team[] collection, Team Player)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] != Player)
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
