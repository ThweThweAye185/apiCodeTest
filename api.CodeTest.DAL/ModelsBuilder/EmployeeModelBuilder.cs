using api.CodeTest.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.CodeTest.DAL.ModelsBuilder
{
    public class EmployeeModelBuilder
    {
        public EmployeeModelBuilder(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.Property(p => p.Id).HasMaxLength(36).IsRequired(true);
            entityBuilder.Property(p => p.empId).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(p => p.empName).IsRequired(true).HasMaxLength(50);
            entityBuilder.Property(a => a.phoneNumber).IsRequired(true);          
            entityBuilder.Property(p => p.address).IsRequired(false);
            entityBuilder.Property(p => p.position).IsRequired(false);
           
            entityBuilder.Property(p => p.Active).IsRequired(true);
            entityBuilder.Property(p => p.CreatedBy).IsRequired(false);
            entityBuilder.Property(p => p.UpdatedBy).IsRequired(false);
            entityBuilder.Property(p => p.CreatedDate).IsRequired(true);
            entityBuilder.Property(p => p.UpdatedDate).IsRequired(true);


        }
    }
}
