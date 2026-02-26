using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Имя (Задания 1.3 и 4.5)
    /// </summary>
    internal class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        // Конструктор только с именем
        public FullName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым");

            FirstName = firstName;
        }

        // Конструктор с именем и фамилией
        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым");

            FirstName = firstName;
            LastName = lastName;
        }

        // Конструктор со всеми параметрами
        public FullName(string firstName, string lastName, string patronymic)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым");

            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public override string ToString()
        {
            List<string> parts = new List<string>();

            if (!string.IsNullOrEmpty(LastName))
                parts.Add(LastName);

            if (!string.IsNullOrEmpty(FirstName))
                parts.Add(FirstName);

            if (!string.IsNullOrEmpty(Patronymic))
                parts.Add(Patronymic);

            return string.Join(" ", parts);
        }
    }
}
