using System;
using System.Linq;
using Algorithms.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.GraphTests
{
    [TestClass]
    public class GraphAdjTests
    {
        [TestMethod]
        public void Create_Graph_With_6_Nodes_Assert_NumberOfVertex_6()
        {
            var graph = new GraphAdjMatrix(new int[] {0, 1, 2, 3, 4, 5});
            Assert.AreEqual(6, graph.NumberOfVertices);
        }

        [TestMethod]
        public void Create_Graph_With_6_Nodes_Add_Link_From_0To1_Assert_AreLinked_ZeroToOne()
        {
            var graph = new GraphAdjMatrix(new int[] { 0, 1, 2, 3, 4, 5 });
            Assert.AreEqual(6, graph.NumberOfVertices);

            graph.AddEdge(0, 1);
            var neighbours = graph.GetNeighbours(0);
            Assert.AreEqual(1, neighbours[0]);
        }

        [TestMethod]
        public void Create_Graph_With_6_Nodes_Add_Another_Node_Add_Link_From_5To6_Assert_AreLinked_ZeroToOne()
        {
            var graph = new GraphAdjMatrix(new int[] { 0, 1, 2, 3, 4, 5 });
            Assert.AreEqual(6, graph.NumberOfVertices);

            graph.AddVertex();
            graph.AddEdge(5, 6);
            var neighbours = graph.GetNeighbours(5);
            Assert.AreEqual(6, neighbours[0]);
        }
    }
}
