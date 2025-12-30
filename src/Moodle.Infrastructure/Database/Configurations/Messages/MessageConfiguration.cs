using Moodle.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moodle.Infrastructure.Database.Configurations.Messages
{
    internal sealed class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            // Table
            builder.ToTable("messages");

            // Key
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(m => m.Text)
                .HasColumnName("text")
                .HasMaxLength(Message.TextMaxLength)
                .IsRequired();

            builder.Property(m => m.Timestamp)
                .HasColumnName("timestamp");

            builder.Property(m => m.ConversationId)
                .HasColumnName("conversation_id")
                .IsRequired();

            builder.Property(m => m.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            // Indexes & Constraints
            builder.HasIndex(m => m.ConversationId);

            // Relationships
            builder.HasOne(m => m.Conversation)
                .WithMany()
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
