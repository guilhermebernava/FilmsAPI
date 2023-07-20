using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Configurations;

public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
{
    public void Configure(EntityTypeBuilder<FilmGenre> builder)
    {
        builder.Property<int>("GenreId").IsRequired();
        builder.Property<int>("FilmId").IsRequired();
        builder.HasKey("GenreId", "FilmId");

        builder.HasOne(_ => _.Genre).WithMany(_ => _.FilmGenres).HasForeignKey("GenreId");
        builder.HasOne(_ => _.Film).WithMany(_ => _.FilmGenres).HasForeignKey("FilmId");
    }
}
