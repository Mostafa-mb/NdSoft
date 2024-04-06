using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext :IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<AppUserProduct> AppUserProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserProduct>(p => p.HasKey(p => new { p.ProductId, p.AppUserId }));


            builder.Entity<AppUserProduct>()
                .HasOne(p => p.AppUser)
                .WithMany(p => p.AppUserProducts)
                .HasForeignKey(p => p.AppUserId);
            
            builder.Entity<AppUserProduct>()
                .HasOne(p => p.product)
                .WithMany(p => p.AppUserProducts)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
