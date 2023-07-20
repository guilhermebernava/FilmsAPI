using Domain.Entities;

namespace Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    public Task<bool> SaveAsync();
    public Task<bool> AddAsync(T entity);
    public Task<bool> UpdateAsync(T entity, int id);
    public Task<bool> DeleteAsync(T entity);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<T> GetByIdAsync(int id);
    public Task<IList<T>> GetAllAsync(int id);   
}
