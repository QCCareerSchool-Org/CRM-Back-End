using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("payment_methods", tb => tb.HasComment("history of payment methods used by enrollments"));

        entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

        entity.HasIndex(e => e.PaymentTypeId, "payment_type_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.CardeasexmlCardHash)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("cardeasexml_card_hash")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.CardeasexmlCardReference)
            .HasColumnName("cardeasexml_card_reference")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Deleted).HasColumnName("deleted");
        entity.Property(e => e.Disabled).HasColumnName("disabled");
        entity.Property(e => e.EnrollmentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.EselectPlusDataKey)
            .HasMaxLength(25)
            .IsFixedLength()
            .HasColumnName("eselect_plus_data_key")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.EselectPlusIssuerId)
            .HasMaxLength(36)
            .HasColumnName("eselect_plus_issuer_id");
        entity.Property(e => e.ExpiryMonth)
            .HasColumnType("tinyint(2) unsigned zerofill")
            .HasColumnName("expiry_month");
        entity.Property(e => e.ExpiryYear)
            .HasColumnType("smallint(4) unsigned")
            .HasColumnName("expiry_year");
        entity.Property(e => e.InitialTransactionId).HasColumnName("initial_transaction_id");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Notified)
            .IsRequired()
            .HasDefaultValueSql("'1'")
            .HasColumnName("notified");
        entity.Property(e => e.Pan)
            .HasMaxLength(20)
            .HasColumnName("pan")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.PaymentTypeId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("payment_type_id");
        entity.Property(e => e.PaysafeCardId)
            .HasColumnName("paysafe_card_id")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.PaysafeCompany)
            .HasColumnType("enum('CA','GB','US')")
            .HasColumnName("paysafe_company");
        entity.Property(e => e.PaysafePaymentToken)
            .HasColumnName("paysafe_payment_token")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.PaysafeProfileId)
            .HasColumnName("paysafe_profile_id")
            .UseCollation("ascii_bin")
            .HasCharSet("ascii");
        entity.Property(e => e.Primary).HasColumnName("primary");
        entity.Property(e => e.TransactionCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("transaction_count");

        entity.HasOne(d => d.Enrollment).WithMany(p => p.PaymentMethods)
            .HasForeignKey(d => d.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("payment_methods_ibfk_1");

        entity.HasOne(d => d.PaymentType).WithMany(p => p.PaymentMethods)
            .HasForeignKey(d => d.PaymentTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("payment_methods_ibfk_2");
    }
}
