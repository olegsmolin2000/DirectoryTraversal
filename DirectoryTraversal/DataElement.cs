using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// 
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
        public void IncreaseBytes(int additionalSize)
        {

        }
    }
}
