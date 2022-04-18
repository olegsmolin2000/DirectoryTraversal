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
        public DataElement Node { get; init; }

        /// <summary>
        /// Параметры выполнения программы
        /// </summary>
        public UtilityParameters Parameters { get; init; }

        public DirectoryTraverser(UtilityParameters parameters)
        {
            Parameters = parameters;

            Node = new DataElement(Parameters.DirectoryPath, DataType.Folder);
        }

        /// <summary>
        /// Обход папки
        /// </summary>
        /// <param name="path">Путь проходимой папки</param>
        /// <param name="node">Узел, в который будет идти запись данных</param>
        public void Traverse(string path, DataElement node)
        {
            var currentDirectoryFiles = Directory.GetFiles(path);
            var currentDirectoryFolders = Directory.GetDirectories(path);

            foreach (var filePath in currentDirectoryFiles)
            {
                var fileInfo = new FileInfo(filePath);
                var childFile = new DataElement(fileInfo.Name, DataType.File, bytesCount: fileInfo.Length, parent: node);
                node.Childs.Add(childFile);
            }

            foreach (var folderPath in currentDirectoryFolders)
            {
                var folderInfo = new DirectoryInfo(folderPath);

                var childDirectory = new DataElement(folderInfo.Name, DataType.Folder, parent: node);

                node.Childs.Add(childDirectory);

                Traverse(folderPath, childDirectory);
            }
        }

        public void FillStringBuilder(DataElement node, StringBuilder nodesSB, string padding = "")
        {
            if (padding == "")
            {
                nodesSB.Append($"- <{node.Name}> ({node.BytesCount} bytes)\n");
            }
            else
            {
                nodesSB.Append($"{padding} {node.Name} ({node.BytesCount} bytes)\n");
            }

            if (node.Type != DataType.File)
            {
                foreach (var childNode in node.Childs)
                {
                    FillStringBuilder(childNode, nodesSB, padding + "--");
                }
            }
        }
    }
}
