using API.J.Movies.DAL.Dtos.Category;

namespace API.J.Movies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto dto);
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id);
        Task<bool> DeleteMovieAsync(int id);
    }
}
