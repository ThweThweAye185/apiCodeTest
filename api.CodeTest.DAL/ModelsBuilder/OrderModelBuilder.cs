using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class OrderModelBuilder
    {
        public OrderModelBuilder(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.OrderNumber).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.OrderDate).IsRequired(true);
            entityBuilder.Property(p => p.PaymentDate).IsRequired(true);
            entityBuilder.Property(p => p.Quantity).IsRequired(true);
            entityBuilder.Property(p => p.PaymentTypeId).IsRequired(false);
            entityBuilder.Property(p => p.TransactinId).IsRequired(false);
            entityBuilder.Property(p => p.ProductId).IsRequired(false);
            entityBuilder.Property(p => p.Status).IsRequired(false);
            entityBuilder.HasOne(c => c.Payment).WithOne(e => e.Order).HasForeignKey<Order>(b => b.PaymentTypeId);
            entityBuilder.HasOne(c => c.Product).WithMany(e => e.Order);
            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);
        }
    }
}
