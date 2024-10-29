using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("notes");

        entity.HasIndex(e => e.CourseId, "course_id");

        entity.HasIndex(e => e.StudentId, "student_id");

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.CourseId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("course_id");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Note1).HasColumnName("note");
        entity.Property(e => e.Starred).HasColumnName("starred");
        entity.Property(e => e.StudentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.Type)
            .HasDefaultValueSql("'automatic'")
            .HasColumnType("enum('general','automatic','tutorial')")
            .HasColumnName("type")
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Course).WithMany(p => p.Notes)
            .HasForeignKey(d => d.CourseId)
            .HasConstraintName("notes_ibfk_3");

        entity.HasOne(d => d.Student).WithMany(p => p.Notes)
            .HasForeignKey(d => d.StudentId)
            .HasConstraintName("notes_ibfk_1");

        entity.HasOne(d => d.User).WithMany(p => p.Notes)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("notes_ibfk_2");
    }
}
