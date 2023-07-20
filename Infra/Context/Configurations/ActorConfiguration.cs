using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Configurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(_ => _.Name).HasColumnType("varchar(100)").IsRequired();
        builder.Property(_ => _.Age).IsRequired();

        builder.Ignore(_ => _.FilmActors);
    }
}
