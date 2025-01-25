using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvExamples
{
    internal class Student : Person
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PersonalNumber { get; set; }
        public bool HasGraduated { 
            get 
            {
                if (EndDate == null) return false;
                else return true;
            } 
        }
        public Teacher PrimaryTeacher { get; set; }
        public List<StudentSubject> Grades { get; private set; } = [];
        public void Study()
        {
            Console.WriteLine("I am studying");
        }
        public double? GetAverageGrade()
        {
            try
            {
                if (Grades.Count == 0){
                    return null;
                }
                double sum = 0;
                int counter = 0;
                foreach (StudentSubject subject in Grades)
                { 
                    if (subject.Grade > 4)
                    {
                        sum += subject.Grade;
                        counter++;
                    }
                }
                if (counter == 0){
                    return null;
                }
                double average = sum / counter;
                return average;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<StudentSubject>? GetPassingSubjects()
        {
            var passingGrades = new List<StudentSubject>();
            foreach(StudentSubject studentSubject in Grades)
            {
                if (studentSubject.Grade > 4)
                {
                    passingGrades.Add(studentSubject);
                }
            }
            return passingGrades;
        }
        public StudentSubject? GetStudentSubject(string subject)
        {
            foreach(StudentSubject studentSubject in Grades)
            {
                if (studentSubject.Name == subject)
                {
                    return studentSubject;
                }
            }
            return null;
        }
        public void AddGrade(StudentSubject subject)
        {
            if (subject == null || subject.Grade < 4 || subject.Grade > 10)
            {
                throw new Exception("Invalid grade");
            }
            if (subject.Name == null)
            {
                throw new Exception("Invalid name");
            }
            if (subject.Credits <= 0) {
                throw new Exception("Invalid credits");
            }
            var found = false;
            foreach (var studentSubject in Grades)
            {
                if (studentSubject.Name == subject.Name)
                {
                    found = true;
                    Console.WriteLine($"{studentSubject.Name} is already in list");
                    break;
                }
            }
            if (!found)
            {
                Grades.Add(subject);
                Console.WriteLine($"{FullName} - {subject.Name} ({subject.Grade})");
            }
        }
    }
}
