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
    /// Класс для хранения данных о элементе
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
        public int BytesCount { get; private set; }

        /// <summary>
        /// Создаёт экземпляр объекта элемента данных
        /// </summary>
        /// <param name="name">Название элемента</param>
        /// <param name="type">Тип элемента</param>
        /// <param name="bytesCount">Количество занимаемых байт</param>
        public DataElement(string name, DataType type, int bytesCount = 0)
        {
            Name = name;
            Type = type;
            BytesCount = bytesCount;
        }

        /// <summary>
        /// Увеличение количества занимаемого места
        /// </summary>
        /// <param name="additionalSize">Добавляемый размер (в байтах)</param>
        /// <exception cref="ArgumentException">Добавление отрицательного количества байт</exception>        
        public void IncreaseBytes(int additionalSize)
        {
            if (additionalSize >= 0)
            {
                BytesCount += additionalSize;
            }
            else
            {
                throw new ArgumentException("Добавление отрицательного размера в классе DataElement!");
            }
        }
    }
}
