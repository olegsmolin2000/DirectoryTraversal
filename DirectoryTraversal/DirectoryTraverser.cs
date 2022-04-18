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
        /// <summary>
        /// Корневой узел дерева, которое будет строиться из папок
        /// </summary>
        public NodeElement<DataElement> Node { get; private set; }

        /// <summary>
        /// Путь папки, для которой будет делаться обход
        /// </summary>
        public string Path { get; init; }

        public DirectoryTraverser(UtilityParameters parameters)
        {
            Path = parameters.DirectoryPath;
            var root = new DataElement(Path, DataType.Folder);
            Node = new NodeElement<DataElement>(root);
        }

        public void Traverse()
        {
            
        }
    }
}
