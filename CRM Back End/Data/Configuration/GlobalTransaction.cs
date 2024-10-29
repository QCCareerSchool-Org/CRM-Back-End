using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalTransactionConfiguration : IEntityTypeConfiguration<GlobalTransaction>
{
    public void Configure(EntityTypeBuilder<GlobalTransaction> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("global_transactions")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.GlobalPaymentMethodId, "global_payment_method_id");

        entity.Property(e => e.GlobalTransactionId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.Amount)
            .HasPrecision(9, 2)
            .HasColumnName("amount");
        entity.Property(e => e.AttemptedAmount)
            .HasPrecision(9, 2)
            .HasColumnName("attempted_amount");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Description)
            .HasColumnType("text")
            .HasColumnName("description");
        entity.Property(e => e.ExtraCharge).HasColumnName("extra_charge");
        entity.Property(e => e.GlobalPaymentMethodId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_payment_method_id");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Origin)
            .HasDefaultValueSql("'auto'")
            .HasColumnType("enum('auto','manual','imported','student initiated')")
            .HasColumnName("origin");
        entity.Property(e => e.ParentGlobalTransactionId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("parent_global_transaction_id");
        entity.Property(e => e.RefundedAmount)
            .HasColumnType("decimal(9,2) unsigned")
            .HasColumnName("refunded_amount");
        entity.Property(e => e.Severity)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("severity");
        entity.Property(e => e.Success).HasColumnName("success");
        entity.Property(e => e.TransactionDate)
            .HasComment("the date this payment is registered for")
            .HasColumnName("transaction_date");
        entity.Property(e => e.Type)
            .HasDefaultValueSql("'charge'")
            .HasColumnType("enum('charge','refund','chargeback','nsf fee','void')")
            .HasColumnName("type");
        entity.Property(e => e.UsdAmount)
            .HasPrecision(9, 2)
            .HasColumnName("USD_amount");
        entity.Property(e => e.UsdRefundedAmount)
            .HasColumnType("decimal(9,2) unsigned")
            .HasColumnName("USD_refunded_amount");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");
        entity.Property(e => e.Voided).HasColumnName("voided");

        entity.HasOne(d => d.GlobalPaymentMethod).WithMany(p => p.GlobalTransactions)
            .HasForeignKey(d => d.GlobalPaymentMethodId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("global_transactions_ibfk_1");
    }
}
