using System;

namespace tic_tac_toe
{
    public class Board
    {
        Field[,] fields;

        public Board(int size) {
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
