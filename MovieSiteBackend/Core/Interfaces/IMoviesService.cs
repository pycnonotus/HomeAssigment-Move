using Domain.Entities;

namespace Core.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetAllAsync();

        Task<IEnumerable<Movie>> GetAllByActorNameAsync(string actorName);

        Task<IEnumerable<int>> GetYearsAsync();

        Task RenameTitleAsync(string id, string newTitle);

        Task DeleteAsync(string id);
    }
}