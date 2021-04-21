using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class DepartmentHead : Employee
    {
        public DepartmentHead(string surname, string address, DateTime birthDate, string task) : base(surname, address, birthDate,task)
        {
            Boss = "Він самий головний";
            Position = "Начальник відділу";
        }
        public override void GetSalary(int client, int success)
        {
           
            Salary = client * 1500 + 500 * success + 10000;
            Console.WriteLine($"заробітна плата - {Salary}");
        }
    }
}