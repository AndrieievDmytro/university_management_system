using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class ScheduleEntConf : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(s => s.ScheduleId);
            builder.Property(s => s.ScheduleId).ValueGeneratedOnAdd();
            builder.Property(s => s.Date).IsRequired();
            builder.Property(s => s.Room).IsRequired();
            // Many to many association Course and Subject
            builder.HasOne(s => s.Course)
                    .WithMany(s => s.Schedules)
                    .HasForeignKey(s => s.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Subject)
                    .WithMany(s => s.Schedules)
                    .HasForeignKey(s => s.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}