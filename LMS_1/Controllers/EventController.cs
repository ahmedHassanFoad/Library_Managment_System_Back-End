using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Interfaces;
using LMS_1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepsitory _eventRepsitory;
        public EventController(IEventRepsitory eventRepsitory)
        {
            _eventRepsitory = eventRepsitory;
        }
        [HttpPost("CreateEvent")]
        public async Task<IActionResult>  CreateEvent(Event _event)
        {
            if (_event == null)
            {
                return BadRequest("Book data is null.");
            }
            await _eventRepsitory.CreateEvent(_event);

            return Ok("Book added successfully.");

        }
        [HttpDelete("DeleteeventById")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            await _eventRepsitory.DeleteEvent(eventId);
            return Ok("Event deleted successfully.");
        }
        [HttpPut("UpdateeventById")]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] Event updatedEvent)
        {
            // Check if the event IDs match
            if (eventId != updatedEvent.Id)
            {
                return BadRequest("Event ID mismatch.");
            }

            // Call the repository method to update the event
            await _eventRepsitory.UpdateEvent(updatedEvent);

            return Ok("Event updated successfully.");
        }
    }
}
