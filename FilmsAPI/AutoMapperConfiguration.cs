using AutoMapper;
using Domain.Entities;
using FilmsAPI.Models;

namespace FilmsAPI;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<FilmModel, Film>();
        CreateMap<ActorModel, Actor>();
        CreateMap<GenreModel, Genre>();
    }
}
