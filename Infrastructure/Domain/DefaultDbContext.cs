using Microsoft.EntityFrameworkCore;
using NeilMacabulos.Midterm_.Infrastructure.Domain.Model;
using NeilMacabulos.Midterm_.Infrastructure.Domain.Models;
using System.Data;

namespace NeilMacabulos.Midterm_.Infrastructure.Domain
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsLogin> UserLogins { get; set; }
        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            List<Categories> roles = new List<Categories>();

            roles.Add(new Categories()
            {
                Id = Guid.Parse("0faf41a9-d5c6-41b2-bb3b-f106a30dfed2"),
                Name = "Buyer",
                Description = "People who buying a products",
                Abbreviation = "Byr",
            });

            roles.Add(new Categories()
            {
                Id = Guid.Parse("dda07425-9084-4894-b41c-bc4f04c3a055"),
                Name = "Consumer",
                Description = "People who consume products",
                Abbreviation = "Csmr",
            });

            roles.Add(new Categories()
            {
                Id = Guid.Parse("9849e656-37cf-4569-96f8-05e6ed72ce83"),
                Name = "Producer",
                Description = "People who buying a products",
                Abbreviation = "Prdcr",
            });

        }
    }
}