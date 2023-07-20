using Domain.Entities;
using Infra.Context;
using Infra.Exceptions;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraTests.Repositories;

public class RepositoryTest
{
    private static Repository<Actor> Repository = new Repository<Actor>(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options));
    
    [Fact]
    public async Task ItShouldAdd()
    {
        var actor = new Actor("Guilherme", 18);
        var result = await Repository.AddAsync(actor);
        Assert.True(result);
    }

    [Fact]
    public async Task ItShouldUpdate()
    {
        var actor = new Actor("Guilherme", 18);
        var result = await Repository.AddAsync(actor);
        Assert.True(result);

        var entity = await Repository.GetByIdAsync(1);
        entity.Name = "New Name";
        result = await Repository.UpdateAsync(entity);
        Assert.True(result);
    }

    [Fact]
    public async Task ItShouldGetAll()
    {
        var actors = await Repository.GetAllAsync();
        Assert.NotNull(actors);
    }

    #region GET_BY_ID
    [Fact]
    public async Task ItShouldGetById()
    {
        var entity = new Actor("Guilherme", 18);
        var result = await Repository.AddAsync(entity);
        Assert.True(result);

        var actor = await Repository.GetByIdAsync(1);
        Assert.NotNull(actor);
    }

    [Fact]
    public async Task ItShouldNotFoundAnyById()
    {
        await Assert.ThrowsAsync<ApplicationDbException>(()  =>  Repository.GetByIdAsync(1));
    }
    #endregion

    #region DELETE_BY_ID
    [Fact]
    public async Task ItShouldRemoveById()
    {
        var entity = new Actor("Guilherme", 18);
        var result = await Repository.AddAsync(entity);
        Assert.True(result);

        var isDeleted = await Repository.DeleteByIdAsync(1);
        Assert.True(isDeleted);
    }

    [Fact]
    public async Task ItShouldNotDeletedById()
    {
        await Assert.ThrowsAsync<ApplicationDbException>(() => Repository.DeleteByIdAsync(1));
    }
    #endregion

    #region DELETE
    [Fact]
    public async Task ItShouldRemove()
    {
        var entity = new Actor("Guilherme", 18);
        var result = await Repository.AddAsync(entity);
        Assert.True(result);

        var isDeleted = await Repository.DeleteAsync(entity);
        Assert.True(isDeleted);
    }

    [Fact]
    public async Task ItShouldNotRemove()
    {
        var entity = new Actor("Guilherme", 18);
        await Assert.ThrowsAsync<ApplicationDbException>(() => Repository.DeleteAsync(entity));
    }
    #endregion
}