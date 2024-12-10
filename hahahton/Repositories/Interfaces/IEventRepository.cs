using hahahton.Dtos;
using hahahton.Models;

// IEventRepository.cs
namespace hahahton.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task UpdateEventAsync(Event events);
        Task AddEventAsync(Event events);
        Task DeleteEventAsync(int id);
    }
}

