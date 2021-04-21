using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            string answear = "так";
            int choice, action;
            string outputSurname, outputPosition;
            string job, surname;
            Group group = new Group();
            while (answear.ToLower() == "так")
            {
                try
                {
                    int ans;
                    Console.WriteLine("Що б ви хотіли зробити?\r\n1- вивести список всіх робітників\r\n2 - добавити робітників\r\n3 - видалити робітників\r\n4 - дізнатися мінімальний або максимальний вік\r\n5 - вивести дерево підлеглих\r\n6 - дізнатися заробітну плату.");
                    action = int.Parse(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("Вивести дані в консоль - 1, вивести дані в файл - 2");
                            ans = int.Parse(Console.ReadLine());
                            switch (ans)
                            {
                                case 1:
                                    group.OutputNames();
                                    break;
                                case 2:
                                    group.FileOutput();
                                    break;
                                default:
                                    Console.WriteLine("Даного варіанту вудповіді немає");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Вивести дані вручну - 1, ввести дані с файлу - 2");
                            ans = int.Parse(Console.ReadLine());
                            switch(ans)
                            {
                                case 1:
                                    group.FillSpecialist();
                                    break;
                                case 2:
                                    group.FileRead();
                                    group.FileAction();
                                    break;
                                default:
                                    Console.WriteLine("Даного варіанту відповіді немає");
                                    break;
                            }
                            break;
                        case 3:
                            Delete(group);
                            break;
                        case 4:
                            if (group.employees.Count == 0)
                                Console.WriteLine("Список пустий.");
                            else
                            {
                                Console.Write("Введіть назву професії--> ");
                                string answ = Console.ReadLine();
                                group.Age(answ);
                            }
                            break;
                        case 5:
                            if (group.employees.Count == 0)
                                Console.WriteLine("Список пустий.");
                            else
                            {
                                Console.Write("Введіть прізвище шуканого співробітника--> ");
                                outputSurname = Console.ReadLine();
                                Console.Write("Введіть посаду шуканого співробітника--> ");
                                outputPosition = Console.ReadLine();
                                group.TreeOutput(outputSurname, outputPosition);
                            }
                            break;
                        case 6:
                            GetSalary(group);
                            break;
                        default:
                            Console.WriteLine("Даного варіанту відповіді немає");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Неправильний тип даних");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Бажаєте продовжити?");
                answear = Console.ReadLine();
            }
        }

        private static void GetSalary(Group group)
        {
            if (group.employees.Count == 0)
                Console.WriteLine("Список пустий.");
            else
            {
                int count = 0, i = 0, client, success;
                string job;
                Console.Write("Введіть посаду--> ");
                job = Console.ReadLine();
                Console.WriteLine("Введіть кількість клієнтів--> ");
                client = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть кількість успішних угод--> ");
                success = int.Parse(Console.ReadLine());
                while (count == 0 && group.employees.Count > i)
                {

                    if (group.employees[i].Position == job)
                    {
                        group.employees[i].GetSalary(client, success);
                        count++;

                    }
                    else
                    {
                        i++;
                        if (group.employees.Count == i)
                        {
                            Console.WriteLine("Працівників цієї спеціальності немає.");
                            count++;
                        }
                    }
                }
            }
        }

        static void Delete(Group group)
        {
            if (group.employees.Count != 0)
            {
                string job, surname;
                Console.WriteLine("Введіть посаду видаляємого працівника");
                job = Console.ReadLine();
                Console.WriteLine("Введіть прізвище видаляємого робітника");
                surname = Console.ReadLine();
                int count = 0;
                for (int i = 0; i < group.employees.Count; i++)
                {
                    if (group.employees[i].Surname.ToLower() == surname.ToLower() && group.employees[i].Position.ToLower() == job.ToLower())
                    {
                        group.employees.RemoveAt(i);
                        count++;
                    }
                }
                if (count == 0)
                    Console.WriteLine("Даного робітника знайдено не було");
            }
            else Console.WriteLine("Список пустий");
        }
    }
}