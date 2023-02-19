using api.CodeTest.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using api.CodeTest.DAL.Models.Interfaces;
using api.CodeTest.DAL.ModelsBuilder;

namespace api.CodeTest.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public string CurrentUserId { get; set; }
        public DbSet<Product> Prodcuts { get; set; }
        public DbSet<BuyProduct> BuyProduct { get; set; }
        public DbSet<Order> Order { get; set; }        
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TransactionAudit> TransactionAudit { get; set; }
        public DbSet<Promotion> Promotion { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            new ProductModelBuilder(builder.Entity<Product>().ToTable("Product"));
            new BuyProductModelBuilder(builder.Entity<BuyProduct>().ToTable("BuyProduct"));
            new OrderModelBuilder(builder.Entity<Order>().ToTable("Order"));          
            new PaymentModelBuilder(builder.Entity<Payment>().ToTable("Payment"));
            new TranAuditModelBuilder(builder.Entity<TransactionAudit>().ToTable("TransactionAudit"));
            new PromotionModelBuilder(builder.Entity<Promotion>().ToTable("Promotion"));

        }

    }
}
