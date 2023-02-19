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
        public DbSet<MemberInfo> MemberInfo { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            new ProductModelBuilder(builder.Entity<Product>().ToTable("Product"));
            new MemberInfoModelBuilder(builder.Entity<MemberInfo>().ToTable("MemberInfo"));
            new ProductItemModelBuilder(builder.Entity<ProductItem>().ToTable("ProductItem"));

        }

    }
}
