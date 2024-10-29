using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
{
    public void Configure(EntityTypeBuilder<EmailMessage> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("email_messages")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.CourseId, "course_id");

        entity.HasIndex(e => new { e.CourseId, e.EmailMessageTypeId }, "course_id_2").IsUnique();

        entity.HasIndex(e => e.EmailMessageTypeId, "email_message_type_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Body).HasColumnName("body");
        entity.Property(e => e.CourseId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.EmailMessageTypeId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("email_message_type_id");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Sender)
            .HasMaxLength(255)
            .HasColumnName("sender");
        entity.Property(e => e.Subject)
            .HasMaxLength(40)
            .HasColumnName("subject");

        entity.HasOne(d => d.Course).WithMany(p => p.EmailMessages)
            .HasForeignKey(d => d.CourseId)
            .HasConstraintName("email_messages_ibfk_1");

        entity.HasOne(d => d.EmailMessageType).WithMany(p => p.EmailMessages)
            .HasForeignKey(d => d.EmailMessageTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("email_messages_ibfk_2");
    }
}
