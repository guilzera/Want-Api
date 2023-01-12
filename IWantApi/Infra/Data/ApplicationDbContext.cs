using IWantApi.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IWantApi.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
              .Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();

        builder.Entity<Category>()
            .Property(p => p.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        //todo string terá um máximo de caracteres de 100
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}