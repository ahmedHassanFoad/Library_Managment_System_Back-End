using AutoMapper;
using LMS_1.Dtos;
using LMS_1.Entity;

namespace LMS_1.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
           .ReverseMap();
        }
    }
}
