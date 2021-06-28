using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(1000);
            builder.Property(p=>p.PictureUrl).IsRequired().HasMaxLength(2000);
            builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(8,2)");
            builder.HasOne(p=>p.ProductBrand).WithMany()
                   .HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(p=>p.ProductType).WithMany()
                   .HasForeignKey(p=>p.ProductTypeId);       


        }
    }
}