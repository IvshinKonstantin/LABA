using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Отдел (Задание 2.4)
    /// </summary>
    internal class Department
    {
        public string Name { get; private set; }
        public Employee Chief { get; private set; }

        public Department(string name)
        {
            Name = name;
        }

        public void SetChief(Employee employee)
        {
            Chief = employee;
            employee.SetAsChief(this);
        }

        public override string ToString()
        {
            if (Chief != null)
                return $"Отдел {Name}, начальник: {Chief.Name}";
            else
                return $"Отдел {Name}, начальник не назначен";
        }
    }
}
