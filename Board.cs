using System;

namespace tic_tac_toe
{
    public class Board
    {
        Field[,] fields;
        int WinSize;

        public int GetWinSize()
        {
            return WinSize;
        }

        public Board(int size, int winSize) {
            WinSize = winSize;
            fields = new Field[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }

        public Board() {
            WinSize = 3;
            fields = new Field[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fields[i, j] = new Field();
                }
            }
        }

        public Field[,] GetFields()
        {
            return fields;
        }
    }
}
