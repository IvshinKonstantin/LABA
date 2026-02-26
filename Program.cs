using System;

class Program
{
    static void Main()
    {
        Lab1 lab = new Lab1();
        Console.WriteLine("========================================");
        Console.WriteLine("    ЛАБОРАТОРНАЯ РАБОТА №1 (чётные)");
        Console.WriteLine("========================================");

        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1 - Задание 1 (Методы)");
            Console.WriteLine("2 - Задание 2 (Условия)");
            Console.WriteLine("3 - Задание 3 (Циклы)");
            Console.WriteLine("4 - Задание 4 (Массивы)");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("--- ЗАДАНИЕ 1: МЕТОДЫ ---");
                    Console.WriteLine("1) Сумма двух последних цифр числа 4568: " + lab.sumLastNums(4568));
                    Console.WriteLine("2) Проверка положительности:");
                    Console.WriteLine("   isPositive(3) → " + lab.isPositive(3));
                    Console.WriteLine("   isPositive(-5) → " + lab.isPositive(-5));
                    Console.WriteLine("3) Проверка большой буквы:");
                    Console.WriteLine("   isUpperCase('D') → " + lab.isUpperCase('D'));
                    Console.WriteLine("   isUpperCase('q') → " + lab.isUpperCase('q'));
                    Console.WriteLine("4) Проверка делителя:");
                    Console.WriteLine("   isDivisor(3,6) → " + lab.isDivisor(3, 6));
                    Console.WriteLine("   isDivisor(2,15) → " + lab.isDivisor(2, 15));
                    lab.multiLastNumSum();
                    break;

                case "2":
                    Console.WriteLine("--- ЗАДАНИЕ 2: УСЛОВИЯ ---");
                    Console.WriteLine("1) Безопасное деление:");
                    Console.WriteLine("   safeDiv(5,0) → " + lab.safeDiv(5, 0));
                    Console.WriteLine("   safeDiv(8,2) → " + lab.safeDiv(8, 2));
                    Console.WriteLine("2) Сравнение чисел:");
                    Console.WriteLine("   makeDecision(5,7) → " + lab.makeDecision(5, 7));
                    Console.WriteLine("   makeDecision(8,-1) → " + lab.makeDecision(8, -1));
                    Console.WriteLine("   makeDecision(4,4) → " + lab.makeDecision(4, 4));
                    Console.WriteLine("3) Проверка суммы двух чисел:");
                    Console.WriteLine("   sum3(5,7,2) → " + lab.sum3(5, 7, 2));
                    Console.WriteLine("   sum3(8,-1,4) → " + lab.sum3(8, -1, 4));
                    Console.WriteLine("4) Возраст с окончанием:");
                    Console.WriteLine("   age(5) → " + lab.age(5));
                    Console.WriteLine("   age(31) → " + lab.age(31));
                    Console.WriteLine("   age(44) → " + lab.age(44));
                    Console.WriteLine("5) Дни недели:");
                    lab.printDays("четверг");
                    lab.printDays("чг");
                    break;

                case "3":
                    Console.WriteLine("--- ЗАДАНИЕ 3: ЦИКЛЫ ---");
                    Console.WriteLine("1) Числа от 5 до 0: " + lab.reverseListNums(5));
                    Console.WriteLine("2) 2 в степени 5: " + lab.pow(2, 5));
                    Console.WriteLine("3) Проверка одинаковых цифр:");
                    Console.WriteLine("   equalNum(1111) → " + lab.equalNum(1111));
                    Console.WriteLine("   equalNum(1211) → " + lab.equalNum(1211));
                    Console.WriteLine("4) Левый треугольник (x=4):");
                    lab.leftTriangle(4);
                    lab.guessGame();
                    break;

                case "4":
                    Console.WriteLine("--- ЗАДАНИЕ 4: МАССИВЫ ---");
                    int[] arr = { 1, 2, 3, 4, 2, 2, 5 };
                    lab.PrintArray(arr, "Исходный массив");
                    Console.WriteLine("1) Последнее вхождение числа 2: индекс " + lab.findLast(arr, 2));

                    int[] added = lab.add(new int[] { 1, 2, 3, 4, 5 }, 9, 3);
                    lab.PrintArray(added, "2) Вставка 9 в позицию 3");

                    int[] revArr = { 1, 2, 3, 4, 5 };
                    lab.reverse(revArr);
                    lab.PrintArray(revArr, "3) Реверс массива");

                    int[] concated = lab.concat(new int[] { 1, 2, 3 }, new int[] { 7, 8, 9 });
                    lab.PrintArray(concated, "4) Объединение массивов");

                    int[] noNeg = lab.deleteNegative(new int[] { 1, 2, -3, 4, -2, 2, -5 });
                    lab.PrintArray(noNeg, "5) Удаление отрицательных");
                    break;

                case "0":
                    Console.WriteLine("Выход из программы. До свидания!");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}