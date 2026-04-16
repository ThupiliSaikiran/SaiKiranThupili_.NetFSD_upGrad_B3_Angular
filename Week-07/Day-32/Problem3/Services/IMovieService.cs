using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();

        Movie GetMovieById(int Id);

        void Add(Movie movie);

        void Edit(Movie movie);

        void Delete(Movie movie);
    }
}
