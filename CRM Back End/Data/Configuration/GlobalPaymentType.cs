using CRM.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data.Configuration;
public class GlobalPaymentTypeConfiguration : IEntityTypeConfiguration<GlobalPaymentType>
{
    public void Configure(EntityTypeBuilder<GlobalPaymentType> entity)
    {
        entity.HasKey(e => e.GlobalPaymentTypeId).HasName("PRIMARY");

        entity
            .ToTable("global_payment_types")
            .HasCharSet("utf8")
            .UseCollation("utf8_general_ci");

        entity.Property(e => e.GlobalPaymentTypeId)
            .HasMaxLength(25)
            .HasColumnName("global_payment_type_id");
    }
}
