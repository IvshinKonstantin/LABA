using System;
using System.Collections.Generic;

namespace Lab4_Collections
{
    /// <summary>
    /// Задание 1.4: Составить программу, которая удаляет из списка L за каждым вхождением 
    /// элемента E один элемент, если такой есть, и он отличен от E.
    /// </summary>
    public static class Task1_List
    {
        public static void Demonstrate()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 1.4: LIST - УДАЛЕНИЕ ЗА КАЖДЫМ ВХОЖДЕНИЕМ E");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Создаем список
            List<int> list = new List<int>();

            // Заполняем список
            Console.WriteLine("Заполнение списка L:");
            FillList(list);

            // Выводим исходный список
            Console.WriteLine("\nИсходный список L:");
            PrintList(list);

            // Вводим элемент E
            Console.Write("\nВведите элемент E: ");
            if (!int.TryParse(Console.ReadLine(), out int e))
            {
                Console.WriteLine("Ошибка: введите целое число!");
                return;
            }

            // Копируем для демонстрации
            List<int> originalList = new List<int>(list);

            // Выполняем задание
            RemoveAfterEachOccurrence(list, e);

            // Выводим результат
            Console.WriteLine($"\nРезультат после удаления за каждым вхождением {e}:");
            PrintList(list);

            // Показываем пошагово
            Console.WriteLine("\nПошаговое выполнение:");
            StepByStepRemoval(originalList, e);
        }

        /// <summary>
        /// Заполнение списка с клавиатуры
        /// </summary>
        private static void FillList(List<int> list)
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
                    list.Add(value);
                }
                else
                {
                    Console.WriteLine("Ошибка: введите целое число!");
                    i--;
                }
            }
        }

        /// <summary>
        /// Вывод списка
        /// </summary>
        private static void PrintList(List<int> list)
        {
            Console.Write("Список: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
                if (i < list.Count - 1)
                    Console.Write("→ ");
            }
            Console.WriteLine($" (всего: {list.Count})");
        }

        /// <summary>
        /// Задание 1.4: Удаление за каждым вхождением элемента E один элемент, если он отличен от E
        /// </summary>
        public static void RemoveAfterEachOccurrence(List<int> list, int e)
        {
            if (list == null || list.Count == 0)
                return;

            // Идем с конца, чтобы не нарушать индексацию при удалении
            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (list[i] == e && i + 1 < list.Count && list[i + 1] != e)
                {
                    list.RemoveAt(i + 1);
                }
            }

            // Проверяем последний элемент (для него следующий - первый, если список не пуст)
            if (list.Count > 1 && list[list.Count - 1] == e && list[0] != e)
            {
                list.RemoveAt(0);
            }
        }

        /// <summary>
        /// Пошаговая демонстрация удаления
        /// </summary>
        private static void StepByStepRemoval(List<int> list, int e)
        {
            Console.WriteLine($"Исходный список: {string.Join(" → ", list)}");
            Console.WriteLine($"Ищем элемент E = {e}");

            List<int> workingList = new List<int>(list);
            int step = 1;

            for (int i = 0; i < workingList.Count; i++)
            {
                if (workingList[i] == e)
                {
                    int nextIndex = (i + 1) % workingList.Count;
                    if (workingList[nextIndex] != e)
                    {
                        Console.WriteLine($"  Шаг {step++}: Нашли {e} на позиции {i + 1}, удаляем следующий элемент {workingList[nextIndex]} на позиции {nextIndex + 1}");
                        workingList.RemoveAt(nextIndex);
                        // После удаления индексы смещаются
                        i--;
                    }
                }
            }

            Console.WriteLine($"Результат: {string.Join(" → ", workingList)}");
        }
    }
}