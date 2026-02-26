using System;
using System.Text;

namespace Lab3
{
    /// <summary>
    /// Класс для работы с матрицами (Задания 1-3)
    /// Содержит единственное поле - двумерный массив
    /// </summary>
    public class Matrix
    {
        private double[,] Data { get; set; }

        // Конструктор по умолчанию
        public Matrix()
        {
            Data = new double[0, 0];
        }

        // Конструктор с размерами
        public Matrix(int rows, int cols)
        {
            Data = new double[rows, cols];
        }

        // Конструктор для создания копии
        public Matrix(double[,] data)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            Data = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Data[i, j] = data[i, j];
                }
            }
        }

        #region Задание 1.4 - Конструкторы для заполнения массивов

        /// <summary>
        /// Первый массив: заполнение с клавиатуры по строкам от первых элементов к последним
        /// </summary>
        public Matrix(int n, int m, bool fillFromKeyboard)
        {
            Data = new double[n, m];

            if (!fillFromKeyboard) return;

            Console.WriteLine($"\nЗаполнение массива {n}x{m} по строкам от первых элементов к последним:");
            Console.WriteLine("Порядок заполнения: [0,0] -> [0,1] -> ... -> [0,m-1] -> [1,0] -> ...");

            for (int i = 0; i < n; i++) // Строки сверху вниз
            {
                for (int j = 0; j < m; j++) // Столбцы слева направо
                {
                    Console.Write($"   Элемент [{i},{j}]: ");
                    while (!double.TryParse(Console.ReadLine(), out Data[i, j]))
                    {
                        Console.Write("   Ошибка! Введите число: ");
                    }
                }
            }
        }

        /// <summary>
        /// Второй массив: элементы выше побочной диагонали [-65; 120], 
        /// на побочной диагонали и ниже [-3.5; 10.75]
        /// </summary>
        public Matrix(int n, Random random)
        {
            Data = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Проверка: находится ли элемент выше побочной диагонали
                    // Побочная диагональ: i + j = n - 1
                    if (i + j < n - 1) // Выше побочной диагонали
                    {
                        Data[i, j] = random.NextDouble() * (120 - (-65)) + (-65);
                    }
                    else // На побочной диагонали и ниже
                    {
                        Data[i, j] = random.NextDouble() * (10.75 - (-3.5)) + (-3.5);
                    }
                }
            }
        }

        /// <summary>
        /// Третий массив: заполняется для произвольного n как для n=5 (по фотографии)
        /// </summary>
        public Matrix(int n, bool createSpecialMatrix)
        {
            if (!createSpecialMatrix)
            {
                Data = new double[n, n];
                return;
            }

            Data = new double[n, n];

            // Заполняем по образцу из фотографии для n=5:
            // 11   10   4    3    1
            // 0    12   9    5    2
            // 0    0    13   8    6
            // 0    0    0    14   7
            // 0    0    0    0    15

            int[,] template = new int[5, 5]
            {
                { 11, 10, 4, 3, 1 },
                { 0, 12, 9, 5, 2 },
                { 0, 0, 13, 8, 6 },
                { 0, 0, 0, 14, 7 },
                { 0, 0, 0, 0, 15 }
            };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < 5 && j < 5)
                    {
                        Data[i, j] = template[i, j];
                    }
                    else
                    {
                        // Для размеров больше 5 заполняем по тому же принципу
                        if (i <= j)
                        {
                            // Верхняя треугольная часть (включая диагональ)
                            Data[i, j] = (i + 1) * 10 + (j + 1);
                        }
                        else
                        {
                            Data[i, j] = 0;
                        }
                    }
                }
            }
        }

        #endregion

        #region Задание 2.4 - Работа с двумерными массивами

        /// <summary>
        /// Задание 2.4: В городе П. есть m банков. 
        /// Известны величины задолженностей банков друг другу. 
        /// Укажите банк с максимальным долгом.
        /// </summary>
        public int FindBankWithMaxDebt()
        {
            if (Data.Length == 0 || Data.GetLength(0) != Data.GetLength(1))
            {
                throw new InvalidOperationException("Массив должен быть квадратным и непустым");
            }

            int n = Data.GetLength(0); // Количество банков
            double[] totalDebt = new double[n]; // Суммарный долг каждого банка

            // Суммируем долги каждого банка (по строкам - сколько должен этот банк другим)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j) // Исключаем долг самому себе
                    {
                        totalDebt[i] += Data[i, j];
                    }
                }
            }

            // Находим банк с максимальным долгом
            int maxDebtBank = 0;
            for (int i = 1; i < n; i++)
            {
                if (totalDebt[i] > totalDebt[maxDebtBank])
                {
                    maxDebtBank = i;
                }
            }

            Console.WriteLine("\nСуммарные долги банков:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Банк {i + 1}: {totalDebt[i]:F2}");
            }

            return maxDebtBank + 1; // Возвращаем номер банка (нумерация с 1)
        }

        #endregion

        #region Задание 3.4 - Операторы для работы с матрицами

        // Сложение матриц
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Data.GetLength(0) != b.Data.GetLength(0) ||
                a.Data.GetLength(1) != b.Data.GetLength(1))
            {
                throw new InvalidOperationException("Размеры матриц не совпадают");
            }

            int rows = a.Data.GetLength(0);
            int cols = a.Data.GetLength(1);
            Matrix result = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Data[i, j] = a.Data[i, j] + b.Data[i, j];
                }
            }

            return result;
        }

        // Вычитание матриц
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Data.GetLength(0) != b.Data.GetLength(0) ||
                a.Data.GetLength(1) != b.Data.GetLength(1))
            {
                throw new InvalidOperationException("Размеры матриц не совпадают");
            }

            int rows = a.Data.GetLength(0);
            int cols = a.Data.GetLength(1);
            Matrix result = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];
                }
            }

            return result;
        }

        // Умножение матрицы на число
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            int rows = matrix.Data.GetLength(0);
            int cols = matrix.Data.GetLength(1);
            Matrix result = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Data[i, j] = scalar * matrix.Data[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return scalar * matrix;
        }

        // Умножение матриц
        public static Matrix operator *(Matrix a, Matrix b)
        {
            int aRows = a.Data.GetLength(0);
            int aCols = a.Data.GetLength(1);
            int bRows = b.Data.GetLength(0);
            int bCols = b.Data.GetLength(1);

            if (aCols != bRows)
            {
                throw new InvalidOperationException(
                    "Количество столбцов первой матрицы должно равняться количеству строк второй");
            }

            Matrix result = new Matrix(aRows, bCols);

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < aCols; k++)
                    {
                        sum += a.Data[i, k] * b.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }

            return result;
        }

        // Транспонирование
        public Matrix Transpose()
        {
            int rows = Data.GetLength(0);
            int cols = Data.GetLength(1);
            Matrix result = new Matrix(cols, rows);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Data[j, i] = Data[i, j];
                }
            }

            return result;
        }

        // Свойство для транспонирования
        public Matrix T => Transpose();

        // Переопределение ToString
        public override string ToString()
        {
            if (Data.Length == 0)
            {
                return "[]";
            }

            int rows = Data.GetLength(0);
            int cols = Data.GetLength(1);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                sb.Append("[ ");
                for (int j = 0; j < cols; j++)
                {
                    sb.Append($"{Data[i, j],8:F3} ");
                }
                sb.AppendLine("]");
            }

            return sb.ToString();
        }

        public double[,] GetData()
        {
            return Data;
        }

        #endregion
    }

    /// <summary>
    /// Класс для запуска заданий 1-3
    /// </summary>
    public static class MatrixTasks
    {
        private static Matrix A, B, C;
        private static Random random = new Random();

        public static void RunAllTasks()
        {
            DemonstrateTask1();
            DemonstrateTask2();
            DemonstrateTask3();
        }

        public static void GenerateRandomMatrices()
        {
            Console.Write("Введите количество строк n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                n = 3;
                Console.WriteLine($"Используется значение по умолчанию: {n}");
            }

            Console.Write("Введите количество столбцов m (для первого массива): ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                m = 3;
                Console.WriteLine($"Используется значение по умолчанию: {m}");
            }

            // Матрица A: заполнение с клавиатуры (по строкам от первых к последним)
            Console.WriteLine("\nСоздание матрицы A (заполнение с клавиатуры по строкам от первых к последним):");
            A = new Matrix(n, m, true);

            // Матрица B: для задачи о банках (квадратная матрица)
            Console.WriteLine("\nСоздание матрицы B (квадратная матрица для задачи о банках):");
            Console.WriteLine("Элементы выше побочной диагонали: [-65; 120], на побочной и ниже: [-3.5; 10.75]");
            B = new Matrix(n, random);

            // Матрица C: специальное заполнение (по образцу из фотографии)
            Console.WriteLine("\nСоздание матрицы C (специальное заполнение как для n=5):");
            C = new Matrix(n, true);

            Console.WriteLine("\nМатрицы успешно созданы!");

            Console.WriteLine("\nМатрица A (первый массив):");
            Console.WriteLine(A);

            Console.WriteLine("\nМатрица B (задолженности банков):");
            Console.WriteLine(B);

            Console.WriteLine("\nМатрица C (третий массив):");
            Console.WriteLine(C);
        }

        public static void DemonstrateTask1()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 1.4: СОЗДАНИЕ МАТРИЦ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            GenerateRandomMatrices();
        }

        public static void DemonstrateTask2()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 2.4: ПОИСК БАНКА С МАКСИМАЛЬНЫМ ДОЛГОМ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            if (B == null)
            {
                Console.WriteLine("Матрица B не создана. Сначала выполните задание 1.");
                Console.Write("Хотите создать матрицы сейчас? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    GenerateRandomMatrices();
                }
                else
                {
                    return;
                }
            }

            try
            {
                Console.WriteLine("Матрица задолженностей банков (строка i -> должен банку j):");
                Console.WriteLine(B);

                int bankNumber = B.FindBankWithMaxDebt();
                Console.WriteLine($"\nБанк с максимальным долгом: Банк {bankNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void DemonstrateTask3()
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine("   ЗАДАНИЕ 3.4: ВЫЧИСЛЕНИЕ 2*A - B^T * C");
            Console.WriteLine("=========================================================================");
            Console.WriteLine();

            if (A == null || B == null || C == null)
            {
                Console.WriteLine("Матрицы не созданы. Сначала выполните задание 1.");
                Console.Write("Хотите создать матрицы сейчас? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    GenerateRandomMatrices();
                }
                else
                {
                    return;
                }
            }

            try
            {
                Console.WriteLine("Исходные матрицы:");
                Console.WriteLine("\nМатрица A:");
                Console.WriteLine(A);

                Console.WriteLine("\nМатрица B:");
                Console.WriteLine(B);

                Console.WriteLine("\nМатрица C:");
                Console.WriteLine(C);

                Console.WriteLine("\nМатрица B^T (транспонированная):");
                Console.WriteLine(B.T);

                // Вычисление 2*A - B^T * C
                Matrix expression = 2 * A - B.T * C;

                Console.WriteLine("\nРЕЗУЛЬТАТ ВЫРАЖЕНИЯ 2*A - B^T * C:");
                Console.WriteLine(expression);

                Console.WriteLine("\nПРОВЕРКА НА ОНЛАЙН-КАЛЬКУЛЯТОРЕ:");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("1. Откройте онлайн-калькулятор матриц (например, matrixcalc.org)");
                Console.WriteLine("2. Введите матрицы:");
                Console.WriteLine("   A =");
                foreach (var line in A.ToString().Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        Console.WriteLine($"      {line.Trim()}");
                }
                Console.WriteLine("   B =");
                foreach (var line in B.ToString().Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        Console.WriteLine($"      {line.Trim()}");
                }
                Console.WriteLine("   C =");
                foreach (var line in C.ToString().Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        Console.WriteLine($"      {line.Trim()}");
                }
                Console.WriteLine("3. Вычислите 2*A - B^T * C");
                Console.WriteLine("4. Сравните с результатом выше");
                Console.WriteLine("-------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
            }
        }
    }
}