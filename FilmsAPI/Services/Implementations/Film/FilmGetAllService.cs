using Domain.Entities;
using Domain.Repositories;
using FilmsAPI.DTOs;
using FilmsAPI.Services.Interfaces;

namespace FilmsAPI.Services.Implementations
{
    public class FilmGetAllService : IGetAllService<Film>
    {
        private IFilmRepository _filmRepository;

        public FilmGetAllService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<ServiceResponseDto<IList<Film>>> GetAll()
        {
           var films =  await _filmRepository.GetAllAsync();
           return new ServiceResponseDto<IList<Film>>(films);
        }
    }
}
