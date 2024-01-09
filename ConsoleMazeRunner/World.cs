using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace ConsoleMazeRunner
{
    public class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid) 
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);

        }
        public void Draw()
        {
            for (int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Cols; j++) 
                {
                    string element = Grid[i, j];
                    SetCursorPosition(j, i+2);
                    Write(element);
                }
            }
        }
        public string GetElementAt(int x, int y) 
        {
            return Grid[y, x];
        }

        public bool IsValid(int x, int y)
        {
            if(x < 0 || y < 0 || x >= Cols || y >= Rows) 
            { 
                return false;
            }
            //Espacio " " y X son espacios válidos
            return Grid[y, x] ==" " || Grid[y,x] == "X";
        }

    }
}
