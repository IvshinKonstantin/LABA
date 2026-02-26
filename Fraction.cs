using System;
using Lab6_Interfaces.Interfaces;

namespace Lab6_Interfaces.Models
{
    /// <summary>
    /// Класс, представляющий математическую дробь
    /// </summary>
    public class Fraction : IMyCloneable, IEquatable<Fraction>
    {
        private int _numerator;
        private int _denominator;

        /// <summary>
        /// Числитель дроби
        /// </summary>
        public int Numerator
        {
            get { return _numerator; }
            private set { _numerator = value; }
        }

        /// <summary>
        /// Знаменатель дроби (всегда положительный)
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается при попытке установить 0 или отрицательное значение</exception>
        public int Denominator
        {
            get { return _denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                if (value < 0)
                {
                    // Переносим знак в числитель
                    _numerator = -_numerator;
                    _denominator = -value;
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        /// <summary>
        /// Конструктор для создания дроби
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель (не может быть 0)</param>
        /// <exception cref="ArgumentException">Выбрасывается при некорректном знаменателе</exception>
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }

            _numerator = numerator;
            _denominator = 1; // Временное значение

            // Используем свойство для нормализации знака
            Denominator = denominator;
            Normalize();
        }

        /// <summary>
        /// Нормализация дроби (сокращение и приведение знака)
        /// </summary>
        private void Normalize()
        {
            // Приведение знака уже выполнено в свойстве Denominator
            // Сокращение дроби
            int gcd = GCD(Math.Abs(_numerator), _denominator);
            if (gcd > 1)
            {
                _numerator /= gcd;
                _denominator /= gcd;
            }
        }

        /// <summary>
        /// Наибольший общий делитель (алгоритм Евклида)
        /// </summary>
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        #region Арифметические операции

        /// <summary>
        /// Сложение с другой дробью
        /// </summary>
        /// <param name="other">Другая дробь</param>
        /// <returns>Новая дробь - результат сложения</returns>
        public Fraction Add(Fraction other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int newNumerator = this._numerator * other._denominator +
                              other._numerator * this._denominator;
            int newDenominator = this._denominator * other._denominator;

            return new Fraction(newNumerator, newDenominator);
        }

        /// <summary>
        /// Сложение с целым числом
        /// </summary>
        /// <param name="number">Целое число</param>
        /// <returns>Новая дробь - результат сложения</returns>
        public Fraction Add(int number)
        {
            return Add(new Fraction(number, 1));
        }

        /// <summary>
        /// Вычитание другой дроби
        /// </summary>
        /// <param name="other">Другая дробь</param>
        /// <returns>Новая дробь - результат вычитания</returns>
        public Fraction Subtract(Fraction other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int newNumerator = this._numerator * other._denominator -
                              other._numerator * this._denominator;
            int newDenominator = this._denominator * other._denominator;

            return new Fraction(newNumerator, newDenominator);
        }

        /// <summary>
        /// Вычитание целого числа
        /// </summary>
        /// <param name="number">Целое число</param>
        /// <returns>Новая дробь - результат вычитания</returns>
        public Fraction Subtract(int number)
        {
            return Subtract(new Fraction(number, 1));
        }

        /// <summary>
        /// Умножение на другую дробь
        /// </summary>
        /// <param name="other">Другая дробь</param>
        /// <returns>Новая дробь - результат умножения</returns>
        public Fraction Multiply(Fraction other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int newNumerator = this._numerator * other._numerator;
            int newDenominator = this._denominator * other._denominator;

            return new Fraction(newNumerator, newDenominator);
        }

        /// <summary>
        /// Умножение на целое число
        /// </summary>
        /// <param name="number">Целое число</param>
        /// <returns>Новая дробь - результат умножения</returns>
        public Fraction Multiply(int number)
        {
            return Multiply(new Fraction(number, 1));
        }

        /// <summary>
        /// Деление на другую дробь
        /// </summary>
        /// <param name="other">Другая дробь</param>
        /// <returns>Новая дробь - результат деления</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается при делении на 0</exception>
        public Fraction Divide(Fraction other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (other._numerator == 0)
            {
                throw new DivideByZeroException("Деление на дробь с нулевым числителем");
            }

            // Деление a/b на c/d = (a*d)/(b*c)
            int newNumerator = this._numerator * other._denominator;
            int newDenominator = this._denominator * other._numerator;

            return new Fraction(newNumerator, newDenominator);
        }

        /// <summary>
        /// Деление на целое число
        /// </summary>
        /// <param name="number">Целое число</param>
        /// <returns>Новая дробь - результат деления</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается при делении на 0</exception>
        public Fraction Divide(int number)
        {
            if (number == 0)
            {
                throw new DivideByZeroException("Деление на ноль");
            }
            return Divide(new Fraction(number, 1));
        }

        #endregion

        #region Перегрузка операторов

        /// <summary>
        /// Перегрузка оператора сложения
        /// </summary>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return a.Add(b);
        }

