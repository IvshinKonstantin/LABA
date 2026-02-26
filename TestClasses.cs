using System;
using Lab6_Interfaces.Interfaces;

namespace Lab6_Interfaces.Tests
{
    /// <summary>
    /// Тестовый класс для демонстрации работы интерфейса IMeowable
    /// </summary>
    public class Dog : IMeowable
    {
        private string _name;

        /// <summary>
        /// Имя собаки
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Конструктор собаки
        /// </summary>
        /// <param name="name">Имя собаки</param>
        public Dog(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Собака тоже может "мяукать" (для демонстрации)
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{_name}: гав? (пытается мяукнуть...)");
        }

        /// <summary>
        /// Строковое представление
        /// </summary>
        public override string ToString()
        {
            return $"собака: {_name}";
        }
    }

    /// <summary>
    /// Еще один тестовый класс
    /// </summary>
    public class Robot : IMeowable
    {
        private string _model;

        /// <summary>
        /// Модель робота
        /// </summary>
        public string Model => _model;

        /// <summary>
        /// Конструктор робота
        /// </summary>
        /// <param name="model">Модель робота</param>
        public Robot(string model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        /// <summary>
        /// Робот тоже может мяукать (звуковой сигнал)
        /// </summary>
        public void Meow()
        {
            Console.WriteLine($"{_model}: Бип-бип-мяу!");
        }

        /// <summary>
        /// Строковое представление
        /// </summary>
        public override string ToString()
        {
            return $"робот: {_model}";
        }
    }
}