using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class AssignmentsEntConf : IEntityTypeConfiguration<Assignments>
    {
        public void Configure(EntityTypeBuilder<Assignments> builder)
        {
            builder.ToTable("Assignment");
            builder.HasKey( a => a.AssignmentId);
            builder.Property(a => a.AssignmentId).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.StartDate).IsRequired();
            builder.Property(a => a.EndDate).IsRequired();
            builder.Property(a => a.MaxPoints).IsRequired();
            builder.Property(a => a.Points).IsRequired();

            // One to many association Subject and Asignments

            builder.HasOne(a => a.Subject)
                    .WithMany(s => s.Assignments)
                    .HasForeignKey(s => s.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}