using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    /// <summary>
    /// Класс, содержащий параметры для выполнения программы
    /// </summary>
    internal class UtilityParameters
    {
        /// <summary>
        /// Признак вывода сообщений в стандартный поток вывода 
        /// (-q, --quite. Если <see langword="true"/>, то не выводить лог в консоль. Только в файл)
        /// </summary>
        public bool IsOnlyFileOutput { get; set; }

        /// <summary>
        /// Путь к папке для обхода 
        /// (-p или --path. По-умолчанию текущая папка вызова программы)
        /// </summary>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// Путь к тестовому файлу, куда записать результаты выполнения расчёта 
        /// (-o или --output. По-умолчанию файл sizes-YYYY-MM-DD.txt в текущей папке вызова программы)
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// Признак формирования размеров файлов в человекочитаемой форме
        /// (-h или --humanread. Если <see langword="true"/>, то размер показывается в читаемой для человека форме)
        /// </summary>
        public bool HumanReadable { get; set; }

        public UtilityParameters(string[] args)
        {
            FillDefaultParameters();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-q":
                    case "--quite":
                        IsOnlyFileOutput = true;
                        break;

                    case "-h":
                    case "--humanread":
                        HumanReadable = true;
                        break;

                    case "-p":
                    case "--path":
                        if (i + 1 < args.Length)
                        {
                            string directoryPath = args[i + 1];

                            if (Directory.Exists(directoryPath))
                            {
                                DirectoryPath = directoryPath;

                                i++;
                            }
                            else
                            {
                                throw new ArgumentException($"Указанного пути \"{directoryPath}\" не существует!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Не указан путь к читаемой папке!");
                        }

                        break;

                    case "-o":
                    case "--output":
                        if (i + 1 < args.Length)
                        {
                            string outputPath = args[i + 1];

                            if (outputPath.EndsWith(".txt") && Directory.Exists(Path.GetDirectoryName(outputPath)))
                            {
                                OutputPath = outputPath;

                                i++;
                            }
                            else
                            {
                                throw new ArgumentException($"Такого пути \"{outputPath}\" не существует!");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Не указан пусть к выходному файлу!");
                        }

                        break;

                    default:
                        throw new ArgumentException($"Неизвестный параметр {args[i]}!");
                }
            }
        }

        private void FillDefaultParameters()
        {
            IsOnlyFileOutput = false;
            DirectoryPath = Directory.GetCurrentDirectory();
            OutputPath = $"{DirectoryPath}\\sizes-{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            HumanReadable = false;
        }
    }
}
