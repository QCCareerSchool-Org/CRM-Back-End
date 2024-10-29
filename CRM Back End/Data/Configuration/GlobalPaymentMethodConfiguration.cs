using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalPaymentMethodConfiguration : IEntityTypeConfiguration<GlobalPaymentMethod>
{
    public void Configure(EntityTypeBuilder<GlobalPaymentMethod> entity)
    {
        entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

        entity
            .ToTable("global_payment_methods")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.StudentId, "student_id");

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.GlobalPaymentMethodId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_payment_method_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Deleted).HasColumnName("deleted");
        entity.Property(e => e.ExpiryMonth)
            .HasColumnType("tinyint(2) unsigned zerofill")
            .HasColumnName("expiry_month");
        entity.Property(e => e.ExpiryYear)
            .HasColumnType("smallint(4) unsigned")
            .HasColumnName("expiry_year");
        entity.Property(e => e.GlobalPaymentTypeId)
            .HasMaxLength(25)
            .HasDefaultValueSql("'Paysafe'")
            .HasColumnName("global_payment_type_id");
        entity.Property(e => e.GlobalTransactionCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_count");
        entity.Property(e => e.MaskedPan)
            .HasMaxLength(20)
            .HasColumnName("masked_pan");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Primary).HasColumnName("primary");
        entity.Property(e => e.StudentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Student).WithMany(p => p.GlobalPaymentMethods)
            .HasForeignKey(d => d.StudentId)
            .HasConstraintName("global_payment_methods_ibfk_1");

        entity.HasOne(d => d.User).WithMany(p => p.GlobalPaymentMethods)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("global_payment_methods_ibfk_2");
    }
}
