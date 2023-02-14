using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class TutorEntConf : IEntityTypeConfiguration<Tutor>
    {
        public void Configure(EntityTypeBuilder<Tutor> builder)
        {
            builder.ToTable("Tutor");
            builder.Property(t => t.ScientificTitle);
            builder.Property(t => t.EmploymentDate).IsRequired();
            
        }
    }
}