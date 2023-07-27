using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActorsAPITests.Services;

public class ActorUpdateServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly ActorRepository Repository = new(_context);
    readonly IActorCreateService ActorCreateService = new ActorCreateService(Repository, AutoMapperConfiguration.Initialize());
    readonly IActorUpdateService ActorUpdateService = new ActorUpdateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldCreateActor()
    {
        var result = await ActorCreateService.Execute(new ActorModel("Test", 90));
        Assert.True(result.IsValid);

        result = await ActorUpdateService.Execute(new ActorUpdateModel(new ActorModel("Testing", 10), 1));
        Assert.True(result.IsValid);
    }
}
