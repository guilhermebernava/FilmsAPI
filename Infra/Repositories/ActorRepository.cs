using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories;

public class ActorRepository : Repository<Actor>, IActorRepository
{
    public ActorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
