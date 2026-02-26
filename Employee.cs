using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛАБА_2.Entities
{
    /// <summary>
    /// Сущность Сотрудник (Задание 2.4)
    /// </summary>
    internal class Employee
    {
        public string Name { get; private set; }
        public Department Department { get; private set; }
        public bool IsChief { get; private set; }

        public Employee(string name, Department department)
        {
            Name = name;
            Department = department;
            IsChief = false;
        }

        public void SetAsChief(Department department)
        {
            if (department == Department)
            {
                IsChief = true;
            }
        }

        public override string ToString()
        {
            if (IsChief)
            {
                return $"{Name} начальник отдела {Department.Name}";
            }
            else
            {
                string chiefName = Department.Chief != null ? Department.Chief.Name : "не назначен";
                return $"{Name} работает в отделе {Department.Name}, начальник которого {chiefName}";
            }
        }
    }
}
