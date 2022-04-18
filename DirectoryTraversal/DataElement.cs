namespace DirectoryTraversal
{
    /// <summary>
    /// Типы элементов данных
    /// </summary>
    internal enum DataType
    {
        /// <summary>
        /// Папка
        /// </summary>
        Folder,
        /// <summary>
        /// Файл
        /// </summary>
        File
    }

    /// <summary>
    /// Класс для хранения данных о элементе (дерево с данными).
    /// </summary>
    internal class DataElement
    {
        /// <summary>
        /// Название элемента
        /// </summary>
        public string Name { get; private init; }

        /// <summary>
        /// Тип элемента
        /// </summary>
        public DataType Type { get; private init; }

        /// <summary>
        /// Количество занимаемых байт
        /// </summary>
        public long BytesCount { get; private set; } = 0;

        /// <summary>
        /// Родительская папка
        /// </summary>
        public DataElement Parent { get; private init; }

        /// <summary>
        /// Список содержащихся внутри элементов (Только для папок).
        /// </summary>
        public List<DataElement> Childs { get; private init; }

        /// <summary>
        /// Создаёт экземпляр объекта элемента данных
        /// </summary>
        /// <param name="name">Название элемента</param>
        /// <param name="type">Тип элемента</param>
        /// <param name="bytesCount">Количество занимаемых байт</param>
        /// <param name="parent">Родительская директория</param>
        public DataElement(string name, DataType type, long bytesCount = 0, DataElement parent = null)
        {
            Name = name;
            Type = type;
            Parent = parent;

            if (bytesCount > 0)
            {
                IncreaseBytes(bytesCount);
            }
            
            if (Type == DataType.Folder)
            {
                Childs = new List<DataElement>();
            }
        }

        /// <summary>
        /// Увеличение количества занимаемого места. Так же увеличивает у родительских узлов
        /// </summary>
        /// <param name="additionalSize">Добавляемый размер (в байтах)</param>      
        private void IncreaseBytes(long additionalSize)
        {
            BytesCount += additionalSize;

            if (Parent is not null)
            {
                Parent.IncreaseBytes(additionalSize);
            }
        }
    }
}
