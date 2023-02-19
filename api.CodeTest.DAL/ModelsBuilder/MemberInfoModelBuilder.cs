using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class MemberInfoModelBuilder
    {
        public MemberInfoModelBuilder(EntityTypeBuilder<MemberInfo> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);

            entityBuilder.Property(p => p.memberName).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.phoneNumber).IsRequired(true);
            entityBuilder.Property(p => p.totalPoints).IsRequired(true);
            entityBuilder.Property(p => p.purchaseAmount).IsRequired(true);
            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);
        }
    }
}
