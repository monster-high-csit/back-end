using AutoMapper;
using Cinema.Dto;
using Cinema.Entities;

namespace Cinema.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmDto, Film>();
            CreateMap<Film, FilmDto>();
        }
    }
}
