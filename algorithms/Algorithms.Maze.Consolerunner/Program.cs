using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maze.Consolerunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new ConcreteMaze(4, 4);
            

            maze.ConnectTwoSquare(new Coordinates(0,0), new Coordinates(1,1));
            maze.PrintMaze();
        }
    }
}
