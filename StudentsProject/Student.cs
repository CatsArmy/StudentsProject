using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    class Student
    {
        private string fullName;
        private int height; //גובה בסנטימטרים
        private Subject[] subjects;

        //בנאי עבור סטודנט ללא מקצועות
        public Student(string fullName, int age, int height)
        {
            this.fullName = fullName;
            this.height = height;
        }

        //בנאי עבור סטודנט שיתכן ויש לו מקצועות
        public Student(string fullName, int height, Subject[] subjects)
        {
            this.fullName = fullName;
            this.height = height;
            if (subjects == null)
                this.subjects = null;
            else
            {
                this.subjects = new Subject[subjects.Length];
                for (int i = 0; i < subjects.Length; i++)
                {
                     this.subjects[i] = new Subject(subjects[i]);
                }
            }
        }

        //בנאי העתקה
        public Student(Student other)
        {
            this.fullName = other.fullName;
            this.height = other.height;
            if (other.subjects == null)
                this.subjects = null;
            else
            {
                this.subjects = new Subject[other.subjects.Length];
                for (int i = 0; i < other.subjects.Length; i++)
                {
                     this.subjects[i] = new Subject(other.subjects[i]);
                }
            }
        }

        //טענת כניסה: הפעולה מקבלת שם של מקצוע
        /// <summary>
        /// -1 אם לא קיים לתלמיד מקצוע עם השם שהתקבל מוחזר
        /// 
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns>
        /// הפעולה מחזירה את האינדקס של המקצוע אם התלמיד לומד מקצוע עם השם שהתקבל
        /// </returns>
        private int GetSubjectIndex(string subjectName)
        {
            if(this.subjects == null)
                return -1;
            for (int i = 0; i < this.subjects.Length; i++)
            {
                if (this.subjects[i].GetSubjectName() == subjectName)
                    return i;
            }
            return -1;
        }

        //טענת יציאה: הפעולה מחזירה את שם התלמיד
        public string GetFullName()
        {
            return this.fullName;
        }

        //טענת יציאה: הפעולה מחזירה את גובה התלמיד בסנטימטרים
        public int GetHeight()
        {
            return this.height;
        }

        //טענת יציאה: הפעולה מחזירה העתק של מערך מקצועות התלמיד
        public Subject[] GetSubjects()
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            //שימו לב כי אינכם מבצעים העתקה של הפניות אלא יוצרים זיכרון בלתי תלוי עבור הערך החוזר
            if (subjects == null)
                return null;
            Subject[] newSubjects = new Subject[subjects.Length];
            for (int i = 0; i < newSubjects.Length; i++)
            {
                newSubjects[i] = new Subject(subjects[i]);
            }
            return newSubjects;
        }

        //טענת כניסה: הפעולה מקבלת מקצוע להוספה עבור התלמיד
        //true טענת יציאה: הפעולה מוסיפה לתלמיד את המקצוע שמתקבל אם לא קיים מקצוע עם אותו שם, ומחזירה
        //false אם התקבל מקצוע עם שם שכבר קיים המקצוע לא יוסף ויוחזר
        public bool AddSubject(Subject toAdd)
        {
            string subjectName;
            int arrLength = 1;
            if(this.subjects != null)
            {
                subjectName = toAdd.GetSubjectName();
                for(int i = 0; i < this.subjects.Length; i++)
                {
                    if (this.GetSubjectIndex(subjectName) != -1)
                        return false;
                }
                arrLength = this.subjects.Length + 1;
            }

            Subject[] newArr = new Subject[arrLength];
            if (this.subjects != null)
            {
                for (int i = 0; i < this.subjects.Length; i++)
                {
                    newArr[i] = new Subject(this.subjects[i]);
                }
            }
                
            newArr[arrLength - 1] = new Subject(toAdd);
            this.subjects = newArr;
            return true;
        }

        
        
        //טענת כניסה: הפעולה מקבלת שם של מקצוע וציון מבחן
        //טענת יציאה: אם קיים לתלמיד מקצוע עם שם זה, והמבחן תקין,
        //true יחושב הציון הממוצע החדש של התלמיד במקצוע זה ,כמות המבחנים במקצוע תגדל, ויוחזר
        //false אם לתלמיד אין מקצוע עם השם שהתקבל או אם הצין אינו בטווח 0-100, לא ישתנו נתוני המקצוע ויוחזר

        public bool AddTestToSubject(string subjectName, int grade)
        {
            //ToDo : השלימו את גוף הפעולה בהתאם לטענת היציאה הנתונה
            //Subject בצעו זימון לפעולות הנדרשות במחלקה
            int subjectIndex = GetSubjectIndex(subjectName);

            if (subjectIndex == -1 || grade < 0 || grade > 100)
                return false;
            subjects[GetSubjectIndex(subjectName)].AddTest(grade);
            return true;
        }



        //טענת כניסה: הפעולה מקבלת שם של מקצוע
        /// <summary>
        /// אם קיים לתלמיד מקצוע עם השם שהתקבל, הפעולה מחזירה את הממוצע של אותו מקצוע
        /// אם לתלמיד קיים מקצוע עם השם שהתקבל, ונעשו בו מבחנים הפעולה מחזירה את הציון הממוצע של התלמיד במקצוע
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns> -1 אם לתלמיד קיים מקצוע עם השם שהתקבל, אך לא נעשו בו מבחנים הפעולה מחזירה</returns>
        public double GetAverageAtSubject(string subjectName)
        {
            int subjectIndex = this.GetSubjectIndex(subjectName);
            if (subjectIndex == -1)
                return -1;
            return this.subjects[subjectIndex].GetAverage();
        }
    }
}
