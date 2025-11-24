using API.J.Movies.DAL.Dtos.Category;
using API.J.Movies.DAL.Models;
using API.J.Movies.Repository.IRepository;
using API.J.Movies.Services.IServices;
using AutoMapper;

namespace API.J.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        private async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            if (movie == null)
                throw new InvalidOperationException($"No se encontró la película con ID '{id}'");
            return movie;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto dto)
        {
            var exists = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (exists)
                throw new InvalidOperationException($"Ya existe una película llamada '{dto.Name}'");

            var movie = _mapper.Map<Movie>(dto);

            var created = await _movieRepository.CreateMovieAsync(movie);
            if (!created)
                throw new Exception("No se pudo crear la película.");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            var movie = await GetMovieByIdAsync(id);

            var exists = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (exists && movie.Name != dto.Name)
                throw new InvalidOperationException($"Ya existe una película con el nombre '{dto.Name}'");

            _mapper.Map(dto, movie);

            var updated = await _movieRepository.UpdateMovieAsync(movie);
            if (!updated)
                throw new Exception("No se pudo actualizar la película.");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);

            var deleted = await _movieRepository.DeleteMovieAsync(id);
            if (!deleted)
                throw new Exception("No se pudo eliminar la película.");

            return deleted;
        }
    }
}
