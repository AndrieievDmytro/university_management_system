namespace BlazorProjectServer.Models
{
    public class PartTime : Tutor
    {
        public int WorkingHours { get; set; }
        public long SalaryPerHour { get; set; }

        public override long CalculateSalary(){return 1000;}
        public override void UserCopy(IUser person)
        {
            base.UserCopy(person);
            var partTimeEmp = (PartTime)person;
            WorkingHours = partTimeEmp.WorkingHours;
            SalaryPerHour = partTimeEmp.SalaryPerHour;
        }

    }
}