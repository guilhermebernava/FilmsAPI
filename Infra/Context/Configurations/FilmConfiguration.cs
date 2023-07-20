using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Configurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(_ => _.Title).HasColumnType("varchar(150)").IsRequired();
        builder.Property(_ => _.Description).IsRequired();
        builder.Property(_ => _.Duration).IsRequired();
        builder.Property(_ => _.ReleaseDate).IsRequired();
        builder.Property(_ => _.Score);

        builder.Ignore(_ => _.FilmActors);
        builder.Ignore(_ => _.FilmGenres);

        builder.HasAlternateKey(_ => _.Title);
    }
}
