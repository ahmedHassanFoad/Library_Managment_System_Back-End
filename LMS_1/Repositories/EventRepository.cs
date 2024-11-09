using AutoMapper;
using LMS_1.Data;
using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Interfaces;
using Microsoft.Extensions.Logging;

namespace LMS_1.Repositories
{
    public class EventRepository : IEventRepsitory
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;
        public EventRepository(LMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateEvent(Event _event)
        {
            await _context.Events.AddAsync(_event);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(int EventId)
        {
            var contact = await _context.Events.FindAsync(EventId);
            if (contact != null)
            {
                _context.Events.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEvent(Event _event)
        {
           
            _context.Events.Update(_event);
            await _context.SaveChangesAsync();
        }
    }
}
