using System;
using System.Collections.Generic;

namespace BlazorProjectServer.Models
{

    public enum StudentStatus
    {
        Enrolee,
        StationaryMode,
        OnlineMode,
        DistanceMode,
        OnAcademicLeave,
        Graduated,
        KickedOut
    }

    public class Student : User
    {
        public int StudentId { get; set; }
        public string IdStudent { get; set; }
        public int CurrentSemester { get; set; }
        public StudentStatus Status { get; set; }
        public long? Scholarship { get; set; }
        public ICollection<Attendanse> Attendanses { get; set; }
        

        public Thesis Thesis { get; set; }

        public int ThesisId { get; set; }

        public void ApplyForScholarship()
        {

        }

        public void SendTask(string solution)
        {

        }

        public void SendThesis(string thesis)
        {

        }

        public void UpdateStudentStatus(StudentStatus status)
        {

        }

        public override void UserCopy(IUser person)
        {
            base.UserCopy(person);
            var student = (Student)person;
            IdStudent = student.IdStudent;
            CurrentSemester = student.CurrentSemester;
            Status = student.Status;
            Scholarship = student.Scholarship;
        }
    }
}
