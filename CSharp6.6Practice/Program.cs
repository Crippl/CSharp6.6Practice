using System;
using System.IO;
using System.Text;
using static System.Console;

namespace CSharp6._6Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correct;
            string path = @"Employees.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            for (int i = 0; i < int.MaxValue; i++)
            {
                WriteLine("Что вы желаете сделать? 1 - Отобразить, 2 - Добавить новую запись, 3 - Выйти из программы");
                correct = byte.TryParse(ReadLine(), out byte choose);
                if (correct)
                {
                    switch (choose)
                    {
                        case 1:
                            ShowEmployee(path);
                            WriteLine();
                            break;
                        case 2:
                            AddEmployee(path);
                            WriteLine();
                            break;
                        case 3:
                            System.Environment.Exit(0);
                            break;
                        default:
                            WriteLine("Такого параметра не существует");
                            break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Метод, отображающий данные на экране
        /// </summary>
        static void ShowEmployee(string path)
        {
            using (StreamReader showEmployees = new StreamReader(path))
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
        static void AddEmployee(string path)
        {
            using (StreamWriter addEmployees = new StreamWriter(path, true))
            {
                char key = 'y';

                do
                {
                    StringBuilder info = new StringBuilder();
                    Write("\nВведите ID сотрудника: ");
                    info.Append($"{ReadLine()}#");

                    string writeTime = DateTime.Now.ToString("g");
                    WriteLine($"Запись добавлена: {writeTime}");
                    info.Append($"{writeTime}#");

                    Write("Введи Ф.И.О. сотрудника: ");
                    info.Append($"{ReadLine()}#");

                    Write("Введи возраст сотрудника: ");
                    info.Append($"{ReadLine()}#");

                    Write("Введи рост сотрудника: ");
                    info.Append($"{ReadLine()}см#");

                    Write("Введи дату рождения сотрудника: ");
                    info.Append($"{ReadLine()}#");

                    Write("Введи город рождения сотрудника: ");
                    info.Append($"город {ReadLine()}#");

                    addEmployees.WriteLine(info);
                    Write("Продолжить ввод? y/n");
                    key = ReadKey(true).KeyChar;
                    
                } while (char.ToLower(key)=='y');
            }
        }
    }
}
