using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    class Subject
    {
        private string subjectName;
        private int numTests;
        private double average;

        //בנאי עבור תלמיד חדש
        public Subject(string subjectName)
        {
            this.subjectName = subjectName;
            this.numTests = 0;
            this.average = 0;
        }

        //בנאי עבור מקצוע. ניתן להניח כי ערכי הפרמטרים תקינים - מספר מבחנים אי שלילי, ממוצע בין 0 ל 100
        public Subject(string subjectName, int numTests, double average) 
        {
            this.subjectName = subjectName;
            this.numTests = numTests;
            this.average = average;
        }

        //בנאי העתקה
        public Subject(Subject other)
        {
            this.subjectName = other.subjectName;   
            this.numTests = other.numTests;
            this.average = other.average;
        }

        //טענת יציאה: הפעולה מחזירה את שם המקצוע
        public string GetSubjectName()
        {
            return this.subjectName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>הפעולה מחזירה את כמות המבחנים שנעשו במקצוע</returns>
        public int GetNumTests()
        {
            return this.numTests;   
        }

        //טענת יציאה: אם נעשו מבחנים במקצוע הפעולה מחזירה את ממוצע המבחנים
        //-1 אם לא נעשו מבחנים במקצוע מחזירה הפעולה  
        public double GetAverage()
        {
            if (this.numTests == 0)
                return -1;
            return this.average;
        }

        //טענת כניסה: הפעולה מקבלת ציון של מבחן חדש במקצוע
        //false טענת יציאה: אם ציון המבחן אינו תקין מצב העצם אינו משתנה, ומוחזר 
        //true אם ציון המבחן תקין יעודכן הממוצע וכמות המבחנים במקצוע לאחר מבחן זה ויוחזר
        public bool AddTest(int grade)
        {
            if (grade < 0 || grade > 100)
                return false;
            this.average = (this.average * this.numTests + grade) / (this.numTests + 1);
            this.numTests++;
            return true;
        }
    }
}
