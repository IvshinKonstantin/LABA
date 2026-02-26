using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_Collections
{
    /// <summary>
    /// Задание 3.4: Есть перечень стран, популярных у туристов. 
    /// Определить для каждой страны, какие из них посетили все n туристов, 
    /// какие — некоторые из туристов, и какие — никто из туристов.
    /// </summary>
    public static class Task3_HashSet
    {
        private static readonly Random Random = new Random();

        public static void Demonstrate()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 3.4: HASHSET - СТРАНЫ И ТУРИСТЫ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Перечень стран
            string[] allCountries = {
                "Россия", "Франция", "Италия", "Испания", "Германия",
                "Великобритания", "США", "Канада", "Япония", "Китай",
                "Таиланд", "Турция", "Египет", "Греция", "Мексика",
                "Бразилия", "Австралия", "Индия", "Чехия", "Венгрия"
            };

            Console.Write("Введите количество туристов n: ");
            if (!int.TryParse(Console.ReadLine(), out int touristCount) || touristCount <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное число!");
                return;
            }

            // Генерируем данные о посещениях
            var touristVisits = GenerateTouristVisits(touristCount, allCountries);

            // Выводим информацию
            PrintTouristVisits(touristVisits);

            // Анализируем посещения
            AnalyzeVisits(touristVisits, allCountries);
        }

        /// <summary>
        /// Генерация данных о посещениях туристов
        /// </summary>
        private static List<HashSet<string>> GenerateTouristVisits(int touristCount, string[] allCountries)
        {
            var visits = new List<HashSet<string>>();

            for (int i = 0; i < touristCount; i++)
            {
                var touristVisited = new HashSet<string>();

                // Каждый турист посещает от 3 до 10 стран
                int visitedCount = Random.Next(3, Math.Min(11, allCountries.Length + 1));

                // Выбираем случайные страны
                var availableCountries = new List<string>(allCountries);
                for (int j = 0; j < visitedCount; j++)
                {
                    int index = Random.Next(availableCountries.Count);
                    touristVisited.Add(availableCountries[index]);
                    availableCountries.RemoveAt(index);
                }

                visits.Add(touristVisited);
            }

            return visits;
        }

        /// <summary>
        /// Вывод информации о посещениях
        /// </summary>
        private static void PrintTouristVisits(List<HashSet<string>> visits)
        {
            Console.WriteLine("\nИнформация о посещениях туристов:");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < visits.Count; i++)
            {
                Console.WriteLine($"Турист {i + 1}: {string.Join(", ", visits[i])}");
            }
            Console.WriteLine("----------------------------------------");
        }

        /// <summary>
        /// Задание 3.4: Анализ посещений стран
        /// </summary>
        private static void AnalyzeVisits(List<HashSet<string>> touristVisits, string[] allCountries)
        {
            if (touristVisits == null || touristVisits.Count == 0)
            {
                Console.WriteLine("Нет данных о туристах!");
                return;
            }

            int touristCount = touristVisits.Count;

            // Множество стран, которые посетили все туристы
            var allVisited = new HashSet<string>(allCountries);
            foreach (var visit in touristVisits)
            {
                allVisited.IntersectWith(visit);
            }

            // Множество стран, которые посетили некоторые туристы
            var someVisited = new HashSet<string>();
            foreach (var visit in touristVisits)
            {
                someVisited.UnionWith(visit);
            }
            someVisited.ExceptWith(allVisited);

            // Множество стран, которые не посетил никто
            var noneVisited = new HashSet<string>(allCountries);
            noneVisited.ExceptWith(someVisited);
            noneVisited.ExceptWith(allVisited);

            // Вывод результатов
            Console.WriteLine("\nРЕЗУЛЬТАТЫ АНАЛИЗА:");
            Console.WriteLine("========================================");

            Console.WriteLine($"\n1. Страны, которые посетили ВСЕ {touristCount} туристов:");
            if (allVisited.Count > 0)
            {
                foreach (var country in allVisited.OrderBy(c => c))
                {
                    Console.WriteLine($"   • {country}");
                }
            }
            else
            {
                Console.WriteLine("   • Нет таких стран");
            }

            Console.WriteLine($"\n2. Страны, которые посетили НЕКОТОРЫЕ туристы:");
            if (someVisited.Count > 0)
            {
                foreach (var country in someVisited.OrderBy(c => c))
                {
                    int count = touristVisits.Count(v => v.Contains(country));
                    Console.WriteLine($"   • {country} (посетили {count} туристов)");
                }
            }
            else
            {
                Console.WriteLine("   • Нет таких стран");
            }

            Console.WriteLine($"\n3. Страны, которые НЕ ПОСЕТИЛ ни один турист:");
            if (noneVisited.Count > 0)
            {
                foreach (var country in noneVisited.OrderBy(c => c))
                {
                    Console.WriteLine($"   • {country}");
                }
            }
            else
            {
                Console.WriteLine("   • Нет таких стран");
            }

            // Статистика
            Console.WriteLine("\nСТАТИСТИКА:");
            Console.WriteLine($"   Всего стран в перечне: {allCountries.Length}");
            Console.WriteLine($"   Посетили все: {allVisited.Count}");
            Console.WriteLine($"   Посетили некоторые: {someVisited.Count}");
            Console.WriteLine($"   Не посетил никто: {noneVisited.Count}");
        }
    }
}