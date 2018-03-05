using System.Collections.Generic;

namespace Algorithms.Graphs
{
    public interface IGraph
    {
        int NumberOfVertices { get; }
        int NumberOfEdges { get; set; }
        void AddVertex();
        void AddDirectedEdge(int firstVertex, int secondVertex);
        void AddUnDirectedEdge(int firstVertex, int secondVertex);
        List<int> GetNeighbours(int vertex);
    }
}
