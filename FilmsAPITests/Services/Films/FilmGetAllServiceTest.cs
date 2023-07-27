using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services.Films;

public class FilmGetAllServiceTest
{
    private static readonly ApplicationDbContext _context = new(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static readonly FilmRepository Repository = new(_context);
    readonly IFilmGetAllService FilmGetAllService = new FilmGetAllService(Repository);

    [Fact]
    public async Task ItShouldGetAllFilm()
    {
        var result = await FilmGetAllService.Execute(new GetAllModel(20,1));
        Assert.True(result.IsValid);
    }
}
