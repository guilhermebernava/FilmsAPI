using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public ApplicationDbContext _dbContext;
        public DbSet<T> dbSet { get; private set; }

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }


        public  async Task<bool> AddAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                dbSet.Remove(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<IList<T>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(_ => _.Id == id);

                if (entity == null)
                {
                    throw new NotFoundException($"Not found this {dbSet.GetType()}");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _dbContext.SaveChangesAsync() == 1 ? true : false;
            return saved;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                dbSet.Update(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }
    }
}
