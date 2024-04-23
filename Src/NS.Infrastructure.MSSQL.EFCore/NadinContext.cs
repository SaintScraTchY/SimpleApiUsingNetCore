using Microsoft.EntityFrameworkCore;
using NS.Domain.Entities.Product;
using NS.Domain.Entities.User;
using NS.Infrastructure.MSSQL.EFCore.Mappings;

namespace NS.Infrastructure.MSSQL.EFCore;

public class NadinContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}