using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("prices")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.CountryId, "country_id");

        entity.HasIndex(e => e.CourseId, "course_id");

        entity.HasIndex(e => e.CurrencyId, "currency_id");

        entity.HasIndex(e => e.ProvinceId, "province_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Cost)
            .HasColumnType("decimal(10,2) unsigned")
            .HasColumnName("cost");
        entity.Property(e => e.CountryId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("country_id");
        entity.Property(e => e.CourseId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.CurrencyId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("currency_id");
        entity.Property(e => e.Enabled)
            .HasDefaultValueSql("'1'")
            .HasColumnType("tinyint(1) unsigned")
            .HasColumnName("enabled");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.ProvinceId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("province_id");
        entity.Property(e => e.ShippingCost)
            .HasColumnType("decimal(10,2) unsigned")
            .HasColumnName("shipping_cost");

        entity.HasOne(d => d.Country).WithMany(p => p.Prices)
            .HasForeignKey(d => d.CountryId)
            .HasConstraintName("prices_ibfk_2");

        entity.HasOne(d => d.Course).WithMany(p => p.Prices)
            .HasForeignKey(d => d.CourseId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("prices_ibfk_1");

        entity.HasOne(d => d.Currency).WithMany(p => p.Prices)
            .HasForeignKey(d => d.CurrencyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("prices_ibfk_4");

        entity.HasOne(d => d.Province).WithMany(p => p.Prices)
            .HasForeignKey(d => d.ProvinceId)
            .HasConstraintName("prices_ibfk_3");
    }
}
