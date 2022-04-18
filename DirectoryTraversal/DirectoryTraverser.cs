using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DirectoryTraversal
{
    /// <summary>
    /// Класс, содержащий логику обхода папки
    /// </summary>
    internal class DirectoryTraverser
    {
        public string Path { get; init; }

        public DirectoryTraverser(UtilityParameters parameters)
        {
            Path = parameters.DirectoryPath;
        }

        public void Traverse(string path)
        {

        }
    }
}
