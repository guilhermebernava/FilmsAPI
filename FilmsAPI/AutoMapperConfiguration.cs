using AutoMapper;
using Domain.Entities;
using FilmsAPI.Models;

namespace FilmsAPI;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        Initialize();
    }

    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmModel, Film>();
            cfg.CreateMap<ActorModel, Actor>();
            cfg.CreateMap<GenreModel, Genre>();
        });

        return config.CreateMapper();
    }
}
