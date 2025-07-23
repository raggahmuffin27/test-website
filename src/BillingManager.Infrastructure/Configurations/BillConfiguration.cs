using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BillingManager.Domain.Entities;

namespace BillingManager.Infrastructure.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BillNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Amount)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.PenaltyAmount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(b => b.PaidAmount)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(b => b.PreviousReading)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.CurrentReading)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.Consumption)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.Rate)
            .HasColumnType("decimal(18,2)");

        builder.Property(b => b.Notes)
            .HasMaxLength(1000);

        builder.HasIndex(b => b.BillNumber)
            .IsUnique();

        builder.HasIndex(b => new { b.CustomerId, b.BillingPeriodStart, b.BillType })
            .HasDatabaseName("IX_Bill_Customer_Period_Type");

        // Relationships
        builder.HasOne(b => b.Customer)
            .WithMany(c => c.Bills)
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Unit)
            .WithMany(u => u.Bills)
            .HasForeignKey(b => b.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.Payments)
            .WithMany(p => p.Bills)
            .UsingEntity<PaymentBill>(
                j => j
                    .HasOne(pb => pb.Payment)
                    .WithMany(p => p.PaymentBills)
                    .HasForeignKey(pb => pb.PaymentId),
                j => j
                    .HasOne(pb => pb.Bill)
                    .WithMany()
                    .HasForeignKey(pb => pb.BillId),
                j =>
                {
                    j.HasKey(pb => pb.Id);
                    j.Property(pb => pb.AmountPaid).HasColumnType("decimal(18,2)");
                    j.Property(pb => pb.Notes).HasMaxLength(500);
                });
    }
}

