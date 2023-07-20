using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
