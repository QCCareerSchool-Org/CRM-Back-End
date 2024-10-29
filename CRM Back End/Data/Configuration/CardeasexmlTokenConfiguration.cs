using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;

public class CardeasexmlTokenConfiguration : IEntityTypeConfiguration<CardeasexmlToken>
{
    public void Configure(EntityTypeBuilder<CardeasexmlToken> entity)
    {
        entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

        entity
            .ToTable("cardeasexml_tokens")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalPaymentMethodId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_payment_method_id");
        entity.Property(e => e.CardHash)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("card_hash");
        entity.Property(e => e.CardReference).HasColumnName("card_reference");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");

        entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.CardeasexmlToken)
            .HasForeignKey<CardeasexmlToken>(d => d.GlobalPaymentMethodId)
            .HasConstraintName("cardeasexml_tokens_ibfk_1");
    }
}
