using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> entity)
    {
        entity.HasKey(e => e.RefreshTokenId).HasName("PRIMARY");

        entity.ToTable("refresh_tokens");

        entity.HasIndex(e => e.StudentId, "student_id");

        entity.HasIndex(e => e.Token, "token").IsUnique();

        entity.HasIndex(e => e.UserId, "user_id");

        entity.Property(e => e.RefreshTokenId)
            .HasMaxLength(16)
            .IsFixedLength()
            .HasColumnName("refresh_token_id");
        entity.Property(e => e.Browser)
            .HasMaxLength(191)
            .HasColumnName("browser");
        entity.Property(e => e.BrowserVersion)
            .HasMaxLength(191)
            .HasColumnName("browser_version");
        entity.Property(e => e.City)
            .HasMaxLength(191)
            .HasColumnName("city");
        entity.Property(e => e.Country)
            .HasMaxLength(2)
            .IsFixedLength()
            .HasColumnName("country");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.Expiry)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("expiry");
        entity.Property(e => e.IpAddress)
            .HasMaxLength(16)
            .HasColumnName("ip_address");
        entity.Property(e => e.Latitude)
            .HasPrecision(7, 4)
            .HasColumnName("latitude");
        entity.Property(e => e.Longitude)
            .HasPrecision(7, 4)
            .HasColumnName("longitude");
        entity.Property(e => e.Mobile).HasColumnName("mobile");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Os)
            .HasMaxLength(191)
            .HasColumnName("os");
        entity.Property(e => e.StudentId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("student_id");
        entity.Property(e => e.Token)
            .HasMaxLength(64)
            .IsFixedLength()
            .HasColumnName("token");
        entity.Property(e => e.UserId)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("user_id");

        entity.HasOne(d => d.Student).WithMany(p => p.RefreshTokens)
            .HasForeignKey(d => d.StudentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("refresh_tokens_ibfk_1");

        entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("refresh_tokens_ibfk_2");
    }
}
