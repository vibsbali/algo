using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maze
{
    public static class MazeExtensionMethods
    {
        public static bool AreConnected(this int[,] maze, int rowIndex, int colIndex)
        {
            if (maze[rowIndex, colIndex] == 1)
            {
                return true;
            }

            return false;
        }
    }
}
