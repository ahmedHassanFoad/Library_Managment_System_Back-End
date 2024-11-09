using LMS_1.Entity;

namespace LMS_1.Interfaces
{
    public interface IEventRepsitory
    {
        Task CreateEvent(Event _event);
        Task UpdateEvent(Event _event);
        Task DeleteEvent(int EventId);

    }
}
