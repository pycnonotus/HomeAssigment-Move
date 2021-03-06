using AutoMapper;
using Core.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services;

public class MoviesServiceServices : IMoviesService
{
    private readonly Task<List<MovieJson>> _movies; 
    // the same task will always be returned, so it will be the same pointer the same list allways. 
    private readonly IMapper _mapper;
    
    public MoviesServiceServices(HttpClient client, IMapper mapper)
    {
        _movies = MoviesFetcher.GetMoviesAsync(client);
        _mapper = mapper;

    }
    
    
    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<Movie>>(await _movies).OrderByDescending(x => x.Year);
    }
    
    public async Task<IEnumerable<Movie>> GetAllByActorNameAsync(string actorName)
    {
        actorName = actorName.ToLower();
        var movies = (await _movies).Where(x =>
            x.Principals?.Any(p => p.Name?.ToLower().Contains(actorName) ?? false )
            ??false);
        return _mapper.Map<IEnumerable<Movie>>(movies).OrderByDescending(x => x.Title);
    }

    public async Task<IEnumerable<int>> GetYearsAsync()
    {
        return (await _movies).Select(x => x.Year).Distinct().OrderByDescending(x => x);
    }

    public async Task RenameTitleAsync(string id, string newTitle)
    {
        id = $"/title/{id}/";
        var movie = (await _movies).FirstOrDefault(x => x.Id == id);
        if(movie is null) throw new KeyNotFoundException("Movie not found");
        movie.Title = newTitle;
    }

    public async Task DeleteAsync(string id)
    {
        id = $"/title/{id}/";
        var movie = (await _movies).FirstOrDefault(x => x.Id == id);
        if(movie is null) throw new KeyNotFoundException("Movie not found");
        var movies = (await _movies).Remove(movie);
    }
    
}
