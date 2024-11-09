using AutoMapper;
using LMS_1.Dtos;
using LMS_1.Entity;

namespace LMS_1.Profiles
{
    public class CatagoryProfile : Profile
    {
        public CatagoryProfile() 
        {
            CreateMap<Catagory, categoryDto>()
           .ReverseMap();
        }
    }
}
