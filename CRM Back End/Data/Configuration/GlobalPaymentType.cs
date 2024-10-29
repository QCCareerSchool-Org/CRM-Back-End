using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class AffiliateIdConfiguration : IEntityTypeConfiguration<AffiliateId>
{
    public void Configure(EntityTypeBuilder<AffiliateId> entity)
    {
        entity.HasKey(e => e.EnrollmentId).HasName("PRIMARY");

        entity
            .ToTable("affiliate_ids")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.EnrollmentId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_id");
        entity.Property(e => e.AffiliateId1)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("affiliate_id");

        entity.HasOne(d => d.Enrollment).WithOne(p => p.AffiliateId)
            .HasForeignKey<AffiliateId>(d => d.EnrollmentId)
            .HasConstraintName("affiliate_ids_ibfk_1");
    }
}
