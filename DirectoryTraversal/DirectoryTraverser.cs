using DirectoryTraversal.Outputting;

namespace DirectoryTraversal
{
    /// <summary>
    /// Класс, содержащий логику обхода папки
    /// </summary>
    internal class DirectoryTraverser
    {
        /// <summary>
        /// Параметры выполнения программы
        /// </summary>
        public UtilityParameters Parameters { get; init; }

        /// <summary>
        /// Корневой узел дерева, которое будет строиться из папок
        /// </summary>
        public DataElement Node { get; init; }

        /// <summary>
        /// Список экземпляров объектов отображителей результата
        /// </summary>
        public List<TraversalOutputter> Outputters { get; set; }

        /// <summary>
        /// Создание экземпляра объекта обходчика директории
        /// </summary>
        /// <param name="parameters">Параметры выполнения программы</param>
        public DirectoryTraverser(UtilityParameters parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException("Пустой экземпляр объекта параметров");
            }

            Parameters = parameters;
            Node = new DataElement($"<{Parameters.DirectoryPath}>", DataType.Folder);
            Outputters = new List<TraversalOutputter>();

            Traverse(Parameters.DirectoryPath, Node);
            
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

        /// <summary>
        /// Сделать вывод
        /// </summary>
        public void DoOutput()
        {
            Outputters.Add(new TxtFileOutputter(Node, Parameters.OutputDirectory, Parameters.OutputFileName, reduceBytes: Parameters.ReduceBytes));

            if (!Parameters.IsOnlyFileOutput)
            {
                Outputters.Add(new ConsoleOutputter(Node, reduceBytes: Parameters.ReduceBytes));
            }

            foreach (var outputter in Outputters)
            {
                outputter.DoOutput();
            }
        }
    }
}
