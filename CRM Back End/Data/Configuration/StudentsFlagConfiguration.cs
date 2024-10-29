using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class StudentsFlagConfiguration : IEntityTypeConfiguration<StudentsFlag>
{
    public void Configure(EntityTypeBuilder<StudentsFlag> entity)
    {
        entity.HasKey(e => e.StudentsFlagId).HasName("PRIMARY");

        entity.ToTable("students_flags");

        entity.HasIndex(e => e.FlagId, "flag_id");

        entity.HasIndex(e => e.StudentId, "student_id");

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.StudentsFlagId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("students_flag_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.FlagId)
            .HasMaxLength(191)
            .HasColumnName("flag_id");
        entity.Property(e => e.StudentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Flag).WithMany(p => p.StudentsFlags)
            .HasForeignKey(d => d.FlagId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_students_flags_flags");

        entity.HasOne(d => d.Student).WithMany(p => p.StudentsFlags)
            .HasForeignKey(d => d.StudentId)
            .HasConstraintName("FK_students_flags_students");

        entity.HasOne(d => d.User).WithMany(p => p.StudentsFlags)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_students_flags_users");
    }
}
