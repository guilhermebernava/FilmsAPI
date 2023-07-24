using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services;

public class FilmGetWithActorAndGenreServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    FilmGetWithActorAndGenreService FilmGetAllService = new FilmGetWithActorAndGenreService(Repository);

    [Fact]
    public async Task ItShouldGetAllFilm()
    {
        var result = await FilmGetAllService.Execute(null);
        Assert.True(result.IsValid);
    }
}
