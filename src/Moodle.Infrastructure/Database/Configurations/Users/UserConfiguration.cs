using Moodle.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Users
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("users");

            // Key
            builder.HasKey(u => u.Id);

            // Properties
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(u => u.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(User.NameMaxLength)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(User.NameMaxLength)
                .IsRequired();

            builder.Property(u => u.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("timestamp without time zone");

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(User.EmailMaxLength)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasMaxLength(User.PasswordMaxLength)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasColumnName("role")
                .HasConversion<string>()
                .IsRequired();

            // Indexes & Constraints
            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
