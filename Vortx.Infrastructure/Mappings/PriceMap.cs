using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vortx.Domain.Entities;

namespace Vortx.Infrastructure.Mappings
{
    public class PriceMap : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.DddOrigin)
                .HasColumnType("varchar")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.DddDestination)
                .HasColumnType("varchar")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Minute)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(c => c.UpdatedAt)
                .HasColumnType("datetime");
        }
    }
}
