using Domain.Entities;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraTests.Repositories;

public class FilmRepositoryTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    private static ActorRepository ActorRepository = new ActorRepository(_context);
    private static GenreRepository GenreRepository = new GenreRepository(_context);

    [Fact]
    public async Task ItShouldAddFilmWithActorsAndGenres()
    {
        var actor = new Actor("Guilherme", 18);
        var genre = new Genre("Horror");
        await ActorRepository.AddAsync(actor);
        await GenreRepository.AddAsync(genre);

        var savedFilm = await Repository.AddFilmWithActorsAndGenresAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now), new List<Actor>() { actor }, new List<Genre>() { genre });

        Assert.True(savedFilm);
    }

    [Fact]
    public async Task ItShouldGetAllFilmsFromActor()
    {
        var actor = new Actor("Guilherme", 18);
        await ActorRepository.AddAsync(actor);
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now), new List<Actor>() { actor }, new List<Genre>());
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Testando", 110, 7.0, "Description", DateTime.Now), new List<Actor>(), new List<Genre>());

        var films = await Repository.GetAllFimsFromActorAsync("Guilherme");
        Assert.True(films.Count == 1);
    }

    [Fact]
    public async Task ItShouldGetAllFilmsFromGenre()
    {
        var genre = new Genre("Terror");
        await GenreRepository.AddAsync(genre);
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now), new List<Actor>(), new List<Genre>() { genre });
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Testando", 110, 7.0, "Description", DateTime.Now), new List<Actor>(), new List<Genre>());

        var films = await Repository.GetAllFimsFromGenreAsync("Terror");
        Assert.True(films.Count == 1);
    }

    [Fact]
    public async Task ItShouldGetFilmWithActorsAndGenres()
    {
        var actor = new Actor("Guilherme", 18);
        var genre = new Genre("Horror");
        await ActorRepository.AddAsync(actor);
        await GenreRepository.AddAsync(genre);
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now), new List<Actor>() { actor }, new List<Genre>() { genre });

        var film = await Repository.GetFilmWithActorsAndGenresAsync("Teste");
        Assert.NotNull(film);
        Assert.True(film.FilmGenres.Count > 0);
        Assert.True(film.FilmActors.Count > 0);
    }

    [Fact]
    public async Task ItShouldGetAllFilmWithActorsAndGenres()
    {
        var actor = new Actor("Guilherme", 18);
        var genre = new Genre("Horror");
        await ActorRepository.AddAsync(actor);
        await GenreRepository.AddAsync(genre);
        await Repository.AddFilmWithActorsAndGenresAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now), new List<Actor>() { actor }, new List<Genre>() { genre });

        var films = await Repository.GetAllFilmWithActorsAndGenresAsync();
        Assert.True(films.Count > 0);
        Assert.True(films.First().FilmGenres.Count > 0);
        Assert.True(films.First().FilmActors.Count > 0);
    }
}
