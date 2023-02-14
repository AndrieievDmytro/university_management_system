using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class SubjectEntConf : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(s => s.SubjectId);
            builder.Property(s => s.SubjectId).ValueGeneratedOnAdd();
            builder.Property(s => s.Name);
            builder.Property(s => s.Topics);
            builder.Property(s => s.Type);
            
        }
    }
}