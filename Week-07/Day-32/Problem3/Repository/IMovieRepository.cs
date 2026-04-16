using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public interface IMovieRepository
    {
        List<Movie> ShowMovies();

        Movie GetById(int Id);

        void AddMovie(Movie movie);

        void EditMovie(Movie movie);

        void DeleteMovie(Movie movie);

    }
}
