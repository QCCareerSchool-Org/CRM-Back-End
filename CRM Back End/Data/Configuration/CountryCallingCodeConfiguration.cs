using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;

public class CountryCallingCodeConfiguration : IEntityTypeConfiguration<CountryCallingCode>
{
    public void Configure(EntityTypeBuilder<CountryCallingCode> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("country_calling_codes")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Code)
            .HasColumnType("smallint(5) unsigned")
            .HasColumnName("code");
        entity.Property(e => e.Region)
            .HasMaxLength(255)
            .HasColumnName("region");
    }
}
