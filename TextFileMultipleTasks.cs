using System;
using System.IO;
using System.Linq;

namespace Lab3
{
    /// <summary>
    /// Задание 7: Текстовые файлы с целыми числами по несколько в строке
    /// Вариант 4: Вычислить количество чётных элементов
    /// </summary>
    public static class TextFileMultipleTasks
    {
        private static readonly string InputFilePath = "numbers_multiple.txt";
        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерация файла со случайными числами (по несколько в строке)
        /// </summary>
        public static void GenerateTextFile(string filePath, int rows, int maxNumbersPerRow)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < rows; i++)
                {
                    int numbersInRow = Random.Next(1, maxNumbersPerRow + 1);
                    List<int> rowNumbers = new List<int>();

                    for (int j = 0; j < numbersInRow; j++)
                    {
                        rowNumbers.Add(Random.Next(-100, 101));
                    }

                    writer.WriteLine(string.Join(" ", rowNumbers));
                }
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с {rows} строками");
        }

        /// <summary>
        /// Чтение и вывод содержимого файла
        /// </summary>
        public static void PrintTextFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден");
                return;
            }

            Console.WriteLine("Содержимое файла:");
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"Строка {i + 1}: {lines[i]}");
            }
        }

        /// <summary>
        /// Задание 7.4: Вычислить количество чётных элементов
        /// </summary>
        public static int CountEvenNumbers(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            int evenCount = 0;
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        if (number % 2 == 0)
                        {
                            evenCount++;
                        }
                    }
                }
            }

            return evenCount;
        }

        /// <summary>
        /// Запуск задания 7
        /// </summary>
        public static void RunTask7()
        {
            try
            {
                // Генерируем файл с 5 строками, до 6 чисел в строке
                GenerateTextFile(InputFilePath, 5, 6);

                // Выводим содержимое
                PrintTextFile(InputFilePath);

                // Подсчитываем количество чётных элементов
                int evenCount = CountEvenNumbers(InputFilePath);

                Console.WriteLine($"\nКоличество чётных элементов в файле: {evenCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}