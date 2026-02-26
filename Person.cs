using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Человек (Задания 1.2, 2.2, 2.3, 4.6)
    /// </summary>
    internal class Person
    {
        public FullName Name { get; private set; }
        public int Height { get; private set; }
        public Person Father { get; private set; }

        // Конструктор с именем в виде строки
        public Person(string firstName, int height)
        {
            Name = new FullName(firstName);
            Height = height;
        }

        // Конструктор с именем в виде строки и отцом
        public Person(string firstName, int height, Person father)
        {
            Name = new FullName(firstName);
            Height = height;
            Father = father;
            UpdateNameFromFather();
        }

        // Конструктор с объектом FullName
        public Person(FullName name, int height)
        {
            Name = name;
            Height = height;
        }

        // Конструктор с объектом FullName и отцом
        public Person(FullName name, int height, Person father)
        {
            Name = name;
            Height = height;
            Father = father;
            UpdateNameFromFather();
        }

        private void UpdateNameFromFather()
        {
            if (Father == null) return;

            // Если нет фамилии, берём фамилию отца
            if (string.IsNullOrEmpty(Name.LastName) && !string.IsNullOrEmpty(Father.Name.LastName))
            {
                Name.LastName = Father.Name.LastName;
            }

            // Если нет отчества, создаём из имени отца
            if (string.IsNullOrEmpty(Name.Patronymic) && !string.IsNullOrEmpty(Father.Name.FirstName))
            {
                string fatherName = Father.Name.FirstName;
                // Простое добавление суффикса (для демонстрации)
                if (fatherName.EndsWith("а") || fatherName.EndsWith("я"))
                    Name.Patronymic = fatherName.Substring(0, fatherName.Length - 1) + "ична";
                else
                    Name.Patronymic = fatherName + "ович";
            }
        }

        public override string ToString()
        {
            return $"{Name}, рост: {Height}";
        }
    }
}
