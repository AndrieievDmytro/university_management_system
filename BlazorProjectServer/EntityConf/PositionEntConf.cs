using System.Collections.Generic;
using BlazorProjectServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace BlazorProjectServer.EntityConf
{
    public class PositionEntConf : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(nameof(Position));
            builder.HasKey(e => e.PositionId);
            builder.Property(e => e.PositionId).ValueGeneratedOnAdd();
            builder.Property(e => e.PositionTypes)
                .HasConversion(new ValueConverter<HashSet<PositionType>, string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<HashSet<PositionType>>(v)
                    ));

            builder.Property(e => e.InChairFrom);
            builder.Property(e => e.InChairTo);
            builder.HasIndex(e => e.HoursOfLecture);
            builder.Property(e => e.HoursOfTutorials);

            builder.HasOne(t => t.Tutor)
                    .WithOne(t => t.Position)
                    .HasForeignKey<Position>(t => t.TutorId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Courses)
                    .WithOne(a => a.Position)
                    .HasForeignKey(a => a.IdPosition)
                    .OnDelete(DeleteBehavior.Cascade);

            // Position lecturer = new Position
            // {
            //     TutorId = 1,
            //     PositionId = 1,
            //     PositionTypes = new HashSet<PositionType> { PositionType.Lecturer },
            //     HoursOfLecture = 10,
            // };

            // builder.HasData(lecturer);
        }
    }
}