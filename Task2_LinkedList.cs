using System;
using System.Collections.Generic;

namespace Lab4_Collections
{
    /// <summary>
    /// Задание 2.4: Определить, есть ли в списке L хотя бы один элемент, который равен 
    /// следующему за ним (по кругу) элементу (первый элемент считать следующим для последнего).
    /// </summary>
    public static class Task2_LinkedList
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 2.4: LINKEDLIST - ПРОВЕРКА РАВЕНСТВА ПО КРУГУ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Создаем связанный список
            LinkedList<int> list = new LinkedList<int>();

            // Заполняем список
            Console.WriteLine("Заполнение списка L:");
            FillLinkedList(list);

            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }

            // Выводим исходный список
            Console.WriteLine("\nИсходный список L (по кругу):");
            PrintCircular(list);

            // Выполняем задание
            bool hasEqualNeighbors = HasEqualCircularNeighbor(list);

            // Выводим результат
            Console.WriteLine($"\nРезультат проверки: {(hasEqualNeighbors ? "ДА" : "НЕТ")}");
            Console.WriteLine(hasEqualNeighbors
                ? "В списке есть элемент, равный следующему за ним по кругу."
                : "В списке нет элементов, равных следующим за ними по кругу.");

            // Показываем все пары
            ShowAllPairs(list);
        }

        /// <summary>
        /// Заполнение связанного списка с клавиатуры
        /// </summary>
        private static void FillLinkedList(LinkedList<int> list)
        {
            Console.Write("Введите количество элементов: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Ошибка: введите положительное число!");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    list.AddLast(value);
                }
                else
                {
                    Console.WriteLine("Ошибка: введите целое число!");
                    i--;
                }
            }
        }

        /// <summary>
        /// Вывод списка по кругу
        /// </summary>
        private static void PrintCircular(LinkedList<int> list)
        {
            if (list.Count == 0) return;

            Console.Write("Список: ");
            LinkedListNode<int> current = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{current.Value} ");
                if (i < list.Count - 1)
                {
                    LinkedListNode<int> next = current.Next ?? list.First;
                    Console.Write($"→ (след: {next.Value})  ");
                }
                current = current.Next ?? list.First;
            }
            Console.WriteLine($"\nПоследний → первый: {list.Last.Value} → {list.First.Value}");
        }

        /// <summary>
        /// Задание 2.4: Проверка наличия элемента, равного следующему по кругу
        /// </summary>
        public static bool HasEqualCircularNeighbor(LinkedList<int> list)
        {
            if (list == null || list.Count < 2)
                return false;

            LinkedListNode<int> current = list.First;

            for (int i = 0; i < list.Count; i++)
            {
                LinkedListNode<int> next = current.Next ?? list.First;

                if (current.Value == next.Value)
                {
                    return true;
                }

                current = current.Next ?? list.First;
            }

            return false;
        }

        /// <summary>
        /// Показать все пары элементов
        /// </summary>
        private static void ShowAllPairs(LinkedList<int> list)
        {
            if (list.Count < 2)
            {
                Console.WriteLine("\nДля проверки нужно минимум 2 элемента.");
                return;
            }

            Console.WriteLine("\nВсе пары элементов (текущий → следующий по кругу):");

            LinkedListNode<int> current = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                LinkedListNode<int> next = current.Next ?? list.First;

                Console.Write($"  {current.Value} → {next.Value}");
                if (current.Value == next.Value)
                {
                    Console.WriteLine("  <--- РАВНЫ!");
                }
                else
                {
                    Console.WriteLine();
                }

                current = current.Next ?? list.First;
            }
        }
    }
}