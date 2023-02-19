using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using api.CodeTest.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.CodeTest.DbContextFactory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(configuration["ConnectionStrings:DatabaseConnection"], b => b.MigrationsAssembly("api.CodeTest"));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
