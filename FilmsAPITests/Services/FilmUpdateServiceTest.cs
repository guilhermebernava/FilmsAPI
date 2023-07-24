using Domain.Entities;
using FilmsAPI;
using FilmsAPI.Interfaces.Services;
using FilmsAPI.Models;
using FilmsAPI.Services;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmsAPITests.Services;

public class FilmUpdateServiceTest
{
    private static ApplicationDbContext _context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options);
    private static FilmRepository Repository = new FilmRepository(_context);
    IFilmUpdateService FilmUpdateService = new FilmUpdateService(Repository, AutoMapperConfiguration.Initialize());

    [Fact]
    public async Task ItShouldUpdateFilm()
    {
        await Repository.AddAsync(new Film("Teste", 90, 7.0, "Description", DateTime.Now));
        var result = await FilmUpdateService.Execute(new FilmUpdateModel(new FilmModel("Test",90,7.0,"description",DateTime.Now),1));
        Assert.True(result.IsValid);
    }
}
