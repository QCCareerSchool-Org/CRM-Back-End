using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;

public class CardeasexmlResponseConfiguration : IEntityTypeConfiguration<CardeasexmlResponse>
{
    public void Configure(EntityTypeBuilder<CardeasexmlResponse> entity)
    {
        entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

        entity
            .ToTable("cardeasexml_responses")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalTransactionId)
            .ValueGeneratedNever()
            .HasColumnType("int(10) unsigned")
            .HasColumnName("global_transaction_id");
        entity.Property(e => e.AuthCode)
            .HasMaxLength(8)
            .IsFixedLength()
            .HasColumnName("auth_code");
        entity.Property(e => e.CardEaseReference).HasColumnName("card_ease_reference");
        entity.Property(e => e.Created)
            .HasColumnType("datetime")
            .HasColumnName("created");
        entity.Property(e => e.Message)
            .HasMaxLength(100)
            .HasColumnName("message");
        entity.Property(e => e.Modified)
            .HasColumnType("datetime")
            .HasColumnName("modified");
        entity.Property(e => e.OrderId)
            .HasMaxLength(50)
            .HasColumnName("order_id");
        entity.Property(e => e.ResultCode)
            .HasColumnType("tinyint(2)")
            .HasColumnName("result_code");
        entity.Property(e => e.TransactionTime)
            .HasComment("not supplied by processor")
            .HasColumnType("datetime")
            .HasColumnName("transaction_time");

        entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.CardeasexmlResponse)
            .HasForeignKey<CardeasexmlResponse>(d => d.GlobalTransactionId)
            .HasConstraintName("cardeasexml_responses_ibfk_1");
    }
}
