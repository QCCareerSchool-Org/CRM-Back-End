using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("enrollments");

        entity.HasIndex(e => e.CourseId, "course_id");

        entity.HasIndex(e => e.CurrencyId, "currency_id");

        entity.HasIndex(e => e.EnrollmentDate, "enrollment_date");

        entity.HasIndex(e => e.StudentId, "student_id");

        entity.HasIndex(e => new { e.StudentId, e.CourseId }, "student_id_2").IsUnique();

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.AccountId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("account_id");
        entity.Property(e => e.Cost)
            .HasPrecision(10, 2)
            .HasColumnName("cost");
        entity.Property(e => e.CourseId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.CurrencyId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("currency_id");
        entity.Property(e => e.Diploma).HasColumnName("diploma");
        entity.Property(e => e.DiplomaDate)
            .HasColumnType("timestamp")
            .HasColumnName("diploma_date");
        entity.Property(e => e.Discount)
            .HasPrecision(10, 2)
            .HasColumnName("discount");
        entity.Property(e => e.EnrollmentDate)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("enrollment_date");
        entity.Property(e => e.ExpiryDate)
            .HasColumnType("timestamp")
            .HasColumnName("expiry_date");
        entity.Property(e => e.FastTrack)
            .HasDefaultValueSql("'0'")
            .HasColumnName("fast_track");
        entity.Property(e => e.GradEmailDate)
            .HasColumnType("timestamp")
            .HasColumnName("grad_email_date");
        entity.Property(e => e.GradEmailSkip).HasColumnName("grad_email_skip");
        entity.Property(e => e.HideFromShippingList).HasColumnName("hide_from_shipping_list");
        entity.Property(e => e.Installment)
            .HasPrecision(10, 2)
            .HasColumnName("installment");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.NoShipping).HasColumnName("no_shipping");
        entity.Property(e => e.NoStudentCenter).HasColumnName("no_student_center");
        entity.Property(e => e.PaymentDay)
            .HasColumnType("tinyint(3) unsigned")
            .HasColumnName("payment_day");
        entity.Property(e => e.PaymentFrequency)
            .HasDefaultValueSql("'monthly'")
            .HasColumnType("enum('monthly','bi-weekly','weekly')")
            .HasColumnName("payment_frequency");
        entity.Property(e => e.PaymentOverride).HasColumnName("payment_override");
        entity.Property(e => e.PaymentPlan)
            .HasColumnType("enum('full','accelerated','extended')")
            .HasColumnName("payment_plan");
        entity.Property(e => e.PaymentStart)
            .HasColumnType("timestamp")
            .HasColumnName("payment_start");
        entity.Property(e => e.PreparedDate)
            .HasColumnType("timestamp")
            .HasColumnName("prepared_date");
        entity.Property(e => e.ShippedDate)
            .HasColumnType("timestamp")
            .HasColumnName("shipped_date");
        entity.Property(e => e.ShippingNote)
            .HasColumnType("text")
            .HasColumnName("shipping_note")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.Status)
            .HasColumnType("enum('W','H','T','G','R')")
            .HasColumnName("status");
        entity.Property(e => e.StatusDate)
            .HasColumnType("timestamp")
            .HasColumnName("status_date");
        entity.Property(e => e.StudentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("enrollments_ibfk_2");

        entity.HasOne(d => d.Currency).WithMany(p => p.Enrollments)
            .HasForeignKey(d => d.CurrencyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("enrollments_ibfk_3");

        entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
            .HasForeignKey(d => d.StudentId)
            .HasConstraintName("enrollments_ibfk_1");

        entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("enrollments_ibfk_4");
    }
}
