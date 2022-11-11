using AutoMapper;
using BusnessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusnessLogic.Helpers
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Laptop, LaptopDTO>()
                .ForMember(dest => dest.MemoryName,
                           opt => opt.MapFrom(src => src.Memory.Name));
            CreateMap<LaptopDTO, Laptop>();
        }
    }
}