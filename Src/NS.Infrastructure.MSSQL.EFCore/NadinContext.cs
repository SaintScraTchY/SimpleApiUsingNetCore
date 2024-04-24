using Microsoft.EntityFrameworkCore;
using NS.Domain.Entities.Product;
using NS.Infrastructure.MSSQL.EFCore.Mappings;

namespace NS.Infrastructure.MSSQL.EFCore;

public class NadinContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    //public DbSet<User> Users { get; set; }
    public NadinContext(DbContextOptions<NadinContext> options) : base(options)
    {
    }

    protected NadinContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ProductMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);

        Database.EnsureCreated();
    }
}