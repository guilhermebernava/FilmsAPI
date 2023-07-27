﻿using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GenresAPITests.Services;

public class GenreDeleteServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly GenreRepository Repository = new(_context);
    readonly IGenreDeleteService GenreDeleteService = new GenreDeleteService(Repository);
    readonly IGenreCreateService GenreCreateService = new GenreCreateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldDeleteGenre()
    {
        var result = await GenreCreateService.Execute(new GenreModel("Test"));
        Assert.True(result.IsValid);

        result = await GenreDeleteService.Execute(1);
        Assert.True(result.IsValid);
    }
}
