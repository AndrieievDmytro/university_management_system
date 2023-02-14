using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorProjectServer.EntityConf
{
    public class UserEntConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId).ValueGeneratedOnAdd();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.DateOfBirth).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            // builder.HasDiscriminator<string>("UserType")
            //     .HasValue<Student>("Student")
            //     .HasValue<Tutor>("Tutor").IsComplete(true);
        }
    }
}