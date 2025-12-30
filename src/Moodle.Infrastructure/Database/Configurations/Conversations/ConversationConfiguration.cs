using Moodle.Domain.Entities.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Conversations
{
    internal sealed class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            // Table
            builder.ToTable("conversations");

            // Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(c => c.User1Id)
                .HasColumnName("user1_id")
                .IsRequired();

            builder.Property(c => c.User2Id)
                .HasColumnName("user2_id")
                .IsRequired();

            // Indexes & Constraints
            builder.HasIndex(c => new { c.User1Id, c.User2Id })
                .IsUnique();

            builder.HasIndex(c => c.User1Id);

            builder.HasIndex(c => c.User2Id);

            // Relationships
            builder.HasOne(c => c.User1)
                .WithMany()
                .HasForeignKey(c => c.User1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.User2)
                .WithMany()
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
