using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    abstract class Employee
    {
        public double Salary { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Boss { get; set; }
        public string Task{ get; set; }
        public Employee(string surname, string address, DateTime birthDate, string task)
        {
            Surname = surname;
            Address = address;
            BirthDate = birthDate;
        }
        public abstract void GetSalary(int client, int success);      
    }
}