using System;
using System.Collections.Generic;
using ЛАБА_2.Entities;

namespace ЛАБА_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ShowHeader();

            while (true)
            {
                ShowMainMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DemonstrateTask1();
                        break;
                    case "2":
                        DemonstrateTask2();
                        break;
                    case "3":
                        DemonstrateTask3();
                        break;
                    case "4":
                        DemonstrateTask4();
                        break;
                    case "5":
                        DemonstrateTask5();
                        break;
                    case "6":
                        DemonstrateAll();
                        break;
                    case "0":
                        Console.WriteLine("\nСпасибо за использование программы! До свидания!");
                        return;
                    default:
                        ShowError("Неверный выбор. Пожалуйста, выберите пункт из меню.");
                        break;
                }

                Pause();
            }
        }

        static void ShowHeader()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         ЛАБОРАТОРНАЯ РАБОТА №2                           ║");
            Console.WriteLine("║         ОБЪЕКТНО-ОРИЕНТИРОВАННОЕ ПРОГРАММИРОВАНИЕ        ║");
            Console.WriteLine("║                    Вариант 4                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("\n┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                     ГЛАВНОЕ МЕНЮ                        │");
            Console.WriteLine("├────────────────────────────────────────────────────────┤");
            Console.WriteLine("│  1. Задание 1 (№3 Имена + №2 Человек) - 2 балла         │");
            Console.WriteLine("│  2. Задание 2 (№4 Сотрудники и отделы) - 1 балл         │");
            Console.WriteLine("│  3. Задание 3 (№3 Города) - 2 балла                      │");
            Console.WriteLine("│  4. Задание 4 (№5 Имена) - 1 балл                        │");
            Console.WriteLine("│  5. Задание 5 (№1 Пистолет) - 2 балла                    │");
            Console.WriteLine("│  6. Показать все задания сразу                          │");
            Console.WriteLine("│  0. Выход                                                │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.Write("\nВаш выбор: ");
        }

        // ===== ЗАДАНИЕ 1 (№3 Имена + №2 Человек) =====
        static void DemonstrateTask1()
        {
            ShowSubHeader("ЗАДАНИЕ 1.3 - Имена");

            Console.WriteLine("Создаём различные имена:\n");

            FullName name1 = new FullName("Клеопатра"); // Только имя
            FullName name2 = new FullName("Александр", "Пушкин", "Сергеевич"); // Полное имя
            FullName name3 = new FullName("Владимир", "Маяковский"); // Имя + фамилия

            Console.WriteLine("  1. " + name1);
            Console.WriteLine("  2. " + name2);
            Console.WriteLine("  3. " + name3);

            Console.WriteLine("\n┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  ЗАДАНИЕ 1.2 - Человек                                 │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘\n");

            Person person1 = new Person("Клеопатра", 152);
            Person person2 = new Person("Пушкин", 167);
            Person person3 = new Person("Владимир", 189);

            Console.WriteLine("  1. " + person1);
            Console.WriteLine("  2. " + person2);
            Console.WriteLine("  3. " + person3);

            Console.WriteLine("\n┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  Объединяем Имена и Человека (Задание 2.2)            │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘\n");

            Person personWithFullName1 = new Person(name1, 152);
            Person personWithFullName2 = new Person(name2, 167);
            Person personWithFullName3 = new Person(name3, 189);

            Console.WriteLine("  Человек с именем Клеопатра: " + personWithFullName1);
            Console.WriteLine("  Человек с именем Пушкин Александр Сергеевич: " + personWithFullName2);
            Console.WriteLine("  Человек с именем Маяковский Владимир: " + personWithFullName3);
        }

        // ===== ЗАДАНИЕ 2 (№4 Сотрудники и отделы) =====
        static void DemonstrateTask2()
        {
            ShowSubHeader("ЗАДАНИЕ 2.4 - Сотрудники и отделы");

            // Создаём отдел IT
            Department itDepartment = new Department("IT");

            // Создаём сотрудников
            Employee petrov = new Employee("Петров", itDepartment);
            Employee kozlov = new Employee("Козлов", itDepartment);
            Employee sidorov = new Employee("Сидоров", itDepartment);

            Console.WriteLine("  Созданы сотрудники:\n");
            Console.WriteLine("  • " + petrov);
            Console.WriteLine("  • " + kozlov);
            Console.WriteLine("  • " + sidorov);

            // Назначаем Козлова начальником
            itDepartment.SetChief(kozlov);

            Console.WriteLine("\n  После назначения Козлова начальником IT отдела:\n");
            Console.WriteLine("  • " + petrov);
            Console.WriteLine("  • " + kozlov);
            Console.WriteLine("  • " + sidorov);

            Console.WriteLine("\n  Информация об отделе:");
            Console.WriteLine("  " + itDepartment);
        }

        // ===== ЗАДАНИЕ 3 (№3 Города) =====
        static void DemonstrateTask3()
        {
            ShowSubHeader("ЗАДАНИЕ 3.3 - Города");

            Console.WriteLine("Создаём карту городов с путями:\n");

            // Создаем города согласно рисунку 2
            City moscow = new City("Москва");
            City spb = new City("Санкт-Петербург");
            City novgorod = new City("Новгород");
            City kazan = new City("Казань");
            City samara = new City("Самара");

            // Добавляем пути
            moscow.AddPath(spb, 700);
            moscow.AddPath(novgorod, 500);
            moscow.AddPath(kazan, 800);

            spb.AddPath(moscow, 700);
            spb.AddPath(novgorod, 200);

            novgorod.AddPath(moscow, 500);
            novgorod.AddPath(spb, 200);
            novgorod.AddPath(kazan, 900);

            kazan.AddPath(moscow, 800);
            kazan.AddPath(novgorod, 900);
            kazan.AddPath(samara, 400);

            samara.AddPath(kazan, 400);

            City[] cities = { moscow, spb, novgorod, kazan, samara };

            Console.WriteLine("  Города и связи между ними:\n");

            foreach (var city in cities)
            {
                Console.Write("  • ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{city.Name}");
                Console.ResetColor();
                Console.Write(" связан с: ");

                var paths = city.Paths;
                for (int i = 0; i < paths.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{paths[i].Destination.Name}");
                    Console.ResetColor();
                    Console.Write($"({paths[i].Cost} км)");

                    if (i < paths.Count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }

            // Визуализация
            DrawCityMap();
        }

        static void DrawCityMap()
        {
            Console.WriteLine("\n  Схема связей:");
            Console.WriteLine("  ┌─────────────────┐");
            Console.WriteLine("  │     МОСКВА      │");
            Console.WriteLine("  └────────┬────────┘");
            Console.WriteLine("           │");
            Console.WriteLine("     700   │   500   800");
            Console.WriteLine("           │          ");
            Console.WriteLine("  ┌────────▼────────┐ ┌────────▼────────┐ ┌────────▼────────┐");
            Console.WriteLine("  │ САНКТ-ПЕТЕРБУРГ │ │    НОВГОРОД     │ │     КАЗАНЬ      │");
            Console.WriteLine("  └────────┬────────┘ └────────┬────────┘ └────────┬────────┘");
            Console.WriteLine("           │                    │                    │");
            Console.WriteLine("           └──────────┬─────────┘                    │");
            Console.WriteLine("                    200 │                             │ 400");
            Console.WriteLine("                        │                             │");
            Console.WriteLine("                   ┌────▼─────┐                 ┌────▼─────┐");
            Console.WriteLine("                   │ НОВГОРОД │                 │  САМАРА  │");
            Console.WriteLine("                   └──────────┘                 └──────────┘");
        }

        // ===== ЗАДАНИЕ 4 (№5 Имена - изменение) =====
        static void DemonstrateTask4()
        {
            ShowSubHeader("ЗАДАНИЕ 4.5 - Имена (расширенная версия)");

            Console.WriteLine("Создаём имена разными способами:\n");

            // Только личное имя
            FullName name1 = new FullName("Клеопатра");

            // Личное имя + фамилия
            FullName name2 = new FullName("Александр", "Пушкин");

            // Все три параметра
            FullName name3 = new FullName("Александр", "Пушкин", "Сергеевич");

            // Личное имя + "фамилия"
            FullName name4 = new FullName("Христофор", "Бонифатьевич");

            Console.WriteLine("  1. Только имя: " + name1);
            Console.WriteLine("  2. Имя + фамилия: " + name2);
            Console.WriteLine("  3. Полное имя: " + name3);
            Console.WriteLine("  4. Имя + 'фамилия' (особый случай): " + name4);

            Console.WriteLine("\n┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  Создаём Человека с использованием Имени               │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘\n");

            // Создаём людей с разными вариантами имён
            Person person1 = new Person("Лев", 170);
            Person person2 = new Person(new FullName("Сергей", "Пушкин"), 168, person1);
            Person person3 = new Person("Александр", 167, person2);

            Console.WriteLine("  1. " + person1);
            Console.WriteLine("  2. " + person2);
            Console.WriteLine("  3. " + person3);
        }

        // ===== ЗАДАНИЕ 5 (№1 Пистолет) =====
        static void DemonstrateTask5()
        {
            ShowSubHeader("ЗАДАНИЕ 5.1 - Пистолет");

            Console.WriteLine("Создадим пистолет с 3 патронами и выстрелим 5 раз:\n");

            Gun gun = new Gun(3);
            Console.WriteLine($"  {gun}\n");

            Console.WriteLine("  Результаты выстрелов:");
            Console.WriteLine("  ┌─────────┬───────────────┐");
            Console.WriteLine("  │ Выстрел │   Результат   │");
            Console.WriteLine("  ├─────────┼───────────────┤");

            for (int i = 0; i < 5; i++)
            {
                string result = gun.Shoot();
                Console.Write($"  │    {i + 1}    │      ");
                Console.ForegroundColor = result == "Бах!" ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(result.PadRight(11));
                Console.ResetColor();
                Console.WriteLine("│");
            }

            Console.WriteLine("  └─────────┴───────────────┘");
            Console.WriteLine($"\n  После всех выстрелов: {gun}");
        }

        static void DemonstrateAll()
        {
            ShowSubHeader("ДЕМОНСТРАЦИЯ ВСЕХ ЗАДАНИЙ");

            Console.WriteLine("\n" + new string('═', 60));
            DemonstrateTask1();
            Console.WriteLine("\n" + new string('═', 60));
            DemonstrateTask2();
            Console.WriteLine("\n" + new string('═', 60));
            DemonstrateTask3();
            Console.WriteLine("\n" + new string('═', 60));
            DemonstrateTask4();
            Console.WriteLine("\n" + new string('═', 60));
            DemonstrateTask5();
        }

        static void ShowSubHeader(string title)
        {
            Console.WriteLine($"\n┌────────── {title} ──────────┐\n");
        }

        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Ошибка: {message}");
            Console.ResetColor();
        }

        static void Pause()
        {
            Console.WriteLine("\n┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  Нажмите любую клавишу для продолжения...              │");
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.ReadKey();
            Console.Clear();
            ShowHeader();
        }
    }
}