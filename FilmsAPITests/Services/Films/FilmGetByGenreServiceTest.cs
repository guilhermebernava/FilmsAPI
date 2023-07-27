using Domain.Entities;
using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services.Films;

public class FilmGetByGenreServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    private static GenreRepository GenreRepository = new GenreRepository(_context);
    IFilmGetByGenreService FilmGetByGenreService = new FilmGetByGenreService(Repository);
    FilmCreateWithActorAndGenreService FilmCreateService = new FilmCreateWithActorAndGenreService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldGetByGenreFilm()
    {
        await GenreRepository.AddAsync(new Genre("Guilherme"));
        await FilmCreateService.Execute(new FilmWithActorsAndGenresModel(new FilmModel("Test", 90, 7.0, "description", DateTime.Now), new List<ActorModel>(), new List<GenreModel>() { new GenreModel("Guilherme") }));
        var result = await FilmGetByGenreService.Execute("Guilherme");
        Assert.True(result.IsValid);
    }
}
