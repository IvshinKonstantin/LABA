using System;
using System.Collections.Generic;

namespace Lab4_RightTriangle
{
    /// <summary>
    /// Класс для тестирования RightTriangle
    /// </summary>
    public static class TriangleTester
    {
        /// <summary>
        /// Тестирование конструкторов и методов (Задание 6.4)
        /// </summary>
        public static void TestConstructorsAndMethods()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 6.4: ТЕСТИРОВАНИЕ КОНСТРУКТОРОВ И МЕТОДОВ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Тест 1: Конструктор по умолчанию
            Console.WriteLine("1. Конструктор по умолчанию:");
            RightTriangle t1 = new RightTriangle();
            Console.WriteLine(t1.ToString());
            Console.WriteLine($"   Площадь: {t1.CalculateArea():F3}");
            Console.WriteLine($"   Гипотенуза: {t1.CalculateHypotenuse():F3}");
            Console.WriteLine($"   Существует: {t1.Exists()}");

            PauseForTest();

            // Тест 2: Конструктор с параметрами
            Console.WriteLine("\n2. Конструктор с параметрами (a = 3, b = 4):");
            try
            {
                RightTriangle t2 = new RightTriangle(3, 4);
                Console.WriteLine(t2.ToString());
                Console.WriteLine($"   Площадь: {t2.CalculateArea():F3}");
                Console.WriteLine($"   Гипотенуза: {t2.CalculateHypotenuse():F3}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка: {ex.Message}");
            }

            PauseForTest();

            // Тест 3: Конструктор копирования
            Console.WriteLine("\n3. Конструктор копирования:");
            RightTriangle t3 = new RightTriangle(5, 12);
            RightTriangle t4 = new RightTriangle(t3);
            Console.WriteLine("Оригинал:");
            Console.WriteLine(t3.ToString());
            Console.WriteLine("Копия:");
            Console.WriteLine(t4.ToString());

            PauseForTest();

