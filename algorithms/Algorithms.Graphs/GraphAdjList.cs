using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class GraphAdjList : IGraph
    {
        private List<int> Vertices { get; }
        private Dictionary<int, List<int>> adjList;
        public GraphAdjList(int[] vertices)
        {
            Vertices = vertices.ToList();
            adjList = new Dictionary<int, List<int>>();
            foreach (var vertex in Vertices)
            {
                adjList[vertex] = new List<int>();
            }
        }

        public int NumberOfVertices => Vertices.Count;
        public int NumberOfEdges { get; set; }

        //The assumption is that the vertex will be added one next to the existing sequence
        public void AddVertex()
        {
            //IMPORTANT - zero indexing means Vertices.Add is done after
            //the adjacency list' index is instantiated
            adjList.Add(Vertices.Count, new List<int>());
            Vertices.Add(NumberOfVertices + 1);
        }

        //This add method works for directed graph where firstVertex is the starting node
        //and secondVertex is the ending node
        public void AddEdge(int firstVertex, int secondVertex)
        {
            if (firstVertex > Vertices.Count || secondVertex > Vertices.Count)
            {
                throw new InvalidOperationException();
            }

            //If not already in the list
            if (!adjList[firstVertex].Contains(secondVertex))
            {
                adjList[firstVertex].Add(secondVertex);
            }
        }

        public List<int> GetNeighbours(int vertex)
        {
            return adjList[vertex].ToList();
        }
    }
}
