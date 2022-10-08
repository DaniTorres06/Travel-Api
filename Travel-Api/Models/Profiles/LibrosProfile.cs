﻿using AutoMapper;
using Travel_Api.Models.DTO;

namespace Travel_Api.Models.Profiles
{
    public class LibrosProfile: Profile
    {
        public LibrosProfile()
        {
            CreateMap<Libros, LibrosDTO>();
            CreateMap<LibrosDTO, Libros>();
        }
    }
}
