namespace BlazorProjectServer.Models
{
    public class FullTime : Tutor
    {
        public int SalaryCoefficient { get; set; }

        public override long CalculateSalary(){return 100*SalaryCoefficient;}
        public override void UserCopy(IUser person)
        {
            base.UserCopy(person);
            var fullTimeEmp = (FullTime)person;
            SalaryCoefficient = fullTimeEmp.SalaryCoefficient;
        }
    }
}