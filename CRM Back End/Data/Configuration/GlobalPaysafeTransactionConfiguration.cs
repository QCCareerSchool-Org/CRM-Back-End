using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalPaysafeTransactionConfiguration : IEntityTypeConfiguration<GlobalPaysafeTransaction>
{
    public void Configure(EntityTypeBuilder<GlobalPaysafeTransaction> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("global_paysafe_transactions")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalTransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.AuthorizationId).HasColumnName("authorization_id");

        entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.GlobalPaysafeTransaction)
            .HasForeignKey<GlobalPaysafeTransaction>(d => d.GlobalTransactionId)
            .HasConstraintName("global_paysafe_transactions_ibfk_1");
    }
}
