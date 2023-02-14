using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class AttendanseEntConf : IEntityTypeConfiguration<Attendanse>
    {
        public void Configure(EntityTypeBuilder<Attendanse> builder)
        {
            builder.HasKey(a => a.AttendanseId);
            builder.Property(a => a.AttendanseId).ValueGeneratedOnAdd();
            builder.ToTable("Attendanse");
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.EndDate);
            builder.Property(a => a.IsPassed);

            // Many to many association Student and Course

            builder.HasOne(at => at.Student)
                    .WithMany(st => st.Attendanses)
                    .HasForeignKey(st => st.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(at => at.Course)
                    .WithMany(st => st.Attendanses)
                    .HasForeignKey(st => st.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}