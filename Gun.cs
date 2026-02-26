using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Пистолет (Задание 5.1)
    /// </summary>
    internal class Gun
    {
        public int Bullets { get; private set; }

        public Gun() : this(5) { }

        public Gun(int bullets)
        {
            if (bullets < 0)
                throw new ArgumentException("Количество патронов не может быть отрицательным");

            Bullets = bullets;
        }

        public string Shoot()
        {
            if (Bullets > 0)
            {
                Bullets--;
                return "Бах!";
            }
            else
            {
                return "Клац!";
            }
        }

        public override string ToString()
        {
            return $"Пистолет с {Bullets} патронами";
        }
    }
}
