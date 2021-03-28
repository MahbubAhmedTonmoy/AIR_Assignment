using Application.Command;
using AutoMapper;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightCreateCommand>().ReverseMap();
        }
    }
}
