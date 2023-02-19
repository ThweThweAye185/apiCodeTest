using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class TranAuditModelBuilder
    {
        public TranAuditModelBuilder(EntityTypeBuilder<TransactionAudit> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.TransactionStatus).IsRequired(false).HasMaxLength(15);
            entityBuilder.Property(p => p.ProductId).IsRequired(false).HasMaxLength(36);
            entityBuilder.Property(p => p.PhoneNumber).IsRequired(false);
            entityBuilder.Property(p => p.CardNumber).IsRequired(false);
            entityBuilder.Property(p => p.Amount).IsRequired(true);
            entityBuilder.Property(p => p.Request).IsRequired(false);
            entityBuilder.Property(p => p.Response).IsRequired(false);
            entityBuilder.Property(p => p.LogDate).IsRequired(true);

            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);
        }
    }
}
