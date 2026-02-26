using System;
using System.Text;
using Lab6_Interfaces.Interfaces;

namespace Lab6_Interfaces.Models
{
    /// <summary>
    /// Класс, представляющий кота, который может мяукать
    /// </summary>
    public class Cat : IMeowable
    {
        private string _name;

        /// <summary>
        /// Имя кота
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если имя null или пустое</exception>
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя кота не может быть пустым или null");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Конструктор для создания кота
        /// </summary>
        /// <param name="name">Имя кота</param>
        /// <exception cref="ArgumentException">Выбрасывается, если имя null или пустое</exception>
        public Cat(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Мяукнуть один раз
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }

        /// <summary>
        /// Мяукнуть указанное количество раз
        /// </summary>
        /// <param name="count">Количество мяуканий</param>
        /// <exception cref="ArgumentException">Выбрасывается, если count меньше 1</exception>
        public void Meow(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Количество мяуканий должно быть положительным");
            }

            StringBuilder meowBuilder = new StringBuilder();
            meowBuilder.Append($"{Name}: ");

            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    meowBuilder.Append('-');
                }
                meowBuilder.Append("мяу");
            }

            meowBuilder.Append('!');
            Console.WriteLine(meowBuilder.ToString());
        }

        /// <summary>
        /// Переопределение ToString для вывода информации о коте
        /// </summary>
        /// <returns>Строковое представление кота</returns>
        public override string ToString()
        {
            return $"кот: {Name}";
        }
    }

    /// <summary>
    /// Декоратор для подсчета количества мяуканий
    /// </summary>
    public class MeowCounter : IMeowable
    {
        private readonly IMeowable _meowable;
        private int _meowCount;

        /// <summary>
        /// Количество совершенных мяуканий
        /// </summary>
        public int MeowCount => _meowCount;

        /// <summary>
        /// Конструктор декоратора
        /// </summary>
        /// <param name="meowable">Объект, который может мяукать</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если meowable null</exception>
        public MeowCounter(IMeowable meowable)
        {
            _meowable = meowable ?? throw new ArgumentNullException(nameof(meowable));
            _meowCount = 0;
        }

        /// <summary>
        /// Мяукнуть с подсчетом
        /// </summary>
        public void Meow()
        {
            _meowable.Meow();
            _meowCount++;
        }
    }
}