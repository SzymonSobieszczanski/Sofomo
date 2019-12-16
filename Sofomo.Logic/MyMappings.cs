using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sofomo.DTO;
using Sofomo.Models;


namespace Sofomo.Logic
{
    public class MyMappings : Profile
    {
        public MyMappings()
        {
            CreateMap<IpInfo, IpInfoDTO>();
            CreateMap<IpInfoDTO, IpInfo>();
            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>();
            CreateMap<Language, LanguageDTO>();
            CreateMap<LanguageDTO, Language>();
        }
    }
}
