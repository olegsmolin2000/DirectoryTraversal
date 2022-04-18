using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    internal class NodeElement<T>
    {
        public T Data { get; private init; }
        public NodeElement<T> Parent { get; private init; }
        private List<NodeElement<T>> Childs { get; init; }

        public NodeElement(T data, NodeElement<T> parent = null)
        {
            Data = data;
            Parent = parent;
            Childs = new List<NodeElement<T>>();
        }

        public void AddChild(T child)
        {
            var newNode = new NodeElement<T>(child, this);
            Childs.Add(newNode);
        }
    }
}
