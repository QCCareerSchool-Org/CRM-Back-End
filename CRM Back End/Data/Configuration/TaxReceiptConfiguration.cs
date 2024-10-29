using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class TaxReceiptConfiguration : IEntityTypeConfiguration<TaxReceipt>
{
    public void Configure(EntityTypeBuilder<TaxReceipt> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("tax_receipts")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.EnrollmentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.Type)
            .HasMaxLength(25)
            .HasColumnName("type");

        entity.HasOne(d => d.Enrollment).WithMany(p => p.TaxReceipts)
            .HasForeignKey(d => d.EnrollmentId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tax_receipts_ibfk_1");
    }
}
