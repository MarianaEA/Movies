using API.J.Movies.DAL.Dtos.Category;
using API.J.Movies.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.J.Movies.Controllers
{
   
  
        [Route("api/[controller]")]
        [ApiController]
        public class MovieController : ControllerBase
        {
            private readonly IMovieService _movieService;

            public MovieController(IMovieService movieService)
            {
                _movieService = movieService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync()
            {
                return Ok(await _movieService.GetMoviesAsync());
            }

            [HttpGet("{id:int}", Name = "GetMovieAsync")]
            public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
            {
                try
                {
                    return Ok(await _movieService.GetMovieAsync(id));
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound(new { ex.Message });
                }
            }

            [HttpPost(Name = "CreateMovieAsync")]
            public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieCreateUpdateDto dto)
            {
                try
                {
                    var movie = await _movieService.CreateMovieAsync(dto);
                    return CreatedAtRoute("GetMovieAsync", new { id = movie.Id }, movie);
                }
                catch (InvalidOperationException ex)
                {
                    return Conflict(new { ex.Message });
                }
            }

            [HttpPut("{id:int}", Name = "UpdateMovieAsync")]
            public async Task<ActionResult<MovieDto>> UpdateMovieAsync(int id, [FromBody] MovieCreateUpdateDto dto)
            {
                try
                {
                    return Ok(await _movieService.UpdateMovieAsync(dto, id));
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound(new { ex.Message });
                }
            }

            [HttpDelete("{id:int}", Name = "DeleteMovieAsync")]
            public async Task<ActionResult> DeleteMovieAsync(int id)
            {
                try
                {
                    var deleted = await _movieService.DeleteMovieAsync(id);
                    return Ok(deleted);
                }
                catch (InvalidOperationException ex)
                {
                    return NotFound(new { ex.Message });
                }
            }
        }
    
}
