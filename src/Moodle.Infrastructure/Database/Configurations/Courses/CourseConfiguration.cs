using Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Courses
{
    internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table
            builder.ToTable("courses");

            // Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(Course.NameMaxLength)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasMaxLength(Course.DescriptionMaxLength);

            builder.Property(c => c.ProfessorId)
                .HasColumnName("professor_id");

            // Indexes & Constraints
            builder.HasIndex(c => c.ProfessorId);

            // Relationships
            builder.HasOne(c => c.Professor)
                .WithMany()
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
