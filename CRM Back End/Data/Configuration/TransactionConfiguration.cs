using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("transactions");

        entity.HasIndex(e => e.Auto, "auto");

        entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

        entity.HasIndex(e => e.ExtraCharge, "extra_charge");

        entity.HasIndex(e => e.ParentId, "parent_id");

        entity.HasIndex(e => e.PaymentMethodId, "payment_method_id");

        entity.HasIndex(e => e.Posted, "posted");

        entity.HasIndex(e => e.Reattempt, "reattempt");

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasColumnName("amount");
        entity.Property(e => e.AttemptedAmount)
            .HasPrecision(10, 2)
            .HasColumnName("attempted_amount");
        entity.Property(e => e.AuthorizationCode)
            .HasMaxLength(8)
            .IsFixedLength()
            .HasColumnName("authorization_code")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.Auto).HasColumnName("auto");
        entity.Property(e => e.Chargeback)
            .HasPrecision(10, 2)
            .HasColumnName("chargeback");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Description)
            .HasMaxLength(20)
            .HasColumnName("description")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.EnrollmentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.ExtraCharge).HasColumnName("extra_charge");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Notes)
            .HasColumnType("text")
            .HasColumnName("notes")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.Notified).HasColumnName("notified");
        entity.Property(e => e.OrderId)
            .HasMaxLength(99)
            .HasColumnName("order_id")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.ParentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("parent_id");
        entity.Property(e => e.PaymentMethodId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("payment_method_id");
        entity.Property(e => e.Posted).HasColumnName("posted");
        entity.Property(e => e.PostedDate)
            .HasColumnType("timestamp")
            .HasColumnName("posted_date");
        entity.Property(e => e.Reattempt).HasColumnName("reattempt");
        entity.Property(e => e.ReferenceNumber)
            .HasColumnName("reference_number")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.Refund)
            .HasPrecision(10, 2)
            .HasColumnName("refund");
        entity.Property(e => e.Response)
            .HasColumnType("text")
            .HasColumnName("response")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.ResponseCode)
            .HasColumnType("mediumint(4) unsigned")
            .HasColumnName("response_code");
        entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
        entity.Property(e => e.Severity)
            .HasColumnType("int(11)")
            .HasColumnName("severity");
        entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
        entity.Property(e => e.TransactionNumber)
            .HasMaxLength(20)
            .HasColumnName("transaction_number")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.TransactionTime)
            .HasColumnType("time")
            .HasColumnName("transaction_time");
        entity.Property(e => e.TransactionType)
            .HasDefaultValueSql("'charge'")
            .HasColumnType("enum('charge','refund','chargeback','nsf fee','void')")
            .HasColumnName("transaction_type")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.UsdAmount)
            .HasPrecision(10, 2)
            .HasColumnName("USD_amount");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");
        entity.Property(e => e.Voided).HasColumnName("voided");

        entity.HasOne(d => d.Enrollment).WithMany(p => p.Transactions)
            .HasForeignKey(d => d.EnrollmentId)
            .HasConstraintName("transactions_ibfk_1");

        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
            .HasForeignKey(d => d.ParentId)
            .HasConstraintName("transactions_ibfk_4");

        entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Transactions)
            .HasForeignKey(d => d.PaymentMethodId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("transactions_ibfk_2");

        entity.HasOne(d => d.User).WithMany(p => p.Transactions)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("transactions_ibfk_3");
    }
}
