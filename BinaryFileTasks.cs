using System;
using System.IO;

namespace Lab3
{
    /// <summary>
    /// Задание 4: Работа с бинарными файлами (числовые данные)
    /// Вариант 4: Подсчитать количество пар противоположных чисел среди компонент исходного файла
    /// </summary>
    public static class BinaryFileTasks
    {
        private static readonly string InputFilePath = "numbers4.dat";
        private static readonly Random Random = new Random();

        /// <summary>
        /// Заполнение бинарного файла случайными числами
        /// </summary>
        public static void GenerateBinaryFile(string filePath, int count)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    // Генерируем числа в диапазоне от -50 до 50 для появления противоположных
                    int number = Random.Next(-50, 51);
                    writer.Write(number);
                }
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с {count} случайными числами");
        }

        /// <summary>
        /// Чтение и вывод содержимого бинарного файла
        /// </summary>
        public static void PrintBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден");
                return;
            }

            Console.WriteLine("Содержимое файла:");
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int index = 0;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.Write($"{number} ");
                    index++;

                    if (index % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Задание 4.4: Подсчитать количество пар противоположных чисел
        /// </summary>
        public static int CountOppositePairs(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            List<int> numbers = new List<int>();

            // Читаем все числа из файла
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    numbers.Add(reader.ReadInt32());
                }
            }

            // Подсчет пар противоположных чисел
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            int pairCount = 0;

            // Подсчитываем количество каждого числа
            foreach (int num in numbers)
            {
                if (countMap.ContainsKey(num))
                {
                    countMap[num]++;
                }
                else
                {
                    countMap[num] = 1;
                }
            }

            // Ищем противоположные пары
            HashSet<int> processed = new HashSet<int>();

            foreach (int num in countMap.Keys)
            {
                int opposite = -num;

                if (num > 0 && countMap.ContainsKey(opposite) && !processed.Contains(num) && !processed.Contains(opposite))
                {
                    // Количество пар - минимальное из количеств num и -num
                    int pairs = Math.Min(countMap[num], countMap[opposite]);
                    pairCount += pairs;

                    processed.Add(num);
                    processed.Add(opposite);

                    Console.WriteLine($"Найдено {pairs} пар чисел {num} и {opposite}");
                }
                else if (num == 0 && countMap[num] > 1)
                {
                    // Для нуля: пары - это сочетания по 2
                    int pairs = countMap[num] * (countMap[num] - 1) / 2;
                    pairCount += pairs;

                    processed.Add(num);

                    Console.WriteLine($"Найдено {pairs} пар нулей");
                }
            }

            return pairCount;
        }

        /// <summary>
        /// Запуск задания 4
        /// </summary>
        public static void RunTask4()
        {
            try
            {
                // Генерируем файл с 20 случайными числами
                GenerateBinaryFile(InputFilePath, 20);

                // Выводим содержимое
                PrintBinaryFile(InputFilePath);

                // Подсчитываем пары противоположных чисел
                int pairCount = CountOppositePairs(InputFilePath);

                Console.WriteLine($"\nКоличество пар противоположных чисел: {pairCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}