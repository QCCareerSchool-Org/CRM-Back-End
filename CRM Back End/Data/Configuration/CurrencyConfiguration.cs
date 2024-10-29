using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class CurrencyConfiguration: IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("currencies")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.Code, "code").IsUnique();

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Code)
            .HasMaxLength(3)
            .IsFixedLength()
            .HasColumnName("code");
        entity.Property(e => e.Created)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.ExchangeRate)
            .HasPrecision(10, 5)
            .HasColumnName("exchange_rate");
        entity.Property(e => e.Modified)
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
        entity.Property(e => e.Symbol)
            .HasMaxLength(5)
            .HasColumnName("symbol");
    }
}
