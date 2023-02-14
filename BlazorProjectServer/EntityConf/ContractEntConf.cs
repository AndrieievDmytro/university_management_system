using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class ContractEntConf : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("ContractEmp");
            builder.Property(c => c.ContractStartDate).IsRequired();
            builder.Property(c => c.ContractEndDate).IsRequired();
            builder.Property(c => c.SalaryInContract).IsRequired();
        }
    }
}