using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;


namespace OOP
{
    class Group
    {
        public List<Employee> employees = new List<Employee>();

        public void Age(string job)
        {
            Console.Write("Якщо хочете отримати мінімальний вік - натисніть 0, в іншому випадку натисні 1--> ");
            int answer = int.Parse(Console.ReadLine());
          
            if (answer == 1)
            {
                List<Employee> list = new List<Employee>();
                switch(job.ToLower())
                {
                    case "начальник відділу":
                        for (int t = 0; t < employees.Count; t++)
                        {
                            if (employees[t] is DepartmentHead)
                            {
                                list.Add(employees[t]);
                            }
                        }
                        break;
                    case "начальник сектору":
                        for (int t = 0; t < employees.Count; t++)
                        {
                            if (employees[t] is HeadOfSector)
                            {
                                list.Add(employees[t]);
                            }
                        }
                        break;
                    case "спеціаліст":
                        for (int t = 0; t < employees.Count; t++)
                        {
                            if (employees[t] is Specialist)
                            {
                                list.Add(employees[t]);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Даної професії не існує!");
                        return;
                }
                if (list.Count != 0)
                {
                    int max = DateTime.Now.Year - list[0].BirthDate.Year;
                    string surname = list[0].Surname;
                    for (int i = 1; i < list.Count; i++)
                    {
                        if (max < DateTime.Now.Year - list[i].BirthDate.Year)
                        {
                            max = DateTime.Now.Year - list[i].BirthDate.Year;
                            surname = list[i].Surname;
                        }
                    }
                    Console.WriteLine($"Максимальный вік у працівника {surname}. Його вік дорівнює {max}. Він працює {job}");
                }
                else
                {
                    Console.WriteLine("працівників даної професії не знайдено!");
                }
            }
        }

        public void TreeOutput(string surname, string position)
        {
            string[] array = new string[60];
            int count = 0;
            for (int w = 0; w < 2; w++)
                switch (position)
                {
                    case "Начальник відділу":
                      
                        for (int t = 0; t < employees.Count; t++)
                        {
                            if (employees[t] is DepartmentHead)
                            {
                                if (surname == employees[t].Surname)
                                    count++;
                            }
                        }
                        if (count != 0)
                        {
                            int i = 0;
                            for (int t = 0; t < employees.Count; t++)
                            {
                                if (employees[t] is HeadOfSector)
                                {
                                    if (employees[t].Boss == surname)
                                    {
                                        array[i] = employees[t].Surname;
                                        i++;
                                    }
                                }
                            }
                           
                            if (array[0] != null)
                            {
                                i = 0;
                                Console.WriteLine($"У начальника відділу {surname} є підлеглі: ");
                                while (array[i] != null)
                                {
                                    if (array[i + 1] != null)
                                    {
                                        Console.Write(array[i] + ", ");
                                        i++;
                                    }
                                    else
                                    {
                                        Console.WriteLine(array[i] + ".");
                                        i++;
                                    }
                                }
                                position = "Начальник сектору";
                            }
                            else
                            {
                                Console.WriteLine($"У начальник відділу {surname} немає підлеглих.");
                                w = 2;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Начальника відділу {surname} не існує");
                            w = 2;
                        }
                        break;
                    case "Начальник сектору":
                        count = 0;
                        if (array[0] == null) //когда не от босса
                        {
                            for (int t = 0; t < employees.Count; t++)
                            {
                                if (employees[t] is HeadOfSector)
                                {
                                    if (surname == employees[t].Surname)
                                        count++;
                                }
                            }
                            if (count != 0)
                            {
                                int i = 0;
                                for (int t = 0; t < employees.Count; t++)
                                {
                                    if (employees[t] is Specialist)
                                    {
                                        if (employees[t].Boss == surname)
                                        {
                                            array[i] = employees[t].Surname;
                                            i++;
                                        }
                                    }
                                }                               
                                if (array[0] != null)
                                {
                                    i = 0;
                                    Console.Write("У начальника сектору є підлеглі: ");
                                    while (array[i] != null)
                                    {
                                        if (array[i + 1] != null)
                                        {
                                            Console.Write(array[i] + ", ");
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine(array[i] + ".");
                                            i++;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"У начальника сектору {surname} немає підлеглих.");
                                    w = 2;
                                }
                            }
                        }
                        else // когда пришел от босса
                        {
                            int q = 0, i = 0;
                            string[] arrayOfSpecialist = new string[600];
                            while (array[q] != null)
                            {
                                i = 0;
                                for (int t = 0; t < employees.Count; t++)
                                {
                                    if (employees[t] is Specialist)
                                    {
                                        if (employees[t].Boss == array[q])
                                        {
                                            arrayOfSpecialist[i] = employees[t].Surname;
                                            i++;
                                        }
                                    }
                                }
                           
                                if (arrayOfSpecialist[0] != null)
                                {
                                    i = 0;
                                    Console.WriteLine($"У начальника сектору {array[q]} є підлеглі: ");
                                    while (arrayOfSpecialist[i] != null)
                                    {
                                        if (arrayOfSpecialist[i + 1] != null)
                                        {
                                            Console.Write(arrayOfSpecialist[i] + ", ");
                                            i++;
                                        }
                                        else
                                        {
                                            Console.WriteLine(arrayOfSpecialist[i] + ".");
                                            i++;
                                            w = 2;
                                            q++;
                                            Array.Clear(arrayOfSpecialist, 0, arrayOfSpecialist.Length - 1);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"У начальника сектору {array[q]} немає підлеглих.");
                                    w = 2;
                                    q++;
                                }
                            }
                        }
                        break;
                    case "Спеціаліст":
                        Console.WriteLine("У спеціаліста немає підлеглих");
                        w = 2;
                        break;
                    default:
                        Console.WriteLine("Ви неправильно ввели назву посади");
                        w = 2;
                        break;
                }
        }
        string line;
        string []str = new string[100];
        public void FileAction()
        {
            DateTime dateTime = new DateTime();
            string deparmentHeadSurname, address, task, headOfSectorSurname, specialistSurname;
            int headOfSectorCount, specialistCount;
            int c = 1;
            if (str[0] != null)
            {
                for (int i = 0; i < int.Parse(str[0].ToString()); i++)
                {
                    deparmentHeadSurname = str[c];
                    c++;
                    address = str[c];
                    c++;
                    DateTime.TryParse(str[c].ToString(), out dateTime);
                    c++;
                    task = str[c];
                    c++;

                    employees.Add(new DepartmentHead(deparmentHeadSurname, address, dateTime, task)); //departmentHeads
                    headOfSectorCount = int.Parse(str[c]);
                    c++;
                    for (int j = 0; j < headOfSectorCount; j++)
                    {
                        headOfSectorSurname = str[c];
                        c++;
                        address = str[c];
                        c++;
                        DateTime.TryParse(str[c], out dateTime);
                        c++;
                        task = str[c];
                        c++;
                        employees.Add(new HeadOfSector(headOfSectorSurname, address, dateTime, task, deparmentHeadSurname)); //headOfSectors
                        specialistCount = int.Parse(str[c]);
                        c++;
                        for (int q = 0; q < specialistCount; q++)
                        {
                            specialistSurname = str[c];
                            c++;
                            address = str[c].ToString();
                            c++;
                            DateTime.TryParse(str[c], out dateTime);
                            c++;
                            task = str[c];
                            c++;
                            employees.Add(new Specialist(specialistSurname, address, dateTime, task, headOfSectorSurname)); //specialists
                        }
                    }
                }
            }
        }
        public void FileOutput()
        {
            string path = @"C:\Users\Admin\Desktop\Лабы 3 курс\Об'єктно-орієнтоване програмування\Output.txt";
            string text = "";
            if (employees.Count != 0)
            {
                text += "Є працівники: \r\n ";
                for (int i = 0; i < employees.Count; i++)
                {
                    text += $"{employees[i].Surname} займає посаду {employees[i].Position}. Проживає за адресою {employees[i].Address}. \r\n ";
                }
            }
            else text += "Працівників немає.";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
                text = "";
            }

        }
        public void FileRead()
        {
            string path = @"C:\Users\Admin\Desktop\Лабы 3 курс\Об'єктно-орієнтоване програмування\Input.txt";
            StreamReader sr = new StreamReader(path);
            line = sr.ReadLine();
            str[0] = line;
            int i = 1;
            while (line != null)
            {
                line = sr.ReadLine();
                str[i] = line;
                i++;
            }
            sr.Close();
        }

        public void OutputNames()
        {
            if (employees.Count != 0)
            {
                Console.WriteLine("Є працівники:");
                for(int i = 0; i < employees.Count;i++)
                {
                    Console.WriteLine($"{employees[i].Surname} займає посаду {employees[i].Position}. Проживає за адресою {employees[i].Address}.");
                }
            }
            else Console.WriteLine("Працівників немає.");
        }
        public void FillSpecialist()
        {
            string deparmentHeadSurname, headOfSectorSurname, address = "", task = "", specialistSurname;
            DateTime dateTime = new DateTime();
            Console.Write("Введіть кількість начальників відділу-->");
            int departmentHeadCount = int.Parse(Console.ReadLine());
            int headOfSectorCount, specialistCount;
            for (int i = 0; i < departmentHeadCount; i++)
            {
                Console.Write("Введіть прізвище начальника відділу--> ");
                deparmentHeadSurname = Console.ReadLine();
                Console.Write("введіть адресу проживання начальнику відділу--> ");
                address = Console.ReadLine();
                Console.Write("Введіть дату народження начальнику відділу в форматі день/месяць/рік--> ");
                DateTime.TryParse(Console.ReadLine(), out dateTime);
                Console.Write("Введіть задачу начальника відділу--> ");
                task = Console.ReadLine();

                employees.Add(new DepartmentHead(deparmentHeadSurname, address, dateTime, task)); //departmentHeads
                Console.Write($"Введіть кількість начальників секторів підлеглих {deparmentHeadSurname}--> ");
                headOfSectorCount = int.Parse(Console.ReadLine());
                for (int j = 0; j < headOfSectorCount; j++)
                {
                    Console.Write("Введіть прізвище начальника сектора--> ");
                    headOfSectorSurname = Console.ReadLine();
                    Console.Write("Введіть адресу проживання начальника сектора--> ");
                    address = Console.ReadLine();
                    Console.Write("Ввдіть дату народження начальника сектора в форматі день/месяць/рік--> ");
                    DateTime.TryParse(Console.ReadLine(), out dateTime);
                    Console.Write("Введіть задачу начальника сектора--> ");
                    task = Console.ReadLine();
                    employees.Add(new HeadOfSector(headOfSectorSurname, address, dateTime, task, deparmentHeadSurname)); //headOfSectors
                    Console.Write($"Введіть кількість спеціалістів підлеглих {headOfSectorSurname}--> ");
                    specialistCount = int.Parse(Console.ReadLine());
                    for (int q = 0; q < specialistCount; q++)
                    {
                        Console.Write("Введіть прізвище спеціаліста--> ");
                        specialistSurname = Console.ReadLine();
                        Console.Write("Введіть адресу проживання спеціаліста--> ");
                        address = Console.ReadLine();
                        Console.Write("Введіть дату проживання спеціаліста в форматі день/місяць/рік--> ");
                        DateTime.TryParse(Console.ReadLine(), out dateTime);
                        Console.Write("Введіть задачу спеціаліста--> ");
                        task = Console.ReadLine();
                        employees.Add(new Specialist(specialistSurname, address, dateTime, task, headOfSectorSurname)); //specialists
                    }
                }
            }
        }
    }
}
