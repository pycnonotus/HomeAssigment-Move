using API.Dtos;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class MoviesController : Controller
{
    private readonly IMoviesService _movieService;

    public MoviesController(IMoviesService movieService) : base()
    {
        _movieService = movieService;
    }

    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllAsync()
    {
        return Ok(await _movieService.GetAllAsync());
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllByActorAsync(string name)
    {
        return Ok(await _movieService.GetAllByActorNameAsync(name));
    }
    
    [HttpGet("years")]
    public async Task<ActionResult<IEnumerable<int>>> GetYearsAsync()
    {
        return Ok(await _movieService.GetYearsAsync());
    }

    [HttpPatch("{id}/rename")]
    public async Task<IActionResult> RenameAsync([FromBody]RenameMovieDto rename, string id)
    {
        try
        {
            await _movieService.RenameTitleAsync(id, rename.Name);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>  DeleteAsync(string id)
    {
        try{
            await _movieService.DeleteAsync(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
