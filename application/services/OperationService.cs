using inventorySystem.application.interfaces;
using inventorySystem.domain.models;

namespace inventorySystem.application.services.OperationService;

public class OperationService : IService<Operation>
{
    public Task<IEnumerable<Operation>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Operation> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Create(Operation entity)
    {
        throw new NotImplementedException();
    }
    
}