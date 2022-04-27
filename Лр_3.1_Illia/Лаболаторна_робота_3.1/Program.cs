using System;

namespace Name
{
    class Program
    {
        static void Main()
        {
            Student[] studs = ReadData("input.txt");
            Console.WriteLine("Choose student");
            Console.WriteLine("1 - Illia \n2 - Olia");
            int a;
            do
            {
                a = Int32.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine();
                        foreach (Student s in studs)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        runMenu_Illia(studs);
                        break;
                    case 2:
                        Console.WriteLine();
                        foreach (Student s in studs)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        runMenu_Olia(studs);
                        break;
                    default: break;
                }
            }
            while (a != 0);           
        }
        struct Student
        {
            public string surName;
            public string firstName;
            public string patronymic;
            public char sex;
            public string dateOfBirth;
            public char mathematicsMark;
            public char physicsMark;
            public char informaticsMark;
            public int scholarship;

            public Student(string lineWithAllData)
            {
                string[] ReadyData = lineWithAllData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                surName = ReadyData[0];
                firstName = ReadyData[1];
                patronymic = ReadyData[2];
                sex = Convert.ToChar(ReadyData[3]);
                dateOfBirth = ReadyData[4];
                mathematicsMark = Convert.ToChar(ReadyData[5]);
                physicsMark = Convert.ToChar(ReadyData[6]);
                informaticsMark = Convert.ToChar(ReadyData[7]);
                scholarship = Convert.ToInt32(ReadyData[8]);
            }
            public override string ToString()
            {
                return $"{surName}\t{firstName}\t{patronymic} | {sex} {dateOfBirth} {mathematicsMark} {physicsMark} {informaticsMark} {scholarship}грн.";
            }
        }
        static void runMenu_Illia(Student[] studs)
        {
            Console.WriteLine("Вивести прізвища, імена і по батькові всіх студентів чоловічої статі, старших 18 років.");
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i].sex == 'M' || studs[i].sex == 'М' || studs[i].sex == 'Ч')
                {
                    var EndDate = DateTime.Now;
                    var StarData = Convert.ToDateTime(studs[i].dateOfBirth);
                    if ((EndDate - StarData).TotalDays / 365 >= 18)
                    {
                        Console.Write(studs[i].surName + " ");
                        Console.Write(studs[i].firstName + " ");
                        Console.Write(studs[i].patronymic);
                        Console.WriteLine();
                    }
                }
            }
        }
        static void runMenu_Olia(Student[] studs)
        {
            DateTime today = DateTime.Today;
            int count = 0;
            bool[] do16rokiv = new bool[studs.Length];
            for (int i = 0; i < studs.Length; i++)
            {
                string[] predatum = studs[i].dateOfBirth.Split(".");
                DateTime datum = new DateTime(int.Parse(predatum[2]), int.Parse(predatum[1]), int.Parse(predatum[0]));
                if (today.AddYears(-16) < datum)
                {
                    do16rokiv[i] = true;
                    count++;
                }
            }
            if(count != 0)
            {
                Console.WriteLine("Молодшi 16-ти " + count + " студентiв:");
                for (int i = 0; i < do16rokiv.Length; i++)
                {
                    if (do16rokiv[i])
                    {
                        Console.WriteLine(studs[i]);
                    }
                }
            }
            else Console.WriteLine("Немає студентів молодше 16.");            
        }
        static Student[] ReadData(string fileName)
        {
            string[] ReadData = File.ReadAllLines(fileName);
            Student[] Studs = new Student[ReadData.Length];
            for (int i = 0; i < ReadData.Length; i++)
            {
                Studs[i] = new Student(ReadData[i]);
            }
            return Studs;
        }
    }
}
