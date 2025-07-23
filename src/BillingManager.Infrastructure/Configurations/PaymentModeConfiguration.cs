using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Configurations;

public class PaymentModeConfiguration : IEntityTypeConfiguration<PaymentMode>
{
    public void Configure(EntityTypeBuilder<PaymentMode> builder)
    {
        builder.HasKey(pm => pm.Id);

        builder.Property(pm => pm.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pm => pm.Description)
            .HasMaxLength(500);

        builder.Property(pm => pm.SortOrder)
            .HasDefaultValue(0);

        builder.HasIndex(pm => pm.Name)
            .IsUnique();

        // Relationships
        builder.HasMany(pm => pm.Payments)
            .WithOne(p => p.PaymentMode)
            .HasForeignKey(p => p.PaymentModeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed data
        builder.HasData(
            new PaymentMode { Id = 1, Name = "Cash", Description = "Cash payment", IsActive = true, IsDefault = true, SortOrder = 1, CreatedAt = DateTime.UtcNow },
            new PaymentMode { Id = 2, Name = "Check", Description = "Check payment", IsActive = true, IsDefault = false, SortOrder = 2, CreatedAt = DateTime.UtcNow },
            new PaymentMode { Id = 3, Name = "Bank Transfer", Description = "Bank transfer payment", IsActive = true, IsDefault = false, SortOrder = 3, CreatedAt = DateTime.UtcNow },
            new PaymentMode { Id = 4, Name = "Credit Card", Description = "Credit card payment", IsActive = true, IsDefault = false, SortOrder = 4, CreatedAt = DateTime.UtcNow },
            new PaymentMode { Id = 5, Name = "Online Payment", Description = "Online payment", IsActive = true, IsDefault = false, SortOrder = 5, CreatedAt = DateTime.UtcNow }
        );
    }
}

