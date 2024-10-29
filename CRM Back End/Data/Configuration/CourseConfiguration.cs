using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("courses")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.SchoolId, "school_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.Code)
            .HasMaxLength(2)
            .IsFixedLength()
            .HasColumnName("code");
        entity.Property(e => e.Cost)
            .HasPrecision(10, 2)
            .HasColumnName("cost");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.EnrollmentCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("enrollment_count");
        entity.Property(e => e.Installment)
            .HasPrecision(10, 2)
            .HasColumnName("installment");
        entity.Property(e => e.MaxAssignments)
            .HasColumnType("int(11)")
            .HasColumnName("max_assignments");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
        entity.Property(e => e.Order)
            .HasDefaultValueSql("'50'")
            .HasColumnType("int(10) unsigned")
            .HasColumnName("order");
        entity.Property(e => e.Prefix)
            .HasMaxLength(2)
            .IsFixedLength()
            .HasColumnName("prefix");
        entity.Property(e => e.SchoolId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("school_id");

        entity.HasOne(d => d.School).WithMany(p => p.Courses)
            .HasForeignKey(d => d.SchoolId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("courses_ibfk_1");
    }
}
