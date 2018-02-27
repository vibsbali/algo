using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tries
{
    public class TrieNodes
    {
        //Hash can be used as well
        public TrieNodes[] Nodes { get; private set; }
        public string Value { get; set; }

        public TrieNodes(int radix)
        {
            Nodes = new TrieNodes[radix];
        }
    }
}
