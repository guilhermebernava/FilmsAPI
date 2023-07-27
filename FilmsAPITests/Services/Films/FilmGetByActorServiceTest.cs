using Domain.Entities;
using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services.Films;

public class FilmGetByActorServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    private static ActorRepository ActorRepository = new ActorRepository(_context);
    IFilmGetByActorService FilmGetByActorService = new FilmGetByActorService(Repository);
    FilmCreateWithActorAndGenreService FilmCreateService = new FilmCreateWithActorAndGenreService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldGetByActorFilm()
    {
        await ActorRepository.AddAsync(new Actor("Guilherme", 10));
        await FilmCreateService.Execute(new FilmWithActorsAndGenresModel(new FilmModel("Test", 90, 7.0, "description", DateTime.Now), new List<ActorModel>() { new ActorModel("Guilherme", 10) }, new List<GenreModel>()));
        var result = await FilmGetByActorService.Execute("Guilherme");
        Assert.True(result.IsValid);
    }
}
