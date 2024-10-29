using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class BonusItemConfiguration : IEntityTypeConfiguration<BonusItem>
{
    public void Configure(EntityTypeBuilder<BonusItem> entity)
    {
        entity.HasKey(e => e.BonusItemId).HasName("PRIMARY");

        entity.ToTable("bonus_items");

        entity.Property(e => e.BonusItemId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("bonus_item_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Default)
            .HasComment("new enrollments should default to getting this item")
            .HasColumnName("default");
        entity.Property(e => e.Description)
            .HasColumnType("text")
            .HasColumnName("description");
        entity.Property(e => e.Enabled)
            .IsRequired()
            .HasDefaultValueSql("'1'")
            .HasComment("at enrollment time, this item will show up in the list of possible bonus items")
            .HasColumnName("enabled");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Name)
            .HasMaxLength(191)
            .HasColumnName("name");
        entity.Property(e => e.ShipImmediately)
            .HasComment("when a new enrollment includes this bonus item, the bonus item shipment will be set into a \"shipment pending\" state from the start")
            .HasColumnName("ship_immediately");
        entity.Property(e => e.Threshold)
            .HasColumnType("decimal(6,5) unsigned")
            .HasColumnName("threshold");
    }
}
