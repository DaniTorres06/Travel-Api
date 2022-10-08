using AutoMapper;
using Travel_Api.Models.DTO;

namespace Travel_Api.Models.Profiles
{
    public class AutoresProfile: Profile
    {
        public AutoresProfile()
        {
            CreateMap<Autores, AutoresDTO>();
            CreateMap<AutoresDTO, Autores>();
        }

    }
}
