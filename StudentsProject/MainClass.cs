using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //added strings so u wont have typo's
            string CS = "Computer Science";
            string Math = "Mathematics";
            string Physics = "Physics";
            string Books = "Literature";
            string BagrutInc = "History";
            string Sports = "Sport";

            Subject s1 = new Subject(CS);
            Subject s2 = new Subject(Math);
            Subject s3 = new Subject(Physics);
            Subject s4 = new Subject(Books);

            Student st1 = new Student("yossi", 15, 158);
            Student st2 = new Student("Dafna", 16, 163);
            Student st3 = new Student("beni", 14, 146);

            st1.AddSubject(s1);
            st1.AddSubject(s2);
            st1.AddSubject(s3);
            
            st2.AddSubject(s2);
            st2.AddSubject(s4);

            Console.WriteLine(st1.AddTestToSubject(Sports, 85));
            Console.WriteLine(st1.AddTestToSubject(BagrutInc, -10));
            Console.WriteLine(st1.AddTestToSubject(BagrutInc, 100));

            Console.WriteLine(st1.AddTestToSubject(CS, 100));
            Console.WriteLine(st1.AddTestToSubject(CS, 50));
            Console.WriteLine(st1.AddTestToSubject(Math, 60));

            Console.WriteLine(st1.GetAverageAtSubject(CS));

            Console.WriteLine(st2.AddTestToSubject(Math, 85));
            Console.WriteLine(st2.AddTestToSubject(Books, 45));

            Student[] students = new Student[3];
            students[0] = st1;
            students[1] = st2;
            students[2] = st3;

            Console.WriteLine("checking NumTests:");
            Console.WriteLine(StudentsUtil.NumTests(st1.GetSubjects()));
            Console.WriteLine(StudentsUtil.NumTests(st2.GetSubjects()));
            Console.WriteLine(StudentsUtil.NumTests(st3.GetSubjects()));

            Console.WriteLine("checking NumSubjectsAboveAverage:");
            Console.WriteLine(StudentsUtil.NumSubjectsAboveAverage(st1.GetSubjects(), 80));
            Console.WriteLine(StudentsUtil.NumSubjectsAboveAverage(st2.GetSubjects(), 80));
            Console.WriteLine(StudentsUtil.NumSubjectsAboveAverage(st3.GetSubjects(), 80));

            Console.WriteLine("checking NumStudentsHeigherThan:");
            Console.WriteLine(StudentsUtil.NumStudentsHeigherThan(students, 150));

            Console.WriteLine("checking NumStudentsPassedSubject:");
            Console.WriteLine(StudentsUtil.NumStudentsPassedSubject(students, BagrutInc));
            Console.WriteLine(StudentsUtil.NumStudentsPassedSubject(students, Books));
            Console.WriteLine(StudentsUtil.NumStudentsPassedSubject(students, Math));

            Console.WriteLine("checking BestStudentAverageAtSubject:");
            Student bestAtMathematics = StudentsUtil.BestStudentAverageAtSubject(students, s2);
            bestAtMathematics.AddTestToSubject(Math, 0);
            Console.WriteLine(StudentsUtil.BestStudentAverageAtSubject(students, s2).GetFullName());
        }
    }
}
