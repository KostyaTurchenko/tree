using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTree;
using Drawing;
namespace TreeV
{
    public partial class TreeForm : Form
    {
        public TreeForm()
        {
            InitializeComponent();
        }
        Draw draw;
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextFile file = new TextFile(openFileDialog.FileName);
                    draw.tree = new Tree(file.Read());
                    Output.Image = draw.DrawImage();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        private void TreeForm_Load(object sender, EventArgs e)
        {
            draw = new Draw(null, Output.Size);
        }
    }
}
