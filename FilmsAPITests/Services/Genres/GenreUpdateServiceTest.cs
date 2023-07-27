using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GenresAPITests.Services;

public class GenreUpdateServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly GenreRepository Repository = new(_context);
    readonly IGenreCreateService GenreCreateService = new GenreCreateService(Repository, AutoMapperConfiguration.Initialize());
    readonly IGenreUpdateService GenreUpdateService = new GenreUpdateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldUpdateGenre()
    {
        var result = await GenreCreateService.Execute(new GenreModel("Test"));
        Assert.True(result.IsValid);

        result = await GenreUpdateService.Execute(new GenreUpdateModel( 1,new GenreModel("Testing")));
        Assert.True(result.IsValid);
    }
}
