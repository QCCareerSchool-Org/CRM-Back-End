using CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CRM.Data.Configuration;

public class BonusItemShipmentConfiguration : IEntityTypeConfiguration<BonusItemShipment>
{
    public void Configure(EntityTypeBuilder<BonusItemShipment> entity)
    {
        entity.HasKey(e => e.BonusItemShipmentId).HasName("PRIMARY");

        entity.ToTable("bonus_item_shipments");

        entity.HasIndex(e => e.BonusItemId, "bonus_item_id");

        entity.HasIndex(e => new { e.EnrollmentId, e.BonusItemId }, "enrollment_id_bonus_item_id").IsUnique();

        entity.Property(e => e.BonusItemShipmentId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("bonus_item_shipment_id");
        entity.Property(e => e.BonusItemId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("bonus_item_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.EnrollmentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.Prepared)
            .HasColumnType("timestamp")
            .HasColumnName("prepared");
        entity.Property(e => e.Qualified)
            .HasColumnType("timestamp")
            .HasColumnName("qualified");
        entity.Property(e => e.Shipped)
            .HasColumnType("timestamp")
            .HasColumnName("shipped");
        entity.Property(e => e.Threshold)
            .HasColumnType("decimal(6,5) unsigned")
            .HasColumnName("threshold");

        entity.HasOne(d => d.BonusItem).WithMany(p => p.BonusItemShipments)
            .HasForeignKey(d => d.BonusItemId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_bonus_item_shipments_bonus_items");

        entity.HasOne(d => d.Enrollment).WithMany(p => p.BonusItemShipments)
            .HasForeignKey(d => d.EnrollmentId)
            .HasConstraintName("FK_bonus_item_shipments_enrollments");
    }
}