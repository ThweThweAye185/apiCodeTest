using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class ProductModelBuilder
    {
        public ProductModelBuilder(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.Description).HasMaxLength(100);
            entityBuilder.Property(p => p.ExpiryDate).IsRequired(true);
            //entityBuilder.Property(p => p.Image).IsRequired(false);
            entityBuilder.Property(p => p.Amount).IsRequired(true);
            entityBuilder.Property(p => p.Quantity).IsRequired(true);
            //entityBuilder.Property(p => p.IsAvailable).IsRequired(true);
            entityBuilder.Property(p => p.memberQRCode).IsRequired(false);
            entityBuilder.Property(p => p.couponQRCode).IsRequired(false);
            entityBuilder.Property(p => p.MaxEVoucher).IsRequired(true);
            entityBuilder.Property(p => p.MaxEVoucherPerUser).IsRequired(true);
            entityBuilder.HasMany(c => c.BuyType).WithOne(e => e.Product);           
            entityBuilder.HasMany(c => c.Promotion).WithOne(e => e.Product);
            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);
        }
    }
}
