using Domain.Entities;
using Infra.Context.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Actor> Actors;
        public DbSet<Film> Films;
        public DbSet<FilmActor> FilmActors;
        public DbSet<FilmGenre> FilmGenres;
        public DbSet<Genre> Genres;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new FilmActorConfiguration());
            modelBuilder.ApplyConfiguration(new FilmGenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
