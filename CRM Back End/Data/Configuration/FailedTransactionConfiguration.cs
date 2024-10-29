using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class FailedTransactionConfiguration : IEntityTypeConfiguration<FailedTransaction>
{
    public void Configure(EntityTypeBuilder<FailedTransaction> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("failed_transactions")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.AccountId, "account_id");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.AccountId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("account_id");
    }
}
