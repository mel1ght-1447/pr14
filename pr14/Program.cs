//*******************************************
//* Практическая работа №16                 *
//* Выполнил: Быков М.С., группа 2ИСП       *
//* Вариант: 2                              *
//*******************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14
{
    struct Patient
    {
        public string LastName;
        public string Initials;
        public DateTime BirthDate;
        public string Gender;
        public string Diagnosis;
        public string Doctor;

        public void OutputInfo()
        {
            Console.WriteLine(
                $"{LastName} {Initials}, Дата рождения: {BirthDate.ToShortDateString()}, " +
                $"Пол: {Gender}, Диагноз: {Diagnosis}, Врач: {Doctor}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Оформление консоли
            Console.Title = "Практическая работа № 14";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");

            try
            {
                Console.Write("\nВведите количество пациентов: ");
                int n = int.Parse(Console.ReadLine());

                Patient[] patients = new Patient[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nПациент №{i + 1}");

                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write("Фамилия: ");
                        patients[i].LastName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(patients[i].LastName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите фамилию!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }

                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write("Инициалы: ");
                        patients[i].Initials = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(patients[i].Initials))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите инициалы!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                    }
                    for (int j = 0; j < 1; j++)
                    {

                        Console.Write("Дата рождения (дд.мм.гггг): ");
                        try
                        {
                            patients[i].BirthDate = DateTime.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка! Введите дату в формате дд.мм.гггг");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write("Пол (м/ж): ");
                        patients[i].Gender = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(patients[i].Gender))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите гендер!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                        else if (patients[i].Gender != "м" && patients[i].Gender != "ж")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите гендер!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                        else break;
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write("Диагноз: ");
                        patients[i].Diagnosis = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(patients[i].Diagnosis))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите диагноз!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write("Леч.врач: ");
                        patients[i].Doctor = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(patients[i].Doctor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите леч.врача!");
                            Console.ForegroundColor = ConsoleColor.White;
                            j--;
                        }
                    }
                }

                // Вывод всех пациентов
                Console.WriteLine("\n=== СПИСОК ПАЦИЕНТОВ ===");
                for (int i = 0; i < n; i++)
                    patients[i].OutputInfo();

                // Количество пациентов у каждого врача
                Console.WriteLine("\n=== КОЛИЧЕСТВО ПАЦИЕНТОВ У ВРАЧЕЙ ===");
                for (int i = 0; i < n; i++)
                {
                    bool printed = false;
                    int count = 0;

                    for (int j = 0; j < i; j++)
                        if (patients[j].Doctor == patients[i].Doctor)
                            printed = true;

                    if (!printed)
                    {
                        for (int j = 0; j < n; j++)
                            if (patients[j].Doctor == patients[i].Doctor)
                                count++;

                        Console.WriteLine($"{patients[i].Doctor}: {count}");
                    }
                }

                // Поиск по диагнозу
                Console.Write("\nВведите диагноз для поиска: ");
                string findDiagnosis = Console.ReadLine();
                bool found = false;

                for (int i = 0; i < n; i++)
                {
                    if (patients[i].Diagnosis == findDiagnosis)
                    {
                        patients[i].OutputInfo();
                        found = true;
                    }
                }

                if (!found)
                    Console.WriteLine("Пациентов с таким диагнозом нет.");

                // Статистика по полу
                int male = 0, female = 0;
                for (int i = 0; i < n; i++)
                {
                    if (patients[i].Gender == "м")
                        male++;
                    else if (patients[i].Gender == "ж")
                        female++;
                }

                Console.WriteLine("\n=== СТАТИСТИКА ===");
                Console.WriteLine($"Мужчины: {male * 100 / n}%");
                Console.WriteLine($"Женщины: {female * 100 / n}%");
            }
            catch
            {
                Console.WriteLine("Ошибка ввода данных!");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

