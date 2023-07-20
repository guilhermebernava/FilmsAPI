using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(_ => _.Name).HasColumnType("varchar(50)").IsRequired();

        builder.Ignore(_ => _.FilmGenres);
        builder.HasAlternateKey(_ => _.Name);
    }
}
