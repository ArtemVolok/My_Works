using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class HeadOfSector : Employee
    {
        //public string BossSurname { get; set; } 
        public HeadOfSector(string surname, string address, DateTime birthDate, string task, string bossDepartmentHead) : base(surname, address, birthDate,task)
        {
            Boss = bossDepartmentHead;
            Position = "Начальник сектору";
        }
        public  override void GetSalary(int client, int success)
        {
            
            Salary = client * 1000 + 200 * success + 2000 - ((client / success) * 100);
            Console.WriteLine($"Заробітна плата - {Salary}");
        }
    }
}
