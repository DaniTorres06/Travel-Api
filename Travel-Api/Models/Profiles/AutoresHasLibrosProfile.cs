using AutoMapper;
using Travel_Api.Models.DTO;

namespace Travel_Api.Models.Profiles
{
    public class AutoresHasLibrosProfile: Profile
    {
        public AutoresHasLibrosProfile()
        {
            CreateMap<Autores_has_libros, Autores_has_librosDTO>();
            CreateMap<Autores_has_librosDTO, Autores_has_libros>();
        }
    }
}
