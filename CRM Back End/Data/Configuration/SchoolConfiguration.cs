using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("schools")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.CourseCount)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_count");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
        entity.Property(e => e.StudentCenterAccountType)
            .HasDefaultValueSql("'general'")
            .HasColumnType("enum('general','style','travel','pet','writing')")
            .HasColumnName("student_center_account_type");
    }
}
