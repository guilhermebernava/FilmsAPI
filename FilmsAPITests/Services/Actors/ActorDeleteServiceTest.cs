using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActorsAPITests.Services;

public class ActorDeleteServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly ActorRepository Repository = new(_context);
    readonly IActorDeleteService ActorDeleteService = new ActorDeleteService(Repository);
    readonly IActorCreateService ActorCreateService = new ActorCreateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldDeleteActor()
    {
        var result = await ActorCreateService.Execute(new ActorModel("Test", 90));
        Assert.True(result.IsValid);

        result = await ActorDeleteService.Execute(1);
        Assert.True(result.IsValid);
    }
}
