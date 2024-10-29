using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GeoLocationConfiguration : IEntityTypeConfiguration<GeoLocation>
{
    public void Configure(EntityTypeBuilder<GeoLocation> entity)
    {
        entity.HasKey(e => e.StudentId).HasName("PRIMARY");

        entity.ToTable("geo_locations");

        entity.Property(e => e.StudentId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.Latitude)
            .HasPrecision(10, 7)
            .HasColumnName("latitude");
        entity.Property(e => e.Longitude)
            .HasPrecision(10, 7)
            .HasColumnName("longitude");
    }
}
