using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Information_System.Data.Database.Entities;

namespace Savarankiskas_darbas_Nr._3.Database.Configuration
{
    internal class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("Lecture");

            builder.HasKey(e => e.LectureId);  // nustatomas primary key

            builder.Property(e => e.LectureName)
                 .IsRequired()
                 .HasComment("Lecture Name must be at least 5 characters long.");

            builder.HasIndex(e => e.LectureName)
                .IsUnique();

            builder.Property(e => e.LectureTime)
                .IsRequired()
                .HasComment("Lecture Time must be between 08:00 and 20:00.");
        }
    }
}
