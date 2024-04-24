using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NS.Domain.Entities.Product;

namespace NS.Infrastructure.MSSQL.EFCore.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasAlternateKey(x => x.ManufactureEmail);
        builder.HasAlternateKey(x => x.ProduceDate);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.ProduceDate).IsRequired();
        builder.Property(x => x.ManufactureEmail).IsRequired().HasMaxLength(512);
        builder.Property(x => x.ManufacturePhone).IsRequired().HasMaxLength(15);
        builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(128);
        builder.Property(x => x.CreationDate).IsRequired();
        builder.Property(x => x.LastModifiedDate).IsRequired(false);

    }
}