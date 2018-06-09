using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    public class Node
    {
        public string Value { get; set; }
        internal int LeftCount { get; set; }
        public List<Node> Nodes { get; set; }
        internal int GetHeight()
        {
            int max = 0;
            foreach (var item in Nodes)
                max = Math.Max(max, item.GetHeight());
            return max + 1;
        }
        public Node(string value, int leftCount)
        {
            Value = value;
            LeftCount = leftCount;
            Nodes = new List<Node>();
        }
    }
}