            // Тест 4: Проверка на некорректные данные
            Console.WriteLine("\n4. Проверка на некорректные данные:");
            try
            {
                Console.WriteLine("   Попытка создать треугольник с a = -2, b = 3");
                RightTriangle t5 = new RightTriangle(-2, 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка (ожидаемо): {ex.Message}");
            }

            try
            {
                Console.WriteLine("   Попытка создать треугольник с a = 0, b = 5");
                RightTriangle t6 = new RightTriangle(0, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка (ожидаемо): {ex.Message}");
            }

            // Тест 5: Ввод с клавиатуры
            Console.WriteLine("\n5. Создание треугольника с вводом от пользователя:");
            try
            {
                RightTriangle t7 = CreateTriangleFromInput();
                if (t7 != null)
                {
                    Console.WriteLine("\nСозданный треугольник:");
                    Console.WriteLine(t7.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Тестирование перегруженных операций (Задание 7.4)
        /// </summary>
        public static void TestOperators()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 7.4: ТЕСТИРОВАНИЕ ПЕРЕГРУЖЕННЫХ ОПЕРАЦИЙ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            // Создаем треугольники для тестов
            RightTriangle t1 = new RightTriangle(3, 4);
            RightTriangle t2 = new RightTriangle(5, 12);
            RightTriangle t3 = new RightTriangle(6, 8);
            RightTriangle t4 = new RightTriangle(1, 1);

            Console.WriteLine("Исходные треугольники:");
            Console.WriteLine($"t1: a=3, b=4, площадь={t1.CalculateArea():F3}");
            Console.WriteLine($"t2: a=5, b=12, площадь={t2.CalculateArea():F3}");
            Console.WriteLine($"t3: a=6, b=8, площадь={t3.CalculateArea():F3}");
            Console.WriteLine($"t4: a=1, b=1, площадь={t4.CalculateArea():F3}");

            PauseForTest();

            // Тест 1: Унарный оператор ++
            Console.WriteLine("\n1. Тест унарного оператора ++:");
            RightTriangle t1Inc = ++t1;
            Console.WriteLine($"   t1 (оригинал): площадь={t1.CalculateArea():F3}");
            Console.WriteLine($"   ++t1: a={t1Inc.A:F3}, b={t1Inc.B:F3}, площадь={t1Inc.CalculateArea():F3}");

            PauseForTest();

            // Тест 2: Унарный оператор --
            Console.WriteLine("\n2. Тест унарного оператора --:");
            RightTriangle t2Dec = --t2;
            Console.WriteLine($"   t2 (оригинал): площадь={t2.CalculateArea():F3}");
            Console.WriteLine($"   --t2: a={t2Dec.A:F3}, b={t2Dec.B:F3}, площадь={t2Dec.CalculateArea():F3}");

            PauseForTest();

            // Тест 3: Операция приведения к double (явная)
            Console.WriteLine("\n3. Тест явного приведения к double:");
            double area1 = (double)t1;
            double area2 = (double)t2;
            Console.WriteLine($"   (double)t1 = {area1:F3} (площадь)");
            Console.WriteLine($"   (double)t2 = {area2:F3} (площадь)");

            PauseForTest();

            // Тест 4: Операция приведения к bool (неявная)
            Console.WriteLine("\n4. Тест неявного приведения к bool:");
            Console.WriteLine($"   t1 существует? {((bool)t1 ? "Да" : "Нет")}");

            RightTriangle tInvalid = null;
            Console.WriteLine($"   null треугольник существует? {((bool)tInvalid ? "Да" : "Нет")}");

            PauseForTest();

            // Тест 5: Бинарные операторы сравнения площадей
            Console.WriteLine("\n5. Тест бинарных операторов сравнения площадей:");
            Console.WriteLine($"   t1 (площадь={t1.CalculateArea():F3}) <= t2 (площадь={t2.CalculateArea():F3})? {t1 <= t2}");
            Console.WriteLine($"   t1 (площадь={t1.CalculateArea():F3}) >= t2 (площадь={t2.CalculateArea():F3})? {t1 >= t2}");
            Console.WriteLine($"   t1 (площадь={t1.CalculateArea():F3}) < t2 (площадь={t2.CalculateArea():F3})? {t1 < t2}");
            Console.WriteLine($"   t1 (площадь={t1.CalculateArea():F3}) > t2 (площадь={t2.CalculateArea():F3})? {t1 > t2}");

            PauseForTest();

            // Тест 6: Сравнение равных площадей
            Console.WriteLine("\n6. Тест сравнения треугольников с равными площадями:");
            Console.WriteLine($"   t1 (площадь={t1.CalculateArea():F3})");
            Console.WriteLine($"   t3 (площадь={t3.CalculateArea():F3})");
            Console.WriteLine($"   t1 <= t3? {t1 <= t3}");
            Console.WriteLine($"   t1 >= t3? {t1 >= t3}");
            Console.WriteLine($"   t1 == t3 по площади? {Math.Abs(t1.CalculateArea() - t3.CalculateArea()) < 0.0001}");

            PauseForTest();

            // Тест 7: Комплексный пример
            Console.WriteLine("\n7. Комплексный пример:");
            RightTriangle t = new RightTriangle(2, 3);
            Console.WriteLine($"   Начальный треугольник: {t}");

            t = ++t;
            Console.WriteLine($"   После ++: {t}");

            t = --t;
            Console.WriteLine($"   После --: {t}");

            double area = (double)t;
            Console.WriteLine($"   Площадь как double: {area:F3}");

            bool exists = t;
            Console.WriteLine($"   Существует как bool: {exists}");
        }

        /// <summary>
        /// Полное тестирование
        /// </summary>
        public static void TestAll()
        {
            TestConstructorsAndMethods();
            Console.WriteLine("\n" + new string('=', 70) + "\n");
            TestOperators();
        }

        /// <summary>
        /// Создание треугольника из пользовательского ввода
        /// </summary>
        private static RightTriangle CreateTriangleFromInput()
        {
            Console.Write("   Введите длину катета a: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("   Ошибка: введите число!");
                return null;
            }

            Console.Write("   Введите длину катета b: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("   Ошибка: введите число!");
                return null;
            }

            return new RightTriangle(a, b);
        }

        /// <summary>
        /// Пауза между тестами
        /// </summary>
        private static void PauseForTest()
        {
            Console.WriteLine("\n--- Нажмите любую клавишу для продолжения ---");
            Console.ReadKey();
        }
    }
}