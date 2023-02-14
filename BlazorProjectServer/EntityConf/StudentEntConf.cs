using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class StudentEntConf : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.Property(s => s.IdStudent);
            builder.Property(s => s.CurrentSemester).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.Scholarship);

            
             
        }
    }
}