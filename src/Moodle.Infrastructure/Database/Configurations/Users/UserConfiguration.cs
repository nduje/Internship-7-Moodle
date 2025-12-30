using Moodle.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Users
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(User.NameMaxLength)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(User.NameMaxLength)
                .IsRequired();

            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(User.EmailMaxLength)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .HasMaxLength(User.PasswordMaxLength)
                .IsRequired();

            builder.Property(x => x.Role)
                .HasColumnName("role")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