        /// <summary>
        /// Перегрузка оператора сложения с целым числом
        /// </summary>
        public static Fraction operator +(Fraction a, int b)
        {
            return a.Add(b);
        }

        /// <summary>
        /// Перегрузка оператора сложения с целым числом
        /// </summary>
        public static Fraction operator +(int a, Fraction b)
        {
            return b.Add(a);
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// </summary>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a.Subtract(b);
        }

        /// <summary>
        /// Перегрузка оператора вычитания с целым числом
        /// </summary>
        public static Fraction operator -(Fraction a, int b)
        {
            return a.Subtract(b);
        }

        /// <summary>
        /// Перегрузка оператора умножения
        /// </summary>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return a.Multiply(b);
        }

        /// <summary>
        /// Перегрузка оператора умножения с целым числом
        /// </summary>
        public static Fraction operator *(Fraction a, int b)
        {
            return a.Multiply(b);
        }

        /// <summary>
        /// Перегрузка оператора умножения с целым числом
        /// </summary>
        public static Fraction operator *(int a, Fraction b)
        {
            return b.Multiply(a);
        }

        /// <summary>
        /// Перегрузка оператора деления
        /// </summary>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a.Divide(b);
        }

        /// <summary>
        /// Перегрузка оператора деления с целым числом
        /// </summary>
        public static Fraction operator /(Fraction a, int b)
        {
            return a.Divide(b);
        }

        #endregion

        #region Реализация интерфейсов

        /// <summary>
        /// Создание копии дроби
        /// </summary>
        /// <returns>Копия объекта Fraction</returns>
        public object Clone()
        {
            return new Fraction(this._numerator, this._denominator);
        }

        /// <summary>
        /// Сравнение с другой дробью
        /// </summary>
        /// <param name="other">Другая дробь</param>
        /// <returns>true, если дроби равны</returns>
        public bool Equals(Fraction other)
        {
            if (other is null)
            {
                return false;
            }

            // Дроби уже нормализованы, поэтому можно сравнивать числители и знаменатели
            return this._numerator == other._numerator &&
                   this._denominator == other._denominator;
        }

        /// <summary>
        /// Переопределение Equals
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Fraction);
        }

        /// <summary>
        /// Переопределение GetHashCode
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(_numerator, _denominator);
        }

        #endregion

        /// <summary>
        /// Преобразование дроби в строку
        /// </summary>
        /// <returns>Строковое представление дроби в формате "числитель/знаменатель"</returns>
        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }
    }

    /// <summary>
    /// Класс дроби с кэшированием вещественного значения
    /// </summary>
    public class CachedFraction : IFraction
    {
        private int _numerator;
        private int _denominator;
        private double? _cachedValue;

        /// <summary>
        /// Конструктор с кэшированием
        /// </summary>
        public CachedFraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }

            _numerator = numerator;
            _denominator = denominator < 0 ? -denominator : denominator;
            if (denominator < 0)
            {
                _numerator = -_numerator;
            }
            _cachedValue = null; // Кэш пуст
        }

        /// <summary>
        /// Получение вещественного значения с кэшированием
        /// </summary>
        public double GetDoubleValue()
        {
            if (!_cachedValue.HasValue)
            {
                _cachedValue = (double)_numerator / _denominator;
                Console.WriteLine("  [Кэширование: значение вычислено]");
            }
            else
            {
                Console.WriteLine("  [Кэширование: значение взято из кэша]");
            }
            return _cachedValue.Value;
        }

        /// <summary>
        /// Установка числителя (сбрасывает кэш)
        /// </summary>
        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
            _cachedValue = null; // Сбрасываем кэш
        }

        /// <summary>
        /// Установка знаменателя (сбрасывает кэш)
        /// </summary>
        public void SetDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }

            _denominator = denominator < 0 ? -denominator : denominator;
            if (denominator < 0)
            {
                _numerator = -_numerator;
            }
            _cachedValue = null; // Сбрасываем кэш
        }

        /// <summary>
        /// Строковое представление
        /// </summary>
        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }
    }
}