using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyTree
{
    public class TextFile
    {
        public string Path { get; set; }
        public string[] Read() => File.ReadAllLines(Path);

        public TextFile(string path)
        {
            Path = path;
        }
    }
}
