using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public interface IGraph
    {
        int NumberOfVertices { get; }
        int NumberOfEdges { get; set; }
        void AddVertex();
        void AddEdge(int firstVertex, int secondVertex);
        List<int> GetNeighbours(int vertex);
    }
}
