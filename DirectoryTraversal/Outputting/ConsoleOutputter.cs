using System.Text;

namespace DirectoryTraversal.Outputting
{
    /// <summary>
    /// Отображитель результата в консоль
    /// </summary>
    internal class ConsoleOutputter : TraversalOutputter
    {
        /// <summary>
        /// Создание экземпляра объекта отображителя в консоль
        /// </summary>
        /// <param name="root">Узел дерева, по которому будет делаться отображение</param>
        /// <param name="reduceBytes">Сокращение количества байт до читаемой для человека формы</param>
        public ConsoleOutputter(DataElement root, bool reduceBytes = false) 
            : base(root, reduceBytes)
        { }

        /// <summary>
        /// Вывести в консоль
        /// </summary>
        public override void DoOutput()
        {
            Console.WriteLine(StringRepresentation.ToString());
        }
    }
}
