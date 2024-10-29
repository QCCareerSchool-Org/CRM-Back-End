using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class PaysafeResponseConfiguration : IEntityTypeConfiguration<PaysafeResponse>
{
    public void Configure(EntityTypeBuilder<PaysafeResponse> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("paysafe_responses")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalTransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.AuthCode)
            .HasMaxLength(50)
            .HasColumnName("auth_code");
        entity.Property(e => e.AuthorizationId).HasColumnName("authorization_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.MerchantRefNum)
            .HasMaxLength(255)
            .HasColumnName("merchant_ref_num");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Status)
            .HasMaxLength(50)
            .HasColumnName("status");
        entity.Property(e => e.TxnTime)
            .HasColumnType("datetime")
            .HasColumnName("txn_time");

        entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.PaysafeResponse)
            .HasForeignKey<PaysafeResponse>(d => d.GlobalTransactionId)
            .HasConstraintName("paysafe_responses_ibfk_1");
    }
}
