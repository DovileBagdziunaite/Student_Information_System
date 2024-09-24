using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Information_System.Data.Database.Entities;

namespace Savarankiskas_darbas_Nr._3.Database.Configuration
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(e => e.DepartmentId);  // nustatomas primary key

            builder.Property(e => e.DepartmentName)
                .HasMaxLength(100)      
                .IsRequired()
                .HasComment("Department Name must contain only letters and numbers.");

            builder.Property(e => e.DepartmentCode)
                .HasMaxLength(6)        
                .IsFixedLength()        
                .IsRequired();         

            builder.HasIndex(e => e.DepartmentCode)
                .IsUnique();
        }
    }
}
