using System;
using System.IO;

namespace Lab3
{
    /// <summary>
    /// Задание 6: Текстовые файлы с целыми числами по одному в строке
    /// Вариант 4: Для заданного файла возвратить true, если он не содержит нуля, и false в противном случае
    /// </summary>
    public static class TextFileSingleTasks
    {
        private static readonly string InputFilePath = "numbers_single.txt";
        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерация файла со случайными числами (по одному в строке)
        /// </summary>
        public static void GenerateTextFile(string filePath, int count)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    // Генерируем числа от -10 до 10, иногда пропуская 0 для проверки
                    int number;
                    if (i % 3 == 0) // Каждое третье число может быть нулем для демонстрации
                    {
                        number = Random.Next(0, 2) == 0 ? 0 : Random.Next(-10, 11);
                    }
                    else
                    {
                        number = Random.Next(-10, 11);
                        if (number == 0) number = 1; // Избегаем случайных нулей
                    }

                    writer.WriteLine(number);
                }
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с {count} числами");
        }

        /// <summary>
        /// Чтение и вывод содержимого текстового файла
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
        /// Задание 6.4: Проверка, содержит ли файл ноль
        /// </summary>
        public static bool ContainsZero(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (int.TryParse(line.Trim(), out int number))
                {
                    if (number == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Запуск задания 6
        /// </summary>
        public static void RunTask6()
        {
            try
            {
                // Генерируем файл с 15 числами
                GenerateTextFile(InputFilePath, 15);

                // Выводим содержимое
                PrintTextFile(InputFilePath);

                // Проверяем наличие нуля
                bool hasZero = ContainsZero(InputFilePath);

                Console.WriteLine($"\nРезультат проверки: файл {(hasZero ? "содержит" : "НЕ содержит")} ноль");
                Console.WriteLine($"ContainsZero() вернул: {hasZero}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}