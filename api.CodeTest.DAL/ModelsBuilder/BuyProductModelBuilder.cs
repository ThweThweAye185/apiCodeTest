using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class BuyProductModelBuilder
    {
        public BuyProductModelBuilder(EntityTypeBuilder<BuyProduct> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);
            entityBuilder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(a => a.PhoneNumber).IsRequired(true);          
            entityBuilder.Property(p => p.BuyTypeStatus).IsRequired(false);
            entityBuilder.Property(p => p.CardNumber).IsRequired(false);
            entityBuilder.Property(p => p.ProductId).IsRequired(false);
            entityBuilder.Property(p => p.Amount).IsRequired(true);
            entityBuilder.HasOne(c => c.Product).WithMany(e => e.BuyType);

            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);


        }
    }
}
