using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalChequePostConfiguration : IEntityTypeConfiguration<GlobalChequePost>
{
    public void Configure(EntityTypeBuilder<GlobalChequePost> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("global_cheque_posts")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalTransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.Success)
            .HasColumnType("tinyint(4)")
            .HasColumnName("success");

        entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.GlobalChequePost)
            .HasForeignKey<GlobalChequePost>(d => d.GlobalTransactionId)
            .HasConstraintName("global_cheque_posts_ibfk_1");
    }
}
