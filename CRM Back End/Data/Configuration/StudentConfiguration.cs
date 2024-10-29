using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("students");

        entity.HasIndex(e => e.CountryId, "country_id");

        entity.HasIndex(e => e.LanguageId, "language_id");

        entity.HasIndex(e => e.ProvinceId, "province_id");

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Address1)
            .HasMaxLength(40)
            .HasColumnName("address1");
        entity.Property(e => e.Address2)
            .HasMaxLength(40)
            .HasColumnName("address2");
        entity.Property(e => e.City)
            .HasMaxLength(31)
            .HasColumnName("city");
        entity.Property(e => e.CountryId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("country_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.CurrencyId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("currency_id");
        entity.Property(e => e.E164)
            .HasMaxLength(104)
            .HasComputedColumnSql("concat('+',`telephone_country_code`,replace(trim(leading '0' from `telephone_number`),'-',''))", false);
        entity.Property(e => e.EmailAddress)
            .HasMaxLength(100)
            .HasColumnName("email_address");
        entity.Property(e => e.EnrollmentCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_count");
        entity.Property(e => e.FirstName)
            .HasMaxLength(40)
            .HasColumnName("first_name");
        entity.Property(e => e.LanguageId)
            .HasDefaultValueSql("'41'")
            .HasColumnType("int(10) unsigned")
            .HasColumnName("language_id");
        entity.Property(e => e.LastName)
            .HasMaxLength(40)
            .HasColumnName("last_name");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Password)
            .HasMaxLength(255)
            .HasComment("hashed password for API access")
            .HasColumnName("password")
            .UseCollation("latin1_bin")
            .HasCharSet("latin1");
        entity.Property(e => e.PaymentDay)
            .HasColumnType("tinyint(3) unsigned")
            .HasColumnName("payment_day");
        entity.Property(e => e.PaymentStart)
            .HasColumnType("timestamp")
            .HasColumnName("payment_start");
        entity.Property(e => e.PostalCode)
            .HasMaxLength(10)
            .HasColumnName("postal_code");
        entity.Property(e => e.ProvinceId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("province_id");
        entity.Property(e => e.Sex)
            .HasDefaultValueSql("'F'")
            .HasColumnType("enum('M','F')")
            .HasColumnName("sex");
        entity.Property(e => e.Sms).HasColumnName("sms");
        entity.Property(e => e.TelephoneCountryCode)
            .HasDefaultValueSql("'1'")
            .HasColumnType("smallint(3) unsigned")
            .HasColumnName("telephone_country_code");
        entity.Property(e => e.TelephoneNumber)
            .HasMaxLength(100)
            .HasColumnName("telephone_number")
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Country).WithMany(p => p.Students)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("students_ibfk_1");

        entity.HasOne(d => d.Language).WithMany(p => p.Students)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("students_ibfk_3");

        entity.HasOne(d => d.Province).WithMany(p => p.Students)
            .HasForeignKey(d => d.ProvinceId)
            .HasConstraintName("students_ibfk_2");

        entity.HasOne(d => d.User).WithMany(p => p.Students)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("students_ibfk_4");
    }
}
