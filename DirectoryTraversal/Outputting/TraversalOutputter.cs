using System.Text;

namespace DirectoryTraversal.Outputting
{
    /// <summary>
    /// Базовый абстрактный класс для отображителей результата
    /// </summary>
    internal abstract class TraversalOutputter
    {
        private static readonly string[] Reductors = {"байт", "Кб", "Мб", "Гб", "Тб"};

        /// <summary>
        /// Узел дерева, из которого будет производиться отображение результата
        /// </summary>
        protected DataElement RootElement { get; private init; }

        /// <summary>
        /// Сокращение количества байт до читаемой для человека формы
        /// </summary>
        protected bool ReduceBytes { get; private init; }

        /// <summary>
        /// Строковое отображение результата
        /// </summary>
        protected StringBuilder StringRepresentation { get; set; }

        /// <summary>
        /// Создание экземпляра объекта выгружателя результата
        /// </summary>
        /// <param name="root">Узел дерева, с которого будет строиться результат</param>
        /// <param name="reduceBytes">Сокращение количества байт до читаемой для человека формы</param>
        protected TraversalOutputter(DataElement root, bool reduceBytes = false)
        {
            RootElement = root;
            ReduceBytes = reduceBytes;
            StringRepresentation = new StringBuilder();
            CalculateStringRepresentation(RootElement);
        }

        /// <summary>
        /// Вычисление строкового представления дерева.
        /// </summary>
        /// <param name="node">Узел дерева</param>
        /// <param name="padding">Отступ</param>
        protected void CalculateStringRepresentation(DataElement node, string padding = "")
        {
            var bytesRepresentation = GetBytesRepresentation(node.BytesCount);

            if (string.IsNullOrEmpty(padding))
            {
                StringRepresentation.Append($"- {node.Name} ({bytesRepresentation})\n");
            }
            else
            {
                StringRepresentation.Append($"{padding} {node.Name} ({bytesRepresentation})\n");
            }

            if (node.Type != DataType.File)
            {
                foreach (var childNode in node.Childs)
                {
                    CalculateStringRepresentation(childNode, padding + "--");
                }
            }
        }

        /// <summary>
        /// Строковое представление количество байт. 
        /// Переводит в человекочитаемую форму,если необходимо
        /// </summary>
        /// <param name="bytesCount">Количество байт</param>
        /// <returns>Строковое представление</returns>
        protected string GetBytesRepresentation(long bytesCount)
        {
            const double ReductorValue = 1024;

            var reducedValue = Convert.ToDouble(bytesCount);
            int reductorIndex = 0;

            if (ReduceBytes)
            {
                while (reducedValue / ReductorValue > 1 && reductorIndex < Reductors.Length - 1)
                {
                    reducedValue /= ReductorValue;

                    reductorIndex++;
                }
            }

            var reducedFormat = reductorIndex > 0
                ? $"{reducedValue:F2}"
                : $"{reducedValue}";

            return $"{reducedFormat} {Reductors[reductorIndex]}";
        }

        /// <summary>
        /// Сделать вывод
        /// </summary>
        public abstract void DoOutput();
    }
}
