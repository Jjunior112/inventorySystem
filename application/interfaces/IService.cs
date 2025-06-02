namespace inventorySystem.application.interfaces;

public interface IService<T> where T : class
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task Create(T entity);

    
}