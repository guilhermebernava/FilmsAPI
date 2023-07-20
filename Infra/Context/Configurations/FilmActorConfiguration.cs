using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Configurations;

public class FilmActorConfiguration : IEntityTypeConfiguration<FilmActor>
{
    public void Configure(EntityTypeBuilder<FilmActor> builder)
    {
        builder.Property<int>("ActorId").IsRequired();
        builder.Property<int>("FilmId").IsRequired();
        builder.HasKey("ActorId", "FilmId");

        builder.HasOne(_ => _.Actor).WithMany(_ => _.FilmActors).HasForeignKey("ActorId");
        builder.HasOne(_ => _.Film).WithMany(_ => _.FilmActors).HasForeignKey("FilmId");
    }
}
