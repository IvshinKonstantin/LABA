using System;
using Lab6_Interfaces.Models;
using Lab6_Interfaces.Utils;
using Lab6_Interfaces.Tests;

namespace Lab6_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "ЛАБОРАТОРНАЯ РАБОТА №6 - Интерфейсы и шаблоны ООП";

            bool exitRequested = false;

            while (!exitRequested)
            {
                ShowMainMenu();

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        TestCatTasks();
                        break;
                    case "2":
                        TestFractionTasks();
                        break;
                    case "3":
                        TestAllTasks();
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

        private static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("========================================================================");
            Console.WriteLine("         ЛАБОРАТОРНАЯ РАБОТА №6 - Интерфейсы и шаблоны ООП");
            Console.WriteLine("========================================================================");
            Console.WriteLine(" 1. Задание 1 - Кот (мяуканье)");
            Console.WriteLine(" 2. Задание 2 - Дроби (арифметика и интерфейсы)");
            Console.WriteLine(" 3. Выполнить все задания");
            Console.WriteLine(" 0. Выход");
            Console.WriteLine("========================================================================");
            Console.Write("Выберите опцию (0-3): ");
        }

        private static void TestCatTasks()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 1.1-1.3: КОТ И МЯУКАНЬЕ");
            Console.WriteLine("=========================================================================");

            // Задание 1.1: Создание кота и мяуканье
            Console.WriteLine("\n--- Задание 1.1: Создание кота и мяуканье ---");
            Cat barsik = new Cat("Барсик");
            Console.WriteLine($"Создан кот: {barsik}");

            Console.WriteLine("\nМяуканье один раз:");
            barsik.Meow();

            Console.WriteLine("\nМяуканье три раза:");
            barsik.Meow(3);

            // Задание 1.2: Интерфейс Мяуканье
            Console.WriteLine("\n--- Задание 1.2: Интерфейс IMeowable ---");

            Cat murzik = new Cat("Мурзик");
            Cat vaska = new Cat("Васька");
            Dog sharik = new Dog("Шарик");

            Console.WriteLine("\nПередаем несколько котов и собаку в метод MeowCare:");
            MeowHelper.MeowCare(barsik, murzik, vaska, sharik);

            // Задание 1.3: Количество мяуканий
            Console.WriteLine("\n--- Задание 1.3: Подсчет количества мяуканий ---");

            Cat originalCat = new Cat("Рыжик");
            MeowCounter decoratedCat = new MeowCounter(originalCat);

            Console.WriteLine("Передаем кота в метод MeowCare для мяуканья...");
            MeowHelper.MeowCare(decoratedCat, decoratedCat);

            Console.WriteLine($"\nСтатистика: кот {originalCat.Name} мяукал {decoratedCat.MeowCount} раз");

            Pause();
        }

        private static void TestFractionTasks()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 2.1-2.4: ДРОБИ");
            Console.WriteLine("=========================================================================");

            // Задание 2.1: Арифметика дробей
            Console.WriteLine("\n--- Задание 2.1: Арифметические операции ---");

            try
            {
                Fraction f1 = new Fraction(1, 2);
                Fraction f2 = new Fraction(2, 3);
                Fraction f3 = new Fraction(3, 4);
                Fraction f4 = new Fraction(-5, 6);

                Console.WriteLine($"Созданы дроби:");
                Console.WriteLine($"  f1 = {f1}");
                Console.WriteLine($"  f2 = {f2}");
                Console.WriteLine($"  f3 = {f3}");
                Console.WriteLine($"  f4 = {f4}");

                Console.WriteLine($"\n{f1} + {f2} = {f1.Add(f2)}");
                Console.WriteLine($"{f2} - {f3} = {f2.Subtract(f3)}");
                Console.WriteLine($"{f1} * {f2} = {f1.Multiply(f2)}");
                Console.WriteLine($"{f3} / {f4} = {f3.Divide(f4)}");

                Console.WriteLine($"\n{f1} + 2 = {f1.Add(2)}");
                Console.WriteLine($"{f2} * 3 = {f2.Multiply(3)}");

                Console.WriteLine($"\n{f1}.Add({f2}).Divide({f3}).Subtract(5) = " +
                    $"{f1.Add(f2).Divide(f3).Subtract(5)}");

                // Задание 2.2: Сравнение дробей
                Console.WriteLine("\n--- Задание 2.2: Сравнение дробей ---");

                Fraction f5 = new Fraction(1, 2);
                Fraction f6 = new Fraction(2, 4);

                Console.WriteLine($"f1 = {f1}");
                Console.WriteLine($"f5 = {f5}");
                Console.WriteLine($"f6 = {f6}");

                Console.WriteLine($"f1 == f5: {f1.Equals(f5)}");
                Console.WriteLine($"f1 == f6: {f1.Equals(f6)}");
                Console.WriteLine($"f1 == f2: {f1.Equals(f2)}");

                // Задание 2.3: Клонирование
                Console.WriteLine("\n--- Задание 2.3: Клонирование дроби ---");

                Fraction original = new Fraction(7, 8);
                Fraction clone = (Fraction)original.Clone();

                Console.WriteLine($"Оригинал: {original}");
                Console.WriteLine($"Клон: {clone}");
                Console.WriteLine($"Оригинал и клон - один объект? {ReferenceEquals(original, clone)}");

                clone = clone.Multiply(2);
                Console.WriteLine($"После изменения клона (умножили на 2):");
                Console.WriteLine($"  Оригинал: {original}");
                Console.WriteLine($"  Клон: {clone}");

                // Задание 2.4: Интерфейс IFraction с кэшированием
                Console.WriteLine("\n--- Задание 2.4: Интерфейс IFraction с кэшированием ---");

                CachedFraction cached = new CachedFraction(3, 8);
                Console.WriteLine($"Создана дробь с кэшированием: {cached}");

                Console.WriteLine($"\nПолучаем вещественное значение (первый раз - вычисляем):");
                Console.WriteLine($"  {cached} = {cached.GetDoubleValue()}");

                Console.WriteLine($"\nПолучаем вещественное значение (второй раз - берем из кэша):");
                Console.WriteLine($"  {cached} = {cached.GetDoubleValue()}");

                Console.WriteLine($"\nИзменяем числитель на 5...");
                cached.SetNumerator(5);
                Console.WriteLine($"  Теперь дробь: {cached}");

                Console.WriteLine($"\nПолучаем вещественное значение (после изменения - пересчет):");
                Console.WriteLine($"  {cached} = {cached.GetDoubleValue()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Pause();
        }

        private static void TestAllTasks()
        {
            TestCatTasks();
            Console.WriteLine("\n" + new string('=', 70) + "\n");
            TestFractionTasks();
        }

        private static void Pause()
        {
            Console.WriteLine("\n--- Нажмите любую клавишу для продолжения ---");
            Console.ReadKey();
        }
    }
}