using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class EselectPlusTokenConfiguration : IEntityTypeConfiguration<EselectPlusToken>
{
    public void Configure(EntityTypeBuilder<EselectPlusToken> entity)
    {
        entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

        entity
            .ToTable("eselect_plus_tokens")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.DataKey, "data_key").IsUnique();

        entity.Property(e => e.GlobalPaymentMethodId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_payment_method_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.DataKey)
            .HasMaxLength(25)
            .IsFixedLength()
            .HasColumnName("data_key")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");

        entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.EselectPlusToken)
            .HasForeignKey<EselectPlusToken>(d => d.GlobalPaymentMethodId)
            .HasConstraintName("eselect_plus_tokens_ibfk_1");
    }
}
