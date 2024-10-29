using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class PaysafeTokenConfiguration : IEntityTypeConfiguration<PaysafeToken>
{
    public void Configure(EntityTypeBuilder<PaysafeToken> entity)
    {
        entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

        entity
            .ToTable("paysafe_tokens")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalPaymentMethodId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_payment_method_id");
        entity.Property(e => e.CardId).HasColumnName("card_id");
        entity.Property(e => e.Company)
            .HasDefaultValueSql("'CA'")
            .HasColumnType("enum('CA','US','GB')")
            .HasColumnName("company");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.PaymentToken)
            .HasMaxLength(80)
            .HasColumnName("payment_token");
        entity.Property(e => e.ProfileId).HasColumnName("profile_id");

        entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.PaysafeToken)
            .HasForeignKey<PaysafeToken>(d => d.GlobalPaymentMethodId)
            .HasConstraintName("paysafe_tokens_ibfk_1");
    }
}
