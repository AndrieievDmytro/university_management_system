using System;
using System.Collections.Generic;

namespace BlazorProjectServer.Models
{
    public class Tutor : User
    {
        public int TutoId { get; set; }
        public string ScientificTitle { get; set; }
        public static long MinSalary = 1000;
        public DateTime EmploymentDate { get; set; }

        public Position Position { get; set; }

        public override void UserCopy(IUser person)
        {
            base.UserCopy(person);
            var tutor = (Tutor)person;
            ScientificTitle = tutor.ScientificTitle;
            EmploymentDate = tutor.EmploymentDate;
            Position = tutor.Position;
        }

        public void SendTask() { }
        public void UploadProgram() { }
        public virtual long CalculateSalary() { return 10; }
    }
}