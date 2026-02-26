using System;

namespace Lab4_RightTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "ЛАБОРАТОРНАЯ РАБОТА №4 - Вариант 4 (RightTriangle)";

            bool exitRequested = false;

            while (!exitRequested)
            {
                ShowMainMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        TriangleTester.TestConstructorsAndMethods();
                        break;
                    case "2":
                        TriangleTester.TestOperators();
                        break;
                    case "3":
                        TriangleTester.TestAll();
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
            Console.WriteLine("         ЛАБОРАТОРНАЯ РАБОТА №4 - Вариант 4 (RightTriangle)");
            Console.WriteLine("========================================================================");
            Console.WriteLine(" 1. Задание 6.4 - Тестирование конструкторов и методов");
            Console.WriteLine(" 2. Задание 7.4 - Тестирование перегруженных операций");
            Console.WriteLine(" 3. Задание 6-7.4 - Полное тестирование");
            Console.WriteLine(" 0. Выход");
            Console.WriteLine("========================================================================");
            Console.Write("Выберите опцию (0-3): ");
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}