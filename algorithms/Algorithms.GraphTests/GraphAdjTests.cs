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

            graph.AddDirectedEdge(0, 1);
            var neighbours = graph.GetNeighbours(0);
            Assert.AreEqual(1, neighbours[0]);
        }

        [TestMethod]
        public void Create_Graph_With_6_Nodes_Add_Another_Node_Add_Link_From_5To6_Assert_AreLinked_ZeroToOne()
        {
            var graph = new GraphAdjMatrix(new int[] { 0, 1, 2, 3, 4, 5 });
            Assert.AreEqual(6, graph.NumberOfVertices);

            graph.AddVertex();
            graph.AddDirectedEdge(5, 6);
            var neighbours = graph.GetNeighbours(5);
            Assert.AreEqual(6, neighbours[0]);
        }

        [TestMethod]
        public void Create_Graph_With_7_Nodes_One_At_A_Time()
        {
            var graph = new GraphAdjMatrix(new int[] { 0 });
            graph.AddVertex();
            graph.AddVertex();
            graph.AddDirectedEdge(1, 2);
            graph.AddDirectedEdge(2, 0);
            graph.AddVertex();
            graph.AddDirectedEdge(0, 3);
            graph.AddVertex();
            graph.AddDirectedEdge(3, 4);
            graph.AddVertex();
            graph.AddDirectedEdge(5, 4);
            graph.AddVertex();
            graph.AddDirectedEdge(6,5);
            graph.AddDirectedEdge(6, 4);

            var zerosNeighbours = graph.GetNeighbours(0);
            var onesNeighbours = graph.GetNeighbours(1);
            var twosNeighbours = graph.GetNeighbours(2);
            var threessNeighbours = graph.GetNeighbours(3);
            var foursNeighbours = graph.GetNeighbours(4);
            var fivesNeighbours = graph.GetNeighbours(5);
            var sixsNeighbours = graph.GetNeighbours(6);

            Assert.AreEqual(3, zerosNeighbours[0]);
            Assert.IsTrue(sixsNeighbours.Contains(5));
            Assert.IsTrue(sixsNeighbours.Contains(4));
            Assert.IsTrue(onesNeighbours.Contains(2));

            Assert.IsTrue(twosNeighbours.Contains(0));
            Assert.IsTrue(threessNeighbours.Contains(4));
            Assert.IsTrue(foursNeighbours.Count == 0);
            Assert.IsTrue(fivesNeighbours.Contains(4));
        }

       
    }
}
