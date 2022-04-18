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
        public bool IsOnlyFileOutput { get; private set; }

        /// <summary>
        /// Путь к папке для обхода 
        /// (-p или --path. По умолчанию - текущая папка вызова программы)
        /// </summary>
        public string DirectoryPath { get; private set; }

        /// <summary>
        /// Расположение папки, в которую будет записан результирующий файл
        /// (-o или --output. По умолчанию - текущая папка вызова программы)
        /// </summary>
        public string OutputDirectory { get; set; }

        /// <summary>
        /// Название результирующейго файла
        /// (-o или --output. По умолчанию - файл sizes-YYYY-MM-DD.txt)
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// Признак формирования размеров файлов в человекочитаемой форме
        /// (-h или --humanread. Если <see langword="true"/>, то размер показывается в читаемой для человека форме)
        /// </summary>
        public bool ReduceBytes { get; private set; }

        /// <summary>
        /// Создание экземпляра параметров и заполнение его значениями по умолчанию. 
        /// Путь - текущая папка. 
        /// Выходной файл - "текущая папка/sizes-YYYY-MM-DD.txt".
        /// </summary>
        public UtilityParameters()
        {
            IsOnlyFileOutput = false;
            DirectoryPath = Directory.GetCurrentDirectory();
            OutputDirectory = DirectoryPath;
            OutputFileName = $"sizes-{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
            ReduceBytes = false;
        }

        /// <summary>
        /// Считывание параметров из аргументов командной строки
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        /// <exception cref="ArgumentException">Некорректные ввод параметров в командной строке</exception>
        public void ReadConsoleParameters(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-q":
                    case "--quite":
                        {
                            IsOnlyFileOutput = true;

                            break;
                        }
                    case "-h":
                    case "--humanread":
                        {
                            ReduceBytes = true;

                            break;
                        }
                    case "-p":
                    case "--path":
                        {
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
                        }
                    case "-o":
                    case "--output":
                        {
                            if (i + 1 < args.Length)
                            {
                                var outputFile = args[i + 1];

                                var outputDirectory = Path.GetDirectoryName(outputFile);
                                var outputFileName = Path.GetFileName(outputFile);

                                if (!string.IsNullOrEmpty(outputFileName))
                                {
                                    if (Directory.Exists(outputDirectory))
                                    {
                                        OutputDirectory = outputDirectory;
                                    }

                                    OutputFileName = outputFileName;
                                    i++;
                                }
                                else
                                {
                                    throw new ArgumentException($"Некорректное название файла \"{outputFileName}\"!");
                                }  
                                
                            }
                            else
                            {
                                throw new ArgumentException("Не указан пусть к выходному файлу!");
                            }

                            break;
                        }
                    default:
                        {
                            throw new ArgumentException($"Неизвестный параметр {args[i]}!");
                        }
                }
            }
        }
    }
}
