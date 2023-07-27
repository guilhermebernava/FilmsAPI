using FilmsAPI;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services.Films;

public class FilmCreateWithActorAndGenreServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    FilmCreateWithActorAndGenreService FilmCreateService = new FilmCreateWithActorAndGenreService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldCreateFilm()
    {
        var result = await FilmCreateService.Execute(new FilmWithActorsAndGenresModel(new FilmModel("Test", 90, 7.0, "description", DateTime.Now), new List<ActorModel>(), new List<GenreModel>()));
        Assert.True(result.IsValid);
    }
}
