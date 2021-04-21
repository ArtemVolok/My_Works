using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Specialist : Employee
    {
        //public string BossSurname { get; set; }
        public Specialist(string surname, string address, DateTime birthDate, string task, string bossHeadOfSector) : base(surname, address, birthDate, task)
        {
            Boss = bossHeadOfSector;
            Position = "Спеціаліст";
        }
        public override void GetSalary(int client, int success)
        {
            Salary = client * 500 + 100 * success + 2000 - ((client / success) * 150);
            Console.WriteLine($"Заробітна плата - {Salary}");
        }
    }
}