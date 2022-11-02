using Application.DataTransfer;
using AutoMapper;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForAuthenticationDto, User>();    
        }
    }
}
