using System;
using System.IO;
using static System.Console;

namespace CSharp6._6Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correct;

            for (int i = 0; i < int.MaxValue; i++)
            {
                WriteLine("Что вы желаете сделать? 1 - Отобразить, 2 - Добавить новую запись");
                correct = byte.TryParse(ReadLine(), out byte choose);
                if (correct)
                {
                    if (choose == 1)
                    {
                        ShowEmployee();
                        WriteLine();
                    }
                    else if (choose == 2)
                    {
                        AddEmployee();
                        WriteLine();
                    }
                    else
                    {
                        WriteLine($"Нет выбора {choose}");
                    }
                }
                else
                {
                    WriteLine("Такого параметра не существует");
                    break;
                }
            }
        }
        
        /// <summary>
        /// Метод, отображающий данные на экране
        /// </summary>
        static void ShowEmployee()
        {
            using (StreamReader showEmployees = new StreamReader("Employees.txt"))
            {
                string employeesInfo;
                while ((employeesInfo=showEmployees.ReadLine()) != null)
                {
                    employeesInfo = employeesInfo.Replace('#', ' ');
                    WriteLine($"{employeesInfo}");
                }
            }
        }

        /// <summary>
        /// Метод, позволяющий заполнить данные и добавить новую запись
        /// </summary>
        static void AddEmployee()
        {
            using (StreamWriter addEmployees = new StreamWriter("Employees.txt", true))
            {
                char key = 'y';

                do
                {
                    string info = string.Empty;
                    Write("\nВведите ID сотрудника: ");
                    info += $"{ReadLine()}#";

                    string writeTime = DateTime.Now.ToString("g");
                    WriteLine($"Запись добавлена: {writeTime}");
                    info += $"{writeTime}#";

                    Write("Введи Ф.И.О. сотрудника: ");
                    info += $"{ReadLine()}#";

                    Write("Введи возраст сотрудника: ");
                    info += $"{ReadLine()}#";

                    Write("Введи рост сотрудника: ");
                    info += $"{ReadLine()}см#";

                    Write("Введи дату рождения сотрудника: ");
                    info += $"{ReadLine()}#";

                    Write("Введи город рождения сотрудника: ");
                    info += $"город {ReadLine()}#";

                    addEmployees.WriteLine(info);
                    Write("Продолжить ввод? y/n");
                    key = ReadKey(true).KeyChar;
                    
                } while (char.ToLower(key)=='y');
            }
        }
    }
}
