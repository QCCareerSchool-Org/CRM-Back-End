using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class TimeZoneConfiguration : IEntityTypeConfiguration<Models.TimeZone>
{
    public void Configure(EntityTypeBuilder<Models.TimeZone> entity)
    {
        entity.HasKey(e => e.StudentId).HasName("PRIMARY");

        entity.ToTable("time_zones");

        entity.Property(e => e.StudentId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.TimeZoneId)
            .HasMaxLength(191)
            .HasColumnName("time_zone_id")
            .UseCollation("ascii_general_ci")
            .HasCharSet("ascii");
    }
}
