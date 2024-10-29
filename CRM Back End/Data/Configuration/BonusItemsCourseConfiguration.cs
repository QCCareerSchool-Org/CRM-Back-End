using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class BonusItemsCourseConfiguration : IEntityTypeConfiguration<BonusItemsCourse>
{
    public void Configure(EntityTypeBuilder<BonusItemsCourse> entity)
    {
        entity.HasKey(e => e.BonusItemCourseId).HasName("PRIMARY");

        entity.ToTable("bonus_items_courses");

        entity.HasIndex(e => new { e.BonusItemId, e.CourseId }, "bonus_item_id_course_id").IsUnique();

        entity.HasIndex(e => e.CourseId, "course_id");

        entity.Property(e => e.BonusItemCourseId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("bonus_item_course_id");
        entity.Property(e => e.BonusItemId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("bonus_item_id");
        entity.Property(e => e.CourseId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_id");

        entity.HasOne(d => d.BonusItem).WithMany(p => p.BonusItemsCourses)
            .HasForeignKey(d => d.BonusItemId)
            .HasConstraintName("FK_bonus_items_courses_bonus_items");

        entity.HasOne(d => d.Course).WithMany(p => p.BonusItemsCourses)
            .HasForeignKey(d => d.CourseId)
            .HasConstraintName("FK_bonus_items_courses_courses");
    }
}
