using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class CourseEntConf : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(c => c.CourseId);
            builder.Property(c => c.CourseId).ValueGeneratedOnAdd();
            builder.Property(c => c.CourseTag).IsRequired();
            builder.Property(c => c.CourseDescription).IsRequired();
            builder.Property(c => c.CourseProgram).IsRequired();

           
        }
    }
}