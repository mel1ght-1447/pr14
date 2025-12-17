using System;

struct Patient
{
    public string LastName;
    public string Initials;
    public DateTime BirthDate;
    public string Gender;
    public string Diagnosis;
    public string Doctor;

    // Метод вывода информации
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

        Console.Write("\nВведите количество пациентов: ");
        int n = int.Parse(Console.ReadLine());

        Patient[] patients = new Patient[n];

        // Ввод данных
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nПациент №{i + 1}");
            patients[i] = InputPatient();
        }

        // Вывод
        Console.WriteLine("\n=== СПИСОК ПАЦИЕНТОВ ===");
        for (int i = 0; i < n; i++)
            patients[i].OutputInfo();

        CountPatientsByDoctor(patients);
        FindByDiagnosis(patients);
        GenderStatistics(patients);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    // ===== МЕТОДЫ =====

    static Patient InputPatient()
    {
        Patient p = new Patient();

        Console.Write("Фамилия: ");
        p.LastName = Console.ReadLine();

        Console.Write("Инициалы: ");
        p.Initials = Console.ReadLine();

        // Ввод даты с проверкой
        while (true)
        {
            Console.Write("Дата рождения (дд.мм.гггг): ");
            if (DateTime.TryParse(Console.ReadLine(), out p.BirthDate))
                break;
            Console.WriteLine("Ошибка! Повторите ввод даты.");
        }

        Console.Write("Пол (м/ж): ");
        p.Gender = Console.ReadLine();

        Console.Write("Диагноз: ");
        p.Diagnosis = Console.ReadLine();

        Console.Write("Лечащий врач: ");
        p.Doctor = Console.ReadLine();

        return p;
    }

    static void CountPatientsByDoctor(Patient[] patients)
    {
        Console.WriteLine("\n=== КОЛИЧЕСТВО ПАЦИЕНТОВ У ВРАЧЕЙ ===");

        for (int i = 0; i < patients.Length; i++)
        {
            bool printed = false;
            for (int j = 0; j < i; j++)
                if (patients[j].Doctor == patients[i].Doctor)
                    printed = true;

            if (!printed)
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
        string diag = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < patients.Length; i++)
        {
            if (patients[i].Diagnosis == diag)
            {
                patients[i].OutputInfo();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Пациентов с таким диагнозом нет.");
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
