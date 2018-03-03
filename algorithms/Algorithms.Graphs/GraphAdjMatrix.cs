using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class GraphAdjMatrix : IGraph
    {
        private List<int> Vertices { get; set; }
        private int[,] adjMatrix;
        public GraphAdjMatrix(int[] vertices)
        {
            Vertices = vertices.ToList();

            adjMatrix = new int[NumberOfVertices, NumberOfVertices];
        }

        public int NumberOfVertices => Vertices.Count;
        public int NumberOfEdges { get; set; }
        public void AddVertex()
        {
            //adds next Vertices 
            Vertices.Add(NumberOfVertices + 1);

            //Do we need to increase length of yes then make it twice the size
            if (adjMatrix.GetUpperBound(1) < NumberOfVertices)
            {
                var temp = new int[NumberOfVertices * 2, NumberOfVertices * 2];
                for (int i = 0; i < NumberOfVertices - 1; i++)
                {
                    for (int j = 0; j < NumberOfVertices - 1; j++)
                    {
                        temp[i, j] = adjMatrix[i, j];
                    }
                }
                adjMatrix = temp;
            }
        }

        //This add method works for directed graph where firstVertex is the starting node
        //and secondVertex is the ending node
        public void AddEdge(int firstVertex, int secondVertex)
        {
            if (firstVertex > Vertices.Count || secondVertex > Vertices.Count)
            {
                throw new InvalidOperationException();
            }

            adjMatrix[firstVertex, secondVertex] = 1;
        }

        public List<int> GetNeighbours(int vertex)
        {
            var neighbours = new List<int>();
            for (int i = 0; i < NumberOfVertices; i++)
            {
                if (adjMatrix[vertex, i] == 1)
                {
                    neighbours.Add(i);
                }
            }

            return neighbours;
        }
    }
}