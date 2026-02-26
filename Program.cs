using System;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "ЛАБОРАТОРНАЯ РАБОТА №3 - Вариант 4";

            bool exitRequested = false;

            while (!exitRequested)
            {
                ShowMainMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        RunTasks1to3();
                        break;
                    case "2":
                        RunTask4();
                        break;
                    case "3":
                        RunTask5();
                        break;
                    case "4":
                        RunTask6();
                        break;
                    case "5":
                        RunTask7();
                        break;
                    case "6":
                        RunTask8();
                        break;
                    case "7":
                        RunAllTasks();
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
            Console.WriteLine("         ЛАБОРАТОРНАЯ РАБОТА №3 - Вариант 4");
            Console.WriteLine("========================================================================");
            Console.WriteLine(" 1. Задания 1-3: Матрицы и операторы");
            Console.WriteLine(" 2. Задание 4: Бинарные файлы (числа)");
            Console.WriteLine(" 3. Задание 5: Бинарные файлы + XML (struct)");
            Console.WriteLine(" 4. Задание 6: Текстовые файлы (1 число в строке)");
            Console.WriteLine(" 5. Задание 7: Текстовые файлы (несколько чисел в строке)");
            Console.WriteLine(" 6. Задание 8: Текстовые файлы (текст)");
            Console.WriteLine(" 7. Выполнить все задания последовательно");
            Console.WriteLine(" 0. Выход");
            Console.WriteLine("========================================================================");
            Console.Write("Выберите опцию (0-7): ");
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void RunTasks1to3()
        {
            bool backToMenu = false;

            while (!backToMenu)
            {
                Console.Clear();
                Console.WriteLine("========================================================================");
                Console.WriteLine("         ЗАДАНИЯ 1-3: РАБОТА С МАТРИЦАМИ");
                Console.WriteLine("========================================================================");
                Console.WriteLine(" 1. Задание 1.4 - Создание матриц");
                Console.WriteLine(" 2. Задание 2.4 - Поиск банка с максимальным долгом");
                Console.WriteLine(" 3. Задание 3.4 - Вычисление выражения 2*A - B^T * C");
                Console.WriteLine(" 4. Сгенерировать случайные матрицы");
                Console.WriteLine(" 0. Назад в главное меню");
                Console.WriteLine("========================================================================");
                Console.Write("Выберите опцию: ");

                string choice = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            MatrixTasks.DemonstrateTask1();
                            break;
                        case "2":
                            MatrixTasks.DemonstrateTask2();
                            break;
                        case "3":
                            MatrixTasks.DemonstrateTask3();
                            break;
                        case "4":
                            MatrixTasks.GenerateRandomMatrices();
                            break;
                        case "0":
                            backToMenu = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }

                    if (!backToMenu) Pause();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Pause();
                }
            }
        }

        static void RunTask4()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЗАДАНИЕ 4: БИНАРНЫЕ ФАЙЛЫ (ЧИСЛА)");
            Console.WriteLine("         Вариант 4: Подсчет пар противоположных чисел");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            try
            {
                BinaryFileTasks.RunTask4();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        static void RunTask5()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЗАДАНИЕ 5: БИНАРНЫЕ ФАЙЛЫ + XML (STRUCT)");
            Console.WriteLine("         Вариант 4: Разница макс. и мин. веса багажа");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            try
            {
                StructFileTasks.RunTask5();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        static void RunTask6()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЗАДАНИЕ 6: ТЕКСТОВЫЕ ФАЙЛЫ (1 ЧИСЛО В СТРОКЕ)");
            Console.WriteLine("         Вариант 4: Проверка наличия нуля");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            try
            {
                TextFileSingleTasks.RunTask6();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        static void RunTask7()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЗАДАНИЕ 7: ТЕКСТОВЫЕ ФАЙЛЫ (НЕСКОЛЬКО ЧИСЕЛ В СТРОКЕ)");
            Console.WriteLine("         Вариант 4: Вычислить количество чётных элементов");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            try
            {
                TextFileMultipleTasks.RunTask7();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        static void RunTask8()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЗАДАНИЕ 8: ТЕКСТОВЫЕ ФАЙЛЫ (ТЕКСТ)");
            Console.WriteLine("         Вариант 4: Переписать строки, оканчивающиеся на заданный символ");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            try
            {
                TextFileStringTasks.RunTask8();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        static void RunAllTasks()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ВЫПОЛНЕНИЕ ВСЕХ ЗАДАНИЙ ПОСЛЕДОВАТЕЛЬНО");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            // Задания 1-3
            Console.WriteLine("ЗАДАНИЯ 1-3:");
            Console.WriteLine("-----------------------------------");
            try { MatrixTasks.RunAllTasks(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            // Задание 4
            Console.WriteLine("ЗАДАНИЕ 4:");
            Console.WriteLine("-----------------------------------");
            try { BinaryFileTasks.RunTask4(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            // Задание 5
            Console.WriteLine("ЗАДАНИЕ 5:");
            Console.WriteLine("-----------------------------------");
            try { StructFileTasks.RunTask5(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            // Задание 6
            Console.WriteLine("ЗАДАНИЕ 6:");
            Console.WriteLine("-----------------------------------");
            try { TextFileSingleTasks.RunTask6(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            // Задание 7
            Console.WriteLine("ЗАДАНИЕ 7:");
            Console.WriteLine("-----------------------------------");
            try { TextFileMultipleTasks.RunTask7(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();

            // Задание 8
            Console.WriteLine("ЗАДАНИЕ 8:");
            Console.WriteLine("-----------------------------------");
            try { TextFileStringTasks.RunTask8(); } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }

            Console.WriteLine("\n\nВсе задания выполнены!");
            Pause();
        }
    }
}