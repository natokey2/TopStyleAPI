using System;
using AutoMapper;
using TopStyleAPI.Repos.Dto;
using TopStyleAPI.Repos.Entities;

namespace TopStyleAPI.Repos.Profiles
{
    public class CustomerProfile : Profile
    {


        public CustomerProfile()
        {

            //En mappningsklass som används för att mappa customer med
            //Med customerResponseDto

            CreateMap<Customer, CustomerResponseDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }

    }
}

