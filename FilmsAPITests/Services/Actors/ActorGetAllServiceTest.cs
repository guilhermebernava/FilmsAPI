﻿using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActorsAPITests.Services;

public class ActorGetAllServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly ActorRepository Repository = new(_context);
    readonly IActorCreateService ActorCreateService = new ActorCreateService(Repository, AutoMapperConfiguration.Initialize());
    readonly IActorGetAllService ActorGetAllService = new ActorGetAllService(Repository);

    [Fact]
    public async Task ItShouldCreateActor()
    {
        var result = await ActorCreateService.Execute(new ActorModel("Test", 90));
        Assert.True(result.IsValid);

        result = await ActorGetAllService.Execute(new GetAllModel(20,1));
        Assert.True(result.IsValid);
    }
}
