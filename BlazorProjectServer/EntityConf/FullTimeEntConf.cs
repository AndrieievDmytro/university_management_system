using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class FullTimeEntConf : IEntityTypeConfiguration<FullTime>
    {
        public void Configure(EntityTypeBuilder<FullTime> builder)
        {
            builder.ToTable("FullTimeEmp");
            builder.Property(f => f.SalaryCoefficient).IsRequired();
        }
    }
}