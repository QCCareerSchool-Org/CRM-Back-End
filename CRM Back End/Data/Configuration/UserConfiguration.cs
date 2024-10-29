using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity
            .ToTable("users")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.HasIndex(e => e.Username, "username").IsUnique();

        entity.Property(e => e.Id)
            .HasColumnType("int(10) unsigned")
            .HasColumnName("id");
        entity.Property(e => e.AccountingPriv)
            .HasComment("modify, charge, and refund credit cards, print bank deposit sheets")
            .HasColumnName("accounting_priv");
        entity.Property(e => e.AdminPriv)
            .HasComment("add and delete users, modify user permissions")
            .HasColumnName("admin_priv");
        entity.Property(e => e.Created)
            .HasDefaultValueSql("current_timestamp()")
            .HasColumnType("timestamp")
            .HasColumnName("created");
        entity.Property(e => e.EmailAddress)
            .HasMaxLength(255)
            .HasColumnName("email_address");
        entity.Property(e => e.FirstName)
            .HasMaxLength(40)
            .HasColumnName("first_name");
        entity.Property(e => e.LastName)
            .HasMaxLength(40)
            .HasColumnName("last_name");
        entity.Property(e => e.Modified)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("timestamp")
            .HasColumnName("modified");
        entity.Property(e => e.Password)
            .HasMaxLength(40)
            .IsFixedLength()
            .HasColumnName("password");
        entity.Property(e => e.Sex)
            .HasDefaultValueSql("'F'")
            .HasColumnType("enum('M','F')")
            .HasColumnName("sex");
        entity.Property(e => e.Username)
            .HasMaxLength(50)
            .HasColumnName("username");
    }
}
