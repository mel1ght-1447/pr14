//*******************************************
//* Практическая работа №14                 *
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
        string Name;
        string BirthDate;
        string Gender;
        string Diagnosis;
        string Doctor;


        public void OutputInfo()
        {
            Console.WriteLine(
                $"Пациент: {Name} \nДата рождения: {BirthDate} \nПол: {Gender} \nДиагноз: {Diagnosis} \nВрач: {Doctor}");
        }


        class Program
        {
            static void Main()
            {
                bool repeat = true;
                while (repeat)
                {
                    try
                    {
                        Console.Title = "Практическая работа № 14";
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("Здравствуйте!");

                        Console.Write("\nВведите количество пациентов: ");
                        int n = int.Parse(Console.ReadLine());
                        if (n == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Количество пациентов должно быть больше нуля!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(0);
                        }
                        Patient[] patients = new Patient[n];


                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"\nПациент №{i + 1}");
                            patients[i] = InputPatient();
                        }


                        Console.WriteLine("\n=== СПИСОК ПАЦИЕНТОВ ===");
                        for (int i = 0; i < n; i++)
                            patients[i].OutputInfo();

                        CountPatientsByDoctor(patients);
                        FindByDiagnosis(patients);
                        GenderStatistics(patients);

                        Console.WriteLine("Нажмите Y - выход из консоли, N - повтор");
                        string selectKey = Console.ReadLine();
                        Console.WriteLine();
                        switch (selectKey)
                        {
                            case "N":
                                repeat = true;
                                break;
                            case "Y":
                                repeat = false;
                                Environment.Exit(0);
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введена неправильная буква");
                                Console.ForegroundColor = ConsoleColor.White;
                                Environment.Exit(0);
                                repeat = false;
                                break;
                        }
                    }
                    catch (FormatException fe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: " + fe.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка: " + ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }


            static Patient InputPatient()
            {
                Patient p = new Patient();
                try
                {
                    for (int h = 0; h < 1; h++)
                    {
                        Console.Write("Фамилия и инициалы: ");
                        p.Name = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(p.Name))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите фамилию и инициалы!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }

                    }
                    for (int h = 0; h < 1; h++)
                    {
                        Console.Write("Дата рождения (дд.мм.гггг): ");
                        p.BirthDate = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(p.BirthDate))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите дату рождения!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }
                    }
                    for (int h = 0; h < 1; h++)
                    {
                        Console.Write("Пол (м/ж): ");
                        p.Gender = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(p.Gender))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите гендер!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }
                        else if (p.Gender != "м" && p.Gender != "ж")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите гендер (м или ж)!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }

                    }
                    for (int h = 0; h < 1; h++)
                    {
                        Console.Write("Диагноз: ");
                        p.Diagnosis = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(p.Diagnosis))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите диагноз!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }

                    }
                    for (int h = 0; h < 1; h++)
                    {
                        Console.Write("Леч. врач: ");
                        p.Doctor = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(p.Doctor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите леч. врач!");
                            Console.ForegroundColor = ConsoleColor.White;
                            h--;
                        }

                    }
                }
                catch (FormatException fe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: " + fe.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return p;
            }

            static void CountPatientsByDoctor(Patient[] patients)
            {
                Console.WriteLine("\n=== КОЛИЧЕСТВО ПАЦИЕНТОВ У ВРАЧЕЙ ===");

                for (int i = 0; i < patients.Length; i++)
                {
                    bool found = false;
                    for (int j = 0; j < i; j++)
                        if (patients[j].Doctor == patients[i].Doctor)
                            found = true;

                    if (!found)
                    {
                        int count = 0;
                        for (int j = 0; j < patients.Length; j++)
                            if (patients[j].Doctor == patients[i].Doctor)
                                count++;

                        Console.WriteLine($"{patients[i].Doctor}: {count}");
                    }
                }
            }

            static void FindByDiagnosis(Patient[] patients)
            {
                Console.Write("\nВведите диагноз для поиска: ");
                string FoundByDiagnosis = Console.ReadLine();
                bool found = false;

                for (int i = 0; i < patients.Length; i++)
                {
                    if (patients[i].Diagnosis == FoundByDiagnosis)
                    {
                        patients[i].OutputInfo();
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пациентов с таким диагнозом нет");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            static void GenderStatistics(Patient[] patients)
            {
                int male = 0, female = 0;

                for (int i = 0; i < patients.Length; i++)
                {
                    if (patients[i].Gender == "м")
                        male++;
                    else if (patients[i].Gender == "ж")
                        female++;
                }

                Console.WriteLine("\n=== СТАТИСТИКА ПО ПОЛУ ===");
                Console.WriteLine($"Мужчины: {male * 100 / patients.Length}%");
                Console.WriteLine($"Женщины: {female * 100 / patients.Length}%");
            }
        }
    }
}
