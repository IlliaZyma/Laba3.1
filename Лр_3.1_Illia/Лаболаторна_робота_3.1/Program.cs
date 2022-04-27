using System;

namespace Name
{
    class Program
    {
        static void Main()
        {

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
