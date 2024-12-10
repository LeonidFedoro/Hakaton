// EventService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using hahahton.Models;
using hahahton.Repositories;

namespace hahahton.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<Event> GetEventByIdAsync(int id)
        {
            return _eventRepository.GetEventByIdAsync(id);
        }

        public Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return _eventRepository.GetAllEventsAsync();
        }

        public Task AddEventAsync(Event events)
        {
            return _eventRepository.AddEventAsync(events);
        }

        public Task UpdateEventAsync(Event events)
        {
            return _eventRepository.UpdateEventAsync(events);
        }

        public Task DeleteEventAsync(int id)
        {
            return _eventRepository.DeleteEventAsync(id);
        }
    }
}
