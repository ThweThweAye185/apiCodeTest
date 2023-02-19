using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class PromotionModelBuilder
    {
        public PromotionModelBuilder(EntityTypeBuilder<Promotion> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.PromCode).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.Description).IsRequired(false).HasMaxLength(100);
            entityBuilder.HasOne(c => c.Product).WithMany(e => e.Promotion);
            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);
        }
    }
}
