using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class EselectPlusResponseConfiguration : IEntityTypeConfiguration<EselectPlusResponse>
{
    public void Configure(EntityTypeBuilder<EselectPlusResponse> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("eselect_plus_responses")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalTransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.AuthCode)
            .HasMaxLength(8)
            .IsFixedLength()
            .HasColumnName("auth_code");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Message)
            .HasMaxLength(100)
            .HasColumnName("message");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.OrderId)
            .HasMaxLength(50)
            .HasColumnName("order_id");
        entity.Property(e => e.ReferenceNumber)
            .HasMaxLength(18)
            .IsFixedLength()
            .HasColumnName("reference_number");
        entity.Property(e => e.ResponseCode)
            .HasColumnType("tinyint(3)")
            .HasColumnName("response_code");
        entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
        entity.Property(e => e.TransactionNumber)
            .HasMaxLength(255)
            .HasColumnName("transaction_number");
        entity.Property(e => e.TransactionTime)
            .HasColumnType("time")
            .HasColumnName("transaction_time");

        entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.EselectPlusResponse)
            .HasForeignKey<EselectPlusResponse>(d => d.GlobalTransactionId)
            .HasConstraintName("eselect_plus_responses_ibfk_1");
    }
}
