using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class ThesisEntConf : IEntityTypeConfiguration<Thesis>
    {
        public void Configure(EntityTypeBuilder<Thesis> builder)
        {
            builder.HasKey(t => t.ThesisId);
            builder.Property(t => t.ThesisId).ValueGeneratedOnAdd();
            builder.Property(t => t.Title).IsRequired();

            builder.HasOne(t => t.Student)
                    .WithOne(st => st.Thesis)
                    .HasForeignKey<Thesis>(u => u.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}