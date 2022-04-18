namespace DirectoryTraversal.Outputting
{
    /// <summary>
    /// Отображитель результата в текстовый файл
    /// </summary>
    internal class TxtFileOutputter : TraversalOutputter
    {
        /// <summary>
        /// Директория, куда будет записан файл
        /// </summary>
        public string Directory { get; private init; }

        /// <summary>
        /// Название создаваемого/записываемого файла
        /// </summary>
        public string FileName { get; private init; }

        /// <summary>
        /// Создание экземпляра объекта отображителя в текстовый файл
        /// </summary>
        /// <param name="root">Узел дерева, по которому будет делаться отображение</param>
        /// <param name="directory">Путь, куда будет записан файл</param>
        /// <param name="fileName">Название файла</param>
        /// <param name="reduceBytes">Сокращение количества байт до читаемой для человека формы</param>
        public TxtFileOutputter(DataElement root, string directory, string fileName, bool reduceBytes = false) 
            : base(root, reduceBytes)
        {
            Directory = directory;
            FileName = fileName;
        }

        /// <summary>
        /// Записать в текстовый файл
        /// </summary>
        public override void DoOutput()
        {
            File.WriteAllText($"{Directory}/{FileName}", StringRepresentation.ToString());
        }
    }
}
