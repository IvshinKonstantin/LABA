using System;

namespace Lab4_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "ЛАБОРАТОРНАЯ РАБОТА №4 - Вариант 4 (Коллекции)";

            bool exitRequested = false;

            while (!exitRequested)
            {
                ShowMainMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Task1_List.Demonstrate();
                        break;
                    case "2":
                        Task2_LinkedList.Demonstrate();
                        break;
                    case "3":
                        Task3_HashSet.Demonstrate();
                        break;
                    case "4":
                        Task4_HashSetFile.Demonstrate();
                        break;
                    case "5":
                        Task5_Dictionary.Demonstrate();
                        break;
                    case "0":
                        exitRequested = true;
                        Console.WriteLine("Программа завершена. Спасибо за работу!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите опцию из меню.");
                        Pause();
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЛАБОРАТОРНАЯ РАБОТА №4 - Вариант 4 (Коллекции)");
            Console.WriteLine("========================================================================");
            Console.WriteLine(" 1. Задание 1.4 - List (удаление за каждым вхождением E)");
            Console.WriteLine(" 2. Задание 2.4 - LinkedList (проверка равенства по кругу)");
            Console.WriteLine(" 3. Задание 3.4 - HashSet (страны и туристы)");
            Console.WriteLine(" 4. Задание 4.4 - HashSet + файл (глухие согласные)");
            Console.WriteLine(" 5. Задание 5.4 - Dictionary (абитуриенты)");
            Console.WriteLine(" 0. Выход");
            Console.WriteLine("========================================================================");
            Console.Write("Выберите опцию (0-5): ");
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}