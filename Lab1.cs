using System;

public class Lab1
{
    // ==================== ЗАДАНИЕ 1. МЕТОДЫ (чётные) ====================

    // 2. Сумма двух последних знаков числа
    public int sumLastNums(int x)
    {
        int last = Math.Abs(x) % 10;
        int prev = Math.Abs(x) / 10 % 10;
        return last + prev;
    }

    // 4. Проверка, положительное ли число
    public bool isPositive(int x)
    {
        return x > 0;
    }

    // 6. Проверка, является ли символ большой буквой A-Z
    public bool isUpperCase(char x)
    {
        return x >= 'A' && x <= 'Z';
    }

    // 8. Проверка, делится ли одно число на другое нацело
    public bool isDivisor(int a, int b)
    {
        if (a == 0 || b == 0) return false;
        return a % b == 0 || b % a == 0;
    }

    // 10. Сумма последних цифр двух чисел с накоплением
    public int lastNumSum(int a, int b)
    {
        return (Math.Abs(a) % 10) + (Math.Abs(b) % 10);
    }

    public void multiLastNumSum()
    {
        Console.WriteLine("\n--- Многократный вызов ---");
        int sum = 0;
        int[] numbers = { 5, 11, 123, 14, 1 };
        Console.WriteLine("Числа: 5, 11, 123, 14, 1");
        foreach (int num in numbers)
        {
            sum = lastNumSum(sum, num);
        }
        Console.WriteLine("Итоговая сумма последних цифр: " + sum);
    }

    // ==================== ЗАДАНИЕ 2. УСЛОВИЯ (чётные) ====================

    // 2. Безопасное деление
    public double safeDiv(int x, int y)
    {
        if (y == 0) return 0;
        return (double)x / y;
    }

    // 4. Строка сравнения
    public string makeDecision(int x, int y)
    {
        if (x > y) return x + " > " + y;
        if (x < y) return x + " < " + y;
        return x + " == " + y;
    }

    // 6. Проверка, можно ли два числа сложить и получить третье
    public bool sum3(int x, int y, int z)
    {
        return (x + y == z) || (x + z == y) || (y + z == x);
    }

    // 8. Возраст с правильным склонением
    public string age(int x)
    {
        if (x % 10 == 1 && x % 100 != 11) return x + " год";
        if (x % 10 >= 2 && x % 10 <= 4 && (x % 100 < 10 || x % 100 >= 20)) return x + " года";
        return x + " лет";
    }

    // 10. Вывод дней недели по названию
    public void printDays(string x)
    {
        Console.Write("Результат: ");
        switch (x.ToLower())
        {
            case "понедельник":
                Console.WriteLine("понедельник вторник среда четверг пятница суббота воскресенье");
                break;
            case "вторник":
                Console.WriteLine("вторник среда четверг пятница суббота воскресенье");
                break;
            case "среда":
                Console.WriteLine("среда четверг пятница суббота воскресенье");
                break;
            case "четверг":
                Console.WriteLine("четверг пятница суббота воскресенье");
                break;
            case "пятница":
                Console.WriteLine("пятница суббота воскресенье");
                break;
            case "суббота":
                Console.WriteLine("суббота воскресенье");
                break;
            case "воскресенье":
                Console.WriteLine("воскресенье");
                break;
            default:
                Console.WriteLine("это не день недели");
                break;
        }
    }

    // ==================== ЗАДАНИЕ 3. ЦИКЛЫ (чётные) ====================

    // 2. Числа от x до 0
    public string reverseListNums(int x)
    {
        string result = "";
        for (int i = x; i >= 0; i--)
            result += i + " ";
        return result.Trim();
    }

    // 4. Возведение в степень
    public int pow(int x, int y)
    {
        int res = 1;
        for (int i = 0; i < y; i++)
            res *= x;
        return res;
    }

    // 6. Все ли цифры числа одинаковы
    public bool equalNum(int x)
    {
        int last = x % 10;
        x /= 10;
        while (x > 0)
        {
            if (x % 10 != last) return false;
            x /= 10;
        }
        return true;
    }

    // 8. Левый треугольник
    public void leftTriangle(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= i; j++)
                Console.Write("*");
            Console.WriteLine();
        }
    }

    // 10. Угадайка
    public void guessGame()
    {
        Console.WriteLine("\n--- Игра 'Угадайка' ---");
        Random rand = new Random();
        int secret = rand.Next(0, 10);
        int guess = -1;
        int attempts = 0;

        while (guess != secret)
        {
            Console.Write("Введите число от 0 до 9: ");
            if (!int.TryParse(Console.ReadLine(), out guess) || guess < 0 || guess > 9)
            {
                Console.WriteLine("Ошибка! Введите число от 0 до 9.");
                continue;
            }
            attempts++;
            if (guess != secret)
                Console.WriteLine("Не угадали, попробуйте ещё раз.");
        }
        Console.WriteLine($"Поздравляю! Вы угадали число {secret} за {attempts} попыток!");
    }

    // ==================== ЗАДАНИЕ 4. МАССИВЫ (чётные) ====================

    // 2. Последнее вхождение числа
    public int findLast(int[] arr, int x)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
            if (arr[i] == x) return i;
        return -1;
    }

    // 4. Вставка элемента в массив
    public int[] add(int[] arr, int x, int pos)
    {
        int[] newArr = new int[arr.Length + 1];
        for (int i = 0; i < pos; i++)
            newArr[i] = arr[i];
        newArr[pos] = x;
        for (int i = pos; i < arr.Length; i++)
            newArr[i + 1] = arr[i];
        return newArr;
    }

    // 6. Реверс массива (на месте)
    public void reverse(int[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[arr.Length - 1 - i];
            arr[arr.Length - 1 - i] = temp;
        }
    }

    // 8. Объединение массивов
    public int[] concat(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length];
        for (int i = 0; i < arr1.Length; i++)
            result[i] = arr1[i];
        for (int i = 0; i < arr2.Length; i++)
            result[arr1.Length + i] = arr2[i];
        return result;
    }

    // 10. Удалить отрицательные
    public int[] deleteNegative(int[] arr)
    {
        int count = 0;
        foreach (int num in arr)
            if (num >= 0) count++;

        int[] result = new int[count];
        int index = 0;
        foreach (int num in arr)
            if (num >= 0) result[index++] = num;

        return result;
    }

    // Вспомогательный метод для красивого вывода массива
    public void PrintArray(int[] arr, string name)
    {
        Console.Write(name + ": [");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1) Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}