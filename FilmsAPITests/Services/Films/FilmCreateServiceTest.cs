using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services.Films;

public class FilmCreateServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly FilmRepository Repository = new(_context);
    readonly IFilmCreateService FilmCreateService = new FilmCreateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldCreateFilm()
    {
        var result = await FilmCreateService.Execute(new FilmModel("Test", 90, 7.0, "description", DateTime.Now));
        Assert.True(result.IsValid);
    }
}
