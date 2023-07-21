using AutoMapper;
using Domain.Entities;
using FilmsAPI.Models;

namespace FilmsAPI;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<FilmViewModel, Film>();
        CreateMap<ActorViewModel, Actor>();
        CreateMap<GenreViewModel, Genre>();
    }
}
