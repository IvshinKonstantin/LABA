using System;
using System.Text;

namespace Lab4_RightTriangle
{
    /// <summary>
    /// Класс RightTriangle (прямоугольный треугольник)
    /// Задание 6.4 и 7.4
    /// </summary>
    public class RightTriangle
    {
        // Поля
        private double _a;
        private double _b;

        // Свойства
        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина катета должна быть положительной!");
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Длина катета должна быть положительной!");
                _b = value;
            }
        }

        // Конструкторы
        public RightTriangle()
        {
            _a = 1.0;
            _b = 1.0;
        }

        public RightTriangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Длины катетов должны быть положительными!");

            _a = a;
            _b = b;
        }

        public RightTriangle(RightTriangle other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            _a = other._a;
            _b = other._b;
        }

        /// <summary>
        /// Задание 6.4: Вычислить площадь треугольника
        /// </summary>
        public double CalculateArea()
        {
            return (_a * _b) / 2.0;
        }

        /// <summary>
        /// Вычислить гипотенузу
        /// </summary>
        public double CalculateHypotenuse()
        {
            return Math.Sqrt(_a * _a + _b * _b);
        }

        /// <summary>
        /// Проверить существование треугольника (всегда true для прямоугольного с положительными сторонами)
        /// </summary>
        public bool Exists()
        {
            return _a > 0 && _b > 0;
        }

        /// <summary>
        /// Перегрузка ToString()
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Прямоугольный треугольник:");
            sb.AppendLine($"  Катет a: {_a:F3}");
            sb.AppendLine($"  Катет b: {_b:F3}");
            sb.AppendLine($"  Гипотенуза: {CalculateHypotenuse():F3}");
            sb.AppendLine($"  Площадь: {CalculateArea():F3}");
            return sb.ToString();
        }

        #region Задание 7.4 - Перегруженные операции

        // Унарные операции
        public static RightTriangle operator ++(RightTriangle t)
        {
            return new RightTriangle(t._a * 2, t._b * 2);
        }

        public static RightTriangle operator --(RightTriangle t)
        {
            return new RightTriangle(t._a / 2, t._b / 2);
        }

        // Операции приведения типа
        public static explicit operator double(RightTriangle t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            if (t.Exists())
            {
                return t.CalculateArea();
            }
            return -1.0; // отрицательное число для несуществующего треугольника
        }

        public static implicit operator bool(RightTriangle t)
        {
            if (t == null)
                return false;

            return t.Exists();
        }

        // Бинарные операции сравнения площадей
        public static bool operator <=(RightTriangle t1, RightTriangle t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException("Операнды не могут быть null");

            return t1.CalculateArea() <= t2.CalculateArea();
        }

        public static bool operator >=(RightTriangle t1, RightTriangle t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException("Операнды не могут быть null");

            return t1.CalculateArea() >= t2.CalculateArea();
        }

        // Для полноты реализуем также < и >
        public static bool operator <(RightTriangle t1, RightTriangle t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException("Операнды не могут быть null");

            return t1.CalculateArea() < t2.CalculateArea();
        }

        public static bool operator >(RightTriangle t1, RightTriangle t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException("Операнды не могут быть null");

            return t1.CalculateArea() > t2.CalculateArea();
        }

        #endregion
    }
}