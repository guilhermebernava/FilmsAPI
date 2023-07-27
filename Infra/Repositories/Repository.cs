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
        public DbSet<T> DbSet { get; private set; }

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }


        public  async Task<bool> AddAsync(T entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
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
                DbSet.Remove(entity);
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
                DbSet.Remove(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }

        public async Task<IList<T>> GetAllAsync(int take = 20, int page = 1)
        {
            try
            {
                return await DbSet.Skip((page - 1) * take ).Take(take).ToListAsync();
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
                var entity = await DbSet.FirstOrDefaultAsync(_ => _.Id == id);

                if(entity == null)
                {
                    throw new NotFoundException($"Not found this {DbSet.GetType()}");
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
            var saved = await _dbContext.SaveChangesAsync() == 1;
            return saved;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                DbSet.Update(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationDbException(ex.Message);
            }
        }
    }
}
