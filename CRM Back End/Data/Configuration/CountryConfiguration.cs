using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("countries")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.Iso31661, "iso 3166-1").IsUnique();

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Code)
            .HasMaxLength(2)
            .HasDefaultValueSql("''")
            .IsFixedLength()
            .HasColumnName("code");
        entity.Property(e => e.Eu).HasColumnName("eu");
        entity.Property(e => e.Iso31661)
            .HasColumnType("smallint(3) unsigned zerofill")
            .HasColumnName("iso 3166-1");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasDefaultValueSql("''")
            .HasColumnName("name");
        entity.Property(e => e.NeedsPostalCode)
            .IsRequired()
            .HasDefaultValueSql("'1'")
            .HasColumnName("needs_postal_code");
        entity.Property(e => e.NoShipping).HasColumnName("no_shipping");
        entity.Property(e => e.StudentCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_count");
    }
}
