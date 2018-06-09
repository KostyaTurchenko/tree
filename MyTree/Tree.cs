using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    public class Tree
    {
        public Node Root { get; set; }
        public Tree(string[] data)
        {
            Root = new Node("", -1);
            for (int i = 0; i < data.Length; i++)
            {
                int Left = 0;
                while (data[i][Left] == ' ')
                    Left++;
                Node Go = Root;
                while (Go.Nodes.Count>0&&Left>Go.Nodes[Go.Nodes.Count-1].LeftCount)
                {
                    Go = Go.Nodes[Go.Nodes.Count - 1];
                }
                Go.Nodes.Add(new Node(data[i].Substring(Left), Left));
            }
        }
        public int GetHeight() => Root.GetHeight();
    }
}
