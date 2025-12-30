using Moodle.Domain.Entities.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Announcements
{
    internal sealed class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            // Table
            builder.ToTable("announcements");

            // Key
            builder.HasKey(a => a.Id);

            // Properties
            builder.Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(a => a.Title)
                .HasColumnName("title")
                .HasMaxLength(Announcement.TitleMaxLength)
                .IsRequired();

            builder.Property(a => a.Content)
                .HasColumnName("content")
                .HasMaxLength(Announcement.ContentMaxLength)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(a => a.CourseId)
                .HasColumnName("course_id")
                .IsRequired();

            // Indexes & Constraints
            builder.HasIndex(a => a.CourseId);

            // Relationships
            builder.HasOne(a => a.Course)
                .WithMany()
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
