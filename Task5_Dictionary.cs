using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4_Collections
{
    /// <summary>
    /// Задание 5.4: Абитуриенты и тестирование
    /// Вывести фамилии и имена абитуриентов, не допущенных к сдаче экзаменов,
    /// в алфавитном порядке.
    /// </summary>
    public static class Task5_Dictionary
    {
        private static readonly string InputFilePath = "applicants.txt";
        private static readonly Random Random = new Random();

        public static void Demonstrate()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 5.4: DICTIONARY - АБИТУРИЕНТЫ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Генерируем файл с данными абитуриентов
            GenerateApplicantsFile(InputFilePath);

            // Читаем и выводим данные
            List<Applicant> applicants = ReadApplicantsFile(InputFilePath);

            if (applicants.Count == 0)
            {
                Console.WriteLine("Нет данных об абитуриентах!");
                return;
            }

            Console.WriteLine("\nДанные обо всех абитуриентах:");
            Console.WriteLine("----------------------------------------");
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"{applicant.LastName} {applicant.FirstName}: {applicant.Score1} {applicant.Score2} - Сумма: {applicant.Score1 + applicant.Score2}");
            }
            Console.WriteLine("----------------------------------------");

            // Находим допущенных и не допущенных
            var (admitted, notAdmitted) = AnalyzeApplicants(applicants);

            // Выводим результаты
            Console.WriteLine($"\nРЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ:");
            Console.WriteLine($"Всего абитуриентов: {applicants.Count}");
            Console.WriteLine($"Допущено к экзаменам: {admitted.Count}");
            Console.WriteLine($"Не допущено: {notAdmitted.Count}");

            Console.WriteLine("\nАБИТУРИЕНТЫ, НЕ ДОПУЩЕННЫЕ К ЭКЗАМЕНАМ (в алфавитном порядке):");
            if (notAdmitted.Count > 0)
            {
                foreach (var applicant in notAdmitted)
                {
                    Console.WriteLine($"  • {applicant.LastName} {applicant.FirstName} - баллы: {applicant.Score1} {applicant.Score2}");
                }
            }
            else
            {
                Console.WriteLine("  • Все абитуриенты допущены!");
            }

            // Статистика по баллам
            ShowScoreStatistics(applicants);
        }

        /// <summary>
        /// Класс для хранения информации об абитуриенте
        /// </summary>
        private class Applicant
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int Score1 { get; set; }
            public int Score2 { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {Score1} {Score2}";
            }
        }

        /// <summary>
        /// Генерация файла с данными абитуриентов
        /// </summary>
        private static void GenerateApplicantsFile(string filePath)
        {
            string[] lastNames = {
                "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Васильев",
                "Михайлов", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
                "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов", "Андреев",
                "Макаров", "Никитин", "Захаров", "Зайцев", "Соловьев", "Борисов", "Яковлев"
            };

            string[] firstNames = {
                "Александр", "Сергей", "Дмитрий", "Андрей", "Алексей", "Максим", "Евгений",
                "Иван", "Михаил", "Николай", "Павел", "Роман", "Владимир", "Олег",
                "Анна", "Мария", "Елена", "Ольга", "Наталья", "Татьяна", "Ирина",
                "Екатерина", "Ксения", "Дарья", "Юлия", "Анастасия", "Виктория", "Светлана"
            };

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                int count = Random.Next(10, 21); // 10-20 абитуриентов
                writer.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    string lastName = lastNames[Random.Next(lastNames.Length)];
                    string firstName = firstNames[Random.Next(firstNames.Length)];

                    // Генерируем баллы от 0 до 100
                    int score1 = Random.Next(0, 101);
                    int score2 = Random.Next(0, 101);

                    writer.WriteLine($"{lastName} {firstName} {score1} {score2}");
                }
            }

            Console.WriteLine($"Сгенерирован файл {filePath} с данными абитуриентов");
        }

        /// <summary>
        /// Чтение данных абитуриентов из файла
        /// </summary>
        private static List<Applicant> ReadApplicantsFile(string filePath)
        {
            var applicants = new List<Applicant>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден");
            }

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            if (lines.Length == 0)
            {
                return applicants;
            }

            // Первая строка - количество абитуриентов
            if (!int.TryParse(lines[0], out int count))
            {
                count = lines.Length - 1;
            }

            for (int i = 1; i < lines.Length && i <= count; i++)
            {
                string[] parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 4)
                {
                    string lastName = parts[0];
                    string firstName = parts[1];

                    if (int.TryParse(parts[2], out int score1) &&
                        int.TryParse(parts[3], out int score2))
                    {
                        applicants.Add(new Applicant
                        {
                            LastName = lastName,
                            FirstName = firstName,
                            Score1 = score1,
                            Score2 = score2
                        });
                    }
                }
            }

            return applicants;
        }

        /// <summary>
        /// Задание 5.4: Анализ абитуриентов
        /// </summary>
        private static (List<Applicant> admitted, List<Applicant> notAdmitted) AnalyzeApplicants(List<Applicant> applicants)
        {
            var admitted = new List<Applicant>();
            var notAdmitted = new List<Applicant>();

            foreach (var applicant in applicants)
            {
                // Проверяем условия допуска: не менее 30 баллов по каждому предмету
                if (applicant.Score1 >= 30 && applicant.Score2 >= 30)
                {
                    admitted.Add(applicant);
                }
                else
                {
                    notAdmitted.Add(applicant);
                }
            }

            // Сортируем не допущенных по фамилии и имени
            notAdmitted = notAdmitted
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .ToList();

            return (admitted, notAdmitted);
        }

        /// <summary>
        /// Статистика по баллам
        /// </summary>
        private static void ShowScoreStatistics(List<Applicant> applicants)
        {
            Console.WriteLine("\nСТАТИСТИКА ПО БАЛЛАМ:");

            if (applicants.Count == 0) return;

            double avgScore1 = applicants.Average(a => a.Score1);
            double avgScore2 = applicants.Average(a => a.Score2);
            double avgTotal = applicants.Average(a => a.Score1 + a.Score2);

            Console.WriteLine($"  • Средний балл по первому предмету: {avgScore1:F2}");
            Console.WriteLine($"  • Средний балл по второму предмету: {avgScore2:F2}");
            Console.WriteLine($"  • Средняя сумма баллов: {avgTotal:F2}");

            int maxScore = applicants.Max(a => a.Score1 + a.Score2);
            int minScore = applicants.Min(a => a.Score1 + a.Score2);

            Console.WriteLine($"  • Максимальная сумма баллов: {maxScore}");
            Console.WriteLine($"  • Минимальная сумма баллов: {minScore}");

            var bestApplicant = applicants.OrderByDescending(a => a.Score1 + a.Score2).First();
            Console.WriteLine($"  • Лучший абитуриент: {bestApplicant.LastName} {bestApplicant.FirstName} ({bestApplicant.Score1 + bestApplicant.Score2} баллов)");
        }
    }
}