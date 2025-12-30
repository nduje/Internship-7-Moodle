using Moodle.Domain.Entities.Enrollments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Enrollments
{
    internal sealed class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // Table
            builder.ToTable("enrollments");

            // Key
            builder.HasKey(e => e.Id);

            // Properties
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.StudentId)
                .HasColumnName("student_id")
                .IsRequired();

            builder.Property(e => e.CourseId)
                .HasColumnName("course_id")
                .IsRequired();

            builder.Property(e => e.EnrolledAt)
                .HasColumnName("enrolled_at");

            // Indexes & Constraints
            builder.HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            builder.HasIndex(e => e.StudentId);

            builder.HasIndex(e => e.CourseId);

            // Relationships
            builder.HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
