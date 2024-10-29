using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalTransactionBreakdownConfiguration : IEntityTypeConfiguration<GlobalTransactionBreakdown>
{
    public void Configure(EntityTypeBuilder<GlobalTransactionBreakdown> entity)
    {
        entity.HasKey(e => e.GlobalTransactionBreakdownId).HasName("PRIMARY");

        entity
            .ToTable("global_transaction_breakdowns")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

        entity.HasIndex(e => e.GlobalTransactionId, "global_transaction_id");

        entity.Property(e => e.GlobalTransactionBreakdownId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_breakdown_id");
        entity.Property(e => e.Amount)
            .HasPrecision(9, 2)
            .HasColumnName("amount");
        entity.Property(e => e.AttemptedAmount)
            .HasPrecision(9, 2)
            .HasColumnName("attempted_amount");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.EnrollmentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.GlobalTransactionId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.UsdAmount)
            .HasPrecision(9, 2)
            .HasColumnName("USD_amount");

        entity.HasOne(d => d.Enrollment).WithMany(p => p.GlobalTransactionBreakdowns)
            .HasForeignKey(d => d.EnrollmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("global_transaction_breakdowns_ibfk_2");

        entity.HasOne(d => d.GlobalTransaction).WithMany(p => p.GlobalTransactionBreakdowns)
            .HasForeignKey(d => d.GlobalTransactionId)
            .HasConstraintName("global_transaction_breakdowns_ibfk_1");
    }
}
