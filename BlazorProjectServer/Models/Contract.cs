using System;

namespace BlazorProjectServer.Models
{
    public class Contract : Tutor
    {
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public long SalaryInContract { get; set; }

        public override long CalculateSalary(){return 1000;}
        public override void UserCopy(IUser person)
        {
            base.UserCopy(person);
            var contractEmp = (Contract)person;
            ContractStartDate = contractEmp.ContractStartDate;
            ContractEndDate = contractEmp.ContractEndDate;
            SalaryInContract = contractEmp.SalaryInContract;
        }
    }
}