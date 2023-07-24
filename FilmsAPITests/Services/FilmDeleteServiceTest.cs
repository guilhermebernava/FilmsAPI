using Domain.Entities;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services;

public class FilmDeleteServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    IFilmDeleteService FilmDeleteService = new FilmDeleteService(Repository);

    [Fact]
    public async Task ItShouldDeleteFilm()
    {
        await Repository.AddAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now));
        var result = await FilmDeleteService.Execute(1);
        Assert.True(result.IsValid);
    }
}
