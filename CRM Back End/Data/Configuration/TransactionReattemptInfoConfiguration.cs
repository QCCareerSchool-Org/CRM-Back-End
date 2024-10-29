using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class TransactionReattemptInfoConfiguration : IEntityTypeConfiguration<TransactionReattemptInfo>
{
    public void Configure(EntityTypeBuilder<TransactionReattemptInfo> entity)
    {
        entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

        entity.ToTable("transaction_reattempt_info");

        entity.Property(e => e.TransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("transaction_id");
        entity.Property(e => e.Reattempts)
            .HasColumnType("tinyint(3) unsigned")
            .HasColumnName("reattempts");
        entity.Property(e => e.Success).HasColumnName("success");

        entity.HasOne(d => d.Transaction).WithOne(p => p.TransactionReattemptInfo)
            .HasForeignKey<TransactionReattemptInfo>(d => d.TransactionId)
            .HasConstraintName("transaction_reattempt_info_ibfk_1");
    }
}
