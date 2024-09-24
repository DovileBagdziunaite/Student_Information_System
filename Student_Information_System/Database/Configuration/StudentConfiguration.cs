using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Information_System.Data.Database.Entities;

namespace Savarankiskas_darbas_Nr._3.Database.Configuration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(e => e.StudentId);  // nustatomas primary key

            builder.Property(e => e.FirstName)
                 .HasMaxLength(50)
                 .IsRequired()
                 .HasComment("First Name must contain only letters.");

            builder.Property(e => e.LastName)
                 .HasMaxLength(50)
                 .IsRequired()
                 .HasComment("Last Name must contain only letters.");

            builder.Property(e => e.StudentNumber)
                .HasMaxLength(8)        
                .IsFixedLength()        
                .IsRequired();

            builder.HasIndex(e => e.StudentNumber)
                .IsUnique();

            builder.Property(e => e.StudentEmail)
                .HasMaxLength(100)   
                .IsRequired()
                .HasComment("Student Email must be in a valid email format.");

        }
    }
}
