using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_Collections
{
    /// <summary>
    /// Задание 4.4: Файл содержит текст на русском языке. 
    /// Напечатать в алфавитном порядке все глухие согласные буквы, 
    /// которые не входят ровно в одно слово.
    /// </summary>
    public static class Task4_HashSetFile
    {
        private static readonly string InputFilePath = "russian_text.txt";
        private static readonly Random Random = new Random();

        // Глухие согласные русского языка
        private static readonly HashSet<char> VoicelessConsonants = new HashSet<char>
        {
            'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ'
        };

        public static void Demonstrate()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 4.4: HASHSET + ФАЙЛ - ГЛУХИЕ СОГЛАСНЫЕ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Генерируем текстовый файл
            GenerateTextFile(InputFilePath);

            // Читаем текст из файла
            string text = ReadTextFile(InputFilePath);

            // Выводим текст
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------");

            // Анализируем текст
            AnalyzeVoicelessConsonants(text);
        }

        /// <summary>
        /// Генерация текстового файла с русским текстом
        /// </summary>
        private static void GenerateTextFile(string filePath)
        {
            string[] words = {
                "привет", "мир", "как", "дела", "сегодня", "хороший", "день",
                "солнце", "светит", "ярко", "птицы", "поют", "весело", "тепло",
                "осень", "золотая", "листья", "падают", "кружатся", "ветер", "дует",
                "школа", "ученики", "учатся", "учитель", "объясняет", "урок", "интересно",
                "книга", "читает", "рассказ", "история", "герой", "приключения", "финал",
                "компьютер", "программа", "код", "пишет", "разработчик", "тестирует",
                "спорт", "футбол", "игра", "команда", "победа", "тренировка", "матч",
                "музыка", "песня", "слушает", "мелодия", "ритм", "танец", "концерт"
            };

            string[] punctuation = { "", ".", "!", "?", ",", "..." };

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                int wordCount = Random.Next(20, 41); // 20-40 слов
                StringBuilder text = new StringBuilder();

                for (int i = 0; i < wordCount; i++)
                {
                    if (i > 0) text.Append(" ");

                    string word = words[Random.Next(words.Length)];

                    // С вероятностью 30% делаем букву заглавной
                    if (Random.NextDouble() < 0.3)
                    {
                        word = char.ToUpper(word[0]) + word.Substring(1);
                    }

                    text.Append(word);

                    // Добавляем знак препинания с вероятностью 20%
                    if (Random.NextDouble() < 0.2)
                    {
                        text.Append(punctuation[Random.Next(punctuation.Length)]);
                    }
                }

                writer.Write(text.ToString());
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с текстом на русском языке");
        }

        /// <summary>
        /// Чтение текста из файла
        /// </summary>
        private static string ReadTextFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        /// <summary>
        /// Задание 4.4: Анализ глухих согласных
        /// </summary>
        private static void AnalyzeVoicelessConsonants(string text)
        {
            // Разбиваем текст на слова (убираем знаки препинания)
            char[] separators = { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '\r', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"\nКоличество слов в тексте: {words.Length}");

            // Для каждой глухой согласной считаем, в скольких словах она встречается
            Dictionary<char, int> consonantCount = new Dictionary<char, int>();

            foreach (char c in VoicelessConsonants)
            {
                consonantCount[c] = 0;
            }

            foreach (string word in words)
            {
                // Приводим слово к нижнему регистру
                string lowerWord = word.ToLower();

                // Множество глухих согласных в текущем слове (без повторов)
                HashSet<char> wordConsonants = new HashSet<char>();

                foreach (char c in lowerWord)
                {
                    if (VoicelessConsonants.Contains(c))
                    {
                        wordConsonants.Add(c);
                    }
                }

                // Увеличиваем счетчик для каждой найденной согласной
                foreach (char c in wordConsonants)
                {
                    consonantCount[c]++;
                }
            }

            // Находим глухие согласные, которые входят ровно в одно слово
            List<char> result = new List<char>();

            foreach (var pair in consonantCount)
            {
                if (pair.Value == 1)
                {
                    result.Add(pair.Key);
                }
            }

            // Сортируем в алфавитном порядке
            result.Sort();

            // Выводим результат
            Console.WriteLine("\nРЕЗУЛЬТАТ:");
            Console.WriteLine("----------------------------------------");

            if (result.Count > 0)
            {
                Console.WriteLine("Глухие согласные, которые входят ровно в одно слово:");
                foreach (char c in result)
                {
                    Console.WriteLine($"  • {c}");
                }
            }
            else
            {
                Console.WriteLine("Нет глухих согласных, которые входят ровно в одно слово.");
            }

            // Выводим статистику по всем глухим согласным
            Console.WriteLine("\nСТАТИСТИКА ПО ВСЕМ ГЛУХИМ СОГЛАСНЫМ:");
            foreach (var pair in consonantCount.OrderBy(p => p.Key))
            {
                Console.WriteLine($"  • {pair.Key}: встречается в {pair.Value} словах");
            }
        }
    }
}