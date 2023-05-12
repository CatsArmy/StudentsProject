using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    class StudentsUtil
    {
        //טענת כניסה: הפעולה מקבלת מערך של מקצועות
        //טענת יציאה: הפעולה תחזיר את כמות כל המבחנים שנעשו במקצועות אשר במערך
        //תחזיר הפעולה 0 null אם המערך שהתקבל הוא 
        public static int NumTests(Subject[] subjects)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            if (subjects == null)
                return 0;
            int totalTestsTaken = 0;
            for (int i = 0; i < subjects.Length; i++)
            {
                totalTestsTaken += subjects[i].GetNumTests();
            }
            return totalTestsTaken;
        }

        ///טענת כניסה: הפעולה מקבלת מערך מקצועות וציון ממוצע
        ///טענת יציאה: הפעולה מחזירה את כמות המקצועות במערך שהתקבל שלהם ציון ממוצע הגבוה מהציון הממוצע שהתקבל
        ///תחזיר הפעולה 0 null אם המערך שהתקבל הוא 
        /// <summary>
        /// טענת יציאה: הפעולה מחזירה את כמות המקצועות במערך שהתקבל שלהם ציון ממוצע הגבוה מהציון הממוצע שהתקבל
        /// תחזיר הפעולה 0 null אם המערך שהתקבל הוא 
        /// </summary>
        /// <param name="subjects"></param>
        /// <param name="average"></param>
        /// <returns></returns>
        /// fixed name Avergae (before) Average (after)
        public static int NumSubjectsAboveAverage(Subject[] subjects, double average)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            if (subjects == null)
                return 0; 
            int subjectsAboveAverage = 0;
            double subjectAverage;
            for (int i = 0; i < subjects.Length; i++)
            {
                subjectAverage = subjects[i].GetAverage();
                subjectsAboveAverage += subjectAverage != -1 && subjectAverage > average ? 1 : 0;
            }
            return subjectsAboveAverage;
        }

        //טענת כניסה: הפעולה מקבלת מקבלת מערך תלמידים וגובה בסנטימטרים
        //טענת יציאה: הפעולה מחזירה את כמות התלמידים במערך הגבוהים מהגובה שהתקבל
        //תחזיר הפעולה 0 null אם המערך שהתקבל הוא 
        public static int NumStudentsHeigherThan(Student[] students, int height)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            if (students == null)
                return 0;
            int studentsHeigherThan = 0;
            int studentHight;
            for (int i = 0; i < students.Length; i++)
            {
                studentHight = students[i].GetHeight();
                studentsHeigherThan += studentHight > height ? 1 : 0;
                    
            }
            return studentsHeigherThan;
        }

        //טענת כניסה: הפעולה מקבלת מערך של תלמידים ושם של מקצוע
        /// <summary>
        /// טענת יציאה: הפעולה מחזירה את כמות התלמידים שלומדים את המקצוע שהתקבל ולהם ממוצע עובר של לפחות 55
        /// תחזיר הפעולה 0 null אם המערך שהתקבל הוא 
        /// </summary>
        /// <param name="students"></param>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        public static int NumStudentsPassedSubject(Student[] students, string subjectName)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            if (students == null)
                return 0;
            int studentsPassedSubject = 0;
            double studentSubjectAvg;
            for (int i = 0; i < students.Length; i++)
            {
                studentSubjectAvg = students[i].GetAverageAtSubject(subjectName);
                studentsPassedSubject += studentSubjectAvg > 55 ? 1 : 0;
            }
            return studentsPassedSubject;
        }

        //טענת כניסה: הפעולה מקבלת מערך של תלמידים ומקצוע
        //טענת יציאה: הפעולה מחזירה את העתק של הסטודנט אשר לו יש את הממוצע הגבוה ביותר במקצוע שהתקבל
        //null או שאין תלמיד הלומד את המקצוע ועשה בו מבחן אחד לפחות, תחזיר הפעולה null או שהמקצוע שהתקבל הוא null אם המערך שהתקבל הוא
        public static Student BestStudentAverageAtSubject(Student[] students, Subject subject)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            //שימו לב כי אינכם מבצעים העתקה של הפניות אלא יוצרים זיכרון בלתי תלוי עבור הערך החוזר

            if (students == null || subject == null)
                return null;
            Subject[] subjects;
            string subjectName = subject.GetSubjectName();
            double bestSubjectAvg = -1;
            int bestStudentIndex = -1;
            
            for (int i = 0; i < students.Length; i++)
            {
                subjects = students[i].GetSubjects();
                if (subjects != null)
                {
                    int j=0;
                    bool bCont = true;
                    while (j < subjects.Length && bCont) 
                    {
                        if (subjects[j].GetSubjectName() == subjectName)
                        {
                            bCont = false;
                        } else
                        {
                            j++;
                        }
                    }
                    if (j < subjects.Length)
                    {
                        if (bestSubjectAvg < subjects[j].GetAverage())
                        {
                            bestSubjectAvg = subjects[j].GetAverage();
                            bestStudentIndex = i;
                        }
                    }
                }
            }
            //Student newStudent = bestStudentIndex > 0 ? new Student(students[bestStudentIndex]) : null;
            if (bestStudentIndex < 0)
                return null; 
            return new Student(students[bestStudentIndex]);
        }

    }
}
