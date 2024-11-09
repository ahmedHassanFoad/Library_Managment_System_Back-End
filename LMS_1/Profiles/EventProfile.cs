using AutoMapper;
using LMS_1.Dtos;
using LMS_1.Entity;

namespace LMS_1.Profiles
{
    public class EventProfile :Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
           .ReverseMap();
        }
    }
}
