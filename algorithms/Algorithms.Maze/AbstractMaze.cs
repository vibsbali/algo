using System;

namespace Algorithms.Maze
{
    public abstract class AbstractMaze
    {
        public virtual int Rows { get; }
        public virtual int Columns { get; }
        public virtual int[,] Maze { get; }

        protected AbstractMaze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Maze = new int[Rows,Columns];
        }

        public virtual void PrintMaze()
        {
            for (int i = 0; i < Rows; i++)
            {   
               
                for (int j = 0; j < Columns; j++)
                {
                    if (Maze.AreConnected(i, j))
                    {
                        Console.Write("|#|");
                    }
                    else
                    {
                        Console.Write("| |");
                    }
                }
                Console.WriteLine();
            }
        }

        public virtual void ConnectTwoSquare(Coordinates firstVertex, Coordinates secondVertex)
        {
            //because of zero based indexing
            if (firstVertex.X >= Rows || secondVertex.X >= Rows  || firstVertex.Y >= Columns || secondVertex.Y >= Columns)
            {
                throw new InvalidOperationException();
            }

            Maze[firstVertex.X, firstVertex.Y] = 1;
            Maze[secondVertex.X, secondVertex.Y] = 1;
        }
    }

    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ConcreteMaze : AbstractMaze
    {
        public ConcreteMaze(int rows, int columns) : base(rows, columns)
        {
        }


    }
}
