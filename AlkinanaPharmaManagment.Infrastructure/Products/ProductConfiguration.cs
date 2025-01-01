using AlkinanaPharmaManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Products
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.ProductId);

            builder.Property(c => c.ProductId)
                   .HasConversion(
                       id => id.Value, // تحويل إلى القيمة الأساسية عند الحفظ
                       value => new Domain.ValueObject.ProductId(value) // تحويل إلى الكائن عند الاسترجاع
                   )
                   .HasColumnName("ProductId");

            builder.OwnsOne(c => c.name, name =>
            {
                name.Property(n => n.Value).HasColumnName("CustomerName");
            });

            builder.OwnsOne(c => c.supplier, pharma =>
            {
                pharma.Property(p => p.Value).HasColumnName("Pharma");
            });

            builder.OwnsOne(c => c.image, image =>
            {
                image.Property(a => a.Value).HasColumnName("Image");
            });

            builder.OwnsOne(c => c.companyName, company =>
            {
                company.Property(a => a.Value).HasColumnName("ComapanyName");
            });

            builder.OwnsOne(c => c.description, desc =>
            {
                desc.Property(a => a.Value).HasColumnName("Description");
            });

            builder.OwnsOne(c => c.price, price =>
            {
                price.Property(a => a.Value).HasColumnName("Price");
            });
           
        }
    }
}
