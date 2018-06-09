using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTree;
using System.Drawing;

namespace Drawing
{
    public class Draw
    {
        public Tree tree { get; set; }
        public Size size { get; set; }
        Bitmap image;
        Graphics G;
        int Y;
        public Draw(Tree tree, Size size)
        {
            this.tree = tree;
            this.size = size;
        }
        public Bitmap DrawImage()
        {
            Y = size.Height / (tree.GetHeight() + 1);
            image = new Bitmap(size.Width, size.Height);
            G = Graphics.FromImage(image);
            DrawNode(tree.Root, 1, 0, size.Width);
            G.Dispose();
            return image;
        }
        void DrawNode(Node node, int k, int L, int R)
        {
            int Rad = Math.Min(R - L, Y) / 3;
            
            int X = node.Nodes.Count==0?0: (R - L) / (node.Nodes.Count);
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                G.DrawLine(Pens.Black, (L + R) / 2, k * Y, L + X * (i + (float)0.5), (k + 1) * Y);
            }
            G.FillEllipse(Brushes.Red, (L+R)/2 - Rad, k*Y - Rad, 2 * Rad, 2 * Rad);
            float size = 0;
            string print =node.Value;
            if(print!= "")
            {
                do
                {
                    size += (float)0.2;
                }
                while (G.MeasureString(print, new Font("Microsoft Sans Serif", size)).Width < Rad);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                G.DrawString(print, new Font("Microsoft Sans Serif", size), Brushes.Black, new Rectangle((L + R) / 2 - Rad, k * Y - Rad, 2 * Rad, 2 * Rad), sf);
            }
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                DrawNode(node.Nodes[i], k + 1, L + i * X, L + i * X + X);
            }
        }
    }
}
