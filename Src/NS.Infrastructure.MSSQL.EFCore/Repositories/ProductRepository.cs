using Microsoft.EntityFrameworkCore;
using NS.Domain.Entities.Product;

namespace NS.Infrastructure.MSSQL.EFCore.Repositories;

public class ProductRepository(NadinContext context) : BaseEntityRepository<long, Product>(context), IProductRepository
{
    private readonly NadinContext _context = context;
    public async Task<bool> IsProductEmailUnique(string email)
    {
        return await _context.Products.AnyAsync(x => x.ManufactureEmail == email);
    }

    public async Task<bool> IsProduceDateUnique(DateOnly date)
    {
        return await _context.Products.AnyAsync(x => x.ProduceDate == date);
    }
}