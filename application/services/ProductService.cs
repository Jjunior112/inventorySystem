using inventorySystem.application.interfaces;
using inventorySystem.domain.models;

namespace inventorySystem.application.services.ProductService;

public class ProductService : IService<Product>
{
    public async Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Create(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
    
}