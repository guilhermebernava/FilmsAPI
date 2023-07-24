using FilmsAPI.Interfaces.Services;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services;

public class FilmGetAllServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    IFilmGetAllService FilmGetAllService = new FilmGetAllService(Repository);

    [Fact]
    public async Task ItShouldGetAllFilm()
    {
        var result = await FilmGetAllService.Execute();
        Assert.True(result.IsValid);
    }
}
