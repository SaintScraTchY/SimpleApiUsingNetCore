using NS.Domain.Common;

namespace NS.Domain.Entities.Product;

public interface IProductRepository : IBaseEntityRepository<long,Product>
{
    Task<bool> IsProductEmailUnique(string email);
    Task<bool> IsProduceDateUnique(DateOnly date);
}