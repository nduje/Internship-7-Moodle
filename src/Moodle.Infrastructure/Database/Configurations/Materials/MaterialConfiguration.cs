using Moodle.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Materials
{
    internal sealed class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            // Table
            builder.ToTable("materials");

            // Key
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .HasMaxLength(Material.NameMaxLength)
                .IsRequired();

            builder.Property(m => m.Url)
                .HasColumnName("url")
                .HasMaxLength(Material.UrlMaxLength)
                .IsRequired();

            builder.Property(m => m.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(m => m.CourseId)
                .HasColumnName("course_id")
                .IsRequired();

            // Indexes & Constraints
            builder.HasIndex(m => m.CourseId);

            builder.HasIndex(m => new { m.Name, m.CourseId })
                .IsUnique();

            // Relationships
            builder.HasOne(m => m.Course)
                .WithMany()
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
