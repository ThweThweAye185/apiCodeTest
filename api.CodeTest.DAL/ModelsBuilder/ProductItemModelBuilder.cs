using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class ProductItemModelBuilder
    {
        public ProductItemModelBuilder(EntityTypeBuilder<ProductItem> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.itemType).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.price).IsRequired(true);
            entityBuilder.Property(p => p.qty).IsRequired(true);
            entityBuilder.Property(p => p.totalPrice).IsRequired(true);
        }
    }
}
