using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Путь между городами (Задание 3.3)
    /// </summary>
    internal class Path
    {
        public City Destination { get; set; }
        public int Cost { get; set; }

        public Path(City destination, int cost)
        {
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));

            if (cost <= 0)
                throw new ArgumentException("Стоимость пути должна быть положительным числом");

            Cost = cost;
        }
    }
}
