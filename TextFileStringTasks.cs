using System;
using System.IO;
using System.Text;

namespace Lab3
{
    /// <summary>
    /// Задание 8: Текстовые файлы с текстом
    /// Вариант 4: Переписать в другой файл строки, оканчивающиеся на заданный символ
    /// </summary>
    public static class TextFileStringTasks
    {
        private static readonly string InputFilePath = "text_input.txt";
        private static readonly string OutputFilePath = "text_output.txt";
        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерация текстового файла с различными строками
        /// </summary>
        public static void GenerateTextFile(string filePath, int lineCount)
        {
            string[] words = {
                "яблоко", "груша", "слива", "арбуз", "дыня",
                "стол", "стул", "шкаф", "кровать", "диван",
                "книга", "тетрадь", "ручка", "карандаш", "линейка",
                "собака", "кошка", "корова", "лошадь", "коза",
                "красный", "синий", "зеленый", "желтый", "черный",
                "бегать", "прыгать", "сидеть", "лежать", "стоять",
                "быстро", "медленно", "громко", "тихо", "ярко"
            };

            string[] endings = { "а", "я", "о", "е", "ь", "й", "и", "ы" };

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    int wordCount = Random.Next(3, 8);
                    StringBuilder line = new StringBuilder();

                    for (int j = 0; j < wordCount; j++)
                    {
                        if (j > 0) line.Append(" ");

                        string word = words[Random.Next(words.Length)];

                        // Иногда добавляем случайное окончание для разнообразия
                        if (Random.Next(3) == 0)
                        {
                            word += endings[Random.Next(endings.Length)];
                        }

                        // Делаем первую букву заглавной в начале предложения
                        if (j == 0)
                        {
                            word = char.ToUpper(word[0]) + word.Substring(1);
                        }

                        line.Append(word);
                    }

                    // Добавляем знак препинания в конце
                    string[] punctuation = { ".", "!", "?", "..." };
                    line.Append(punctuation[Random.Next(punctuation.Length)]);

                    writer.WriteLine(line.ToString());
                }
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с {lineCount} строками текста");
        }

        /// <summary>
        /// Вывод содержимого текстового файла с нумерацией строк
        /// </summary>
        public static void PrintTextFile(string filePath, string title = "Содержимое файла")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не найден");
                return;
            }

            Console.WriteLine($"\n{title}:");
            Console.WriteLine("------------------------------------------------------------------------------");

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Length > 60 ? lines[i].Substring(0, 57) + "..." : lines[i];
                Console.WriteLine($"{i + 1,3}. {line}");
            }

            Console.WriteLine("------------------------------------------------------------------------------");
        }

        /// <summary>
        /// Задание 8.4: Переписать в другой файл строки, оканчивающиеся на заданный символ
        /// </summary>
        public static void FilterLinesByEnding(string inputFile, string outputFile, char endingChar)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"Файл {inputFile} не найден");
            }

            string[] lines = File.ReadAllLines(inputFile, Encoding.UTF8);
            List<string> filteredLines = new List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string trimmedLine = line.TrimEnd('.', '!', '?'); // Убираем знаки препинания в конце
                if (trimmedLine.Length > 0 && char.ToLower(trimmedLine[trimmedLine.Length - 1]) == char.ToLower(endingChar))
                {
                    filteredLines.Add(line);
                }
            }

            File.WriteAllLines(outputFile, filteredLines, Encoding.UTF8);

            Console.WriteLine($"\nНайдено {filteredLines.Count} строк, оканчивающихся на '{endingChar}'");
        }

        /// <summary>
        /// Запуск задания 8
        /// </summary>
        public static void RunTask8()
        {
            try
            {
                // Генерируем текстовый файл
                GenerateTextFile(InputFilePath, 10);

                // Выводим исходный файл
                PrintTextFile(InputFilePath, "ИСХОДНЫЙ ФАЙЛ");

                // Запрашиваем символ для поиска
                Console.Write("\nВведите символ, на который должны оканчиваться строки (по умолчанию 'а'): ");
                string input = Console.ReadLine();
                char endingChar = string.IsNullOrEmpty(input) ? 'а' : input[0];

                // Фильтруем строки
                FilterLinesByEnding(InputFilePath, OutputFilePath, endingChar);

                // Выводим результат
                if (File.Exists(OutputFilePath))
                {
                    PrintTextFile(OutputFilePath, $"СТРОКИ, ОКАНЧИВАЮЩИЕСЯ НА '{endingChar}'");
                }

                // Показываем статистику
                ShowStatistics(InputFilePath, OutputFilePath, endingChar);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void ShowStatistics(string inputFile, string outputFile, char endingChar)
        {
            if (!File.Exists(inputFile) || !File.Exists(outputFile)) return;

            string[] inputLines = File.ReadAllLines(inputFile, Encoding.UTF8);
            string[] outputLines = File.ReadAllLines(outputFile, Encoding.UTF8);

            Console.WriteLine("\nСТАТИСТИКА:");
            Console.WriteLine($"   Всего строк в исходном файле: {inputLines.Length}");
            Console.WriteLine($"   Строк, оканчивающихся на '{endingChar}': {outputLines.Length}");

            if (inputLines.Length > 0)
            {
                double percentage = (double)outputLines.Length / inputLines.Length * 100;
                Console.WriteLine($"   Процент совпадений: {percentage:F1}%");
            }
        }
    }
}