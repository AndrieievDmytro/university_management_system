using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class PartTimeEntConf : IEntityTypeConfiguration<PartTime>
    {
        public void Configure(EntityTypeBuilder<PartTime> builder)
        {
            builder.ToTable("PartTimeEmp");
            builder.Property(p => p.WorkingHours).IsRequired();
            builder.Property(p => p.SalaryPerHour).IsRequired();
        }
    }
}