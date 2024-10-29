using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class EmailMessageTypeConfiguration : IEntityTypeConfiguration<EmailMessageType>
{
    public void Configure(EntityTypeBuilder<EmailMessageType> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("email_message_types")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
    }
}
