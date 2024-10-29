using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("provinces")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => new { e.CountryId, e.Code }, "code").IsUnique();

        entity.HasIndex(e => e.CountryId, "country_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Code)
            .HasMaxLength(3)
            .HasDefaultValueSql("''")
            .IsFixedLength()
            .HasColumnName("code");
        entity.Property(e => e.CountryId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("country_id");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasDefaultValueSql("''")
            .HasColumnName("name");
        entity.Property(e => e.StudentCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_count");

        entity.HasOne(d => d.Country).WithMany(p => p.Provinces)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("provinces_ibfk_1");
    }
}
