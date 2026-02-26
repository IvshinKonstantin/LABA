using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Город (Задание 3.3)
    /// </summary>
    internal class City
    {
        public string Name { get; set; }
        public List<Path> Paths { get; private set; }

        public City(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название города не может быть пустым");

            Name = name;
            Paths = new List<Path>();
        }

        public City(string name, List<Path> paths)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название города не может быть пустым");

            Name = name;
            Paths = paths ?? new List<Path>();
        }

        public void AddPath(City city, int cost)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));

            Paths.Add(new Path(city, cost));
        }

        public override string ToString()
        {
            if (Paths.Count == 0)
                return Name;

            StringBuilder sb = new StringBuilder();
            sb.Append($"{Name}: ");

            for (int i = 0; i < Paths.Count; i++)
            {
                sb.Append($"{Paths[i].Destination.Name}:{Paths[i].Cost}");
                if (i < Paths.Count - 1)
                    sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}
