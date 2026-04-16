using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repo)
        {
            _repo = repo; 
        }

        public List<Movie> GetAllMovies()
        {
            return _repo.ShowMovies();
        }

        public Movie GetMovieById(int Id)
        {
            return _repo.GetById(Id);
        }

        public void Add(Movie movie)
        {
            _repo.AddMovie(movie);
        }

        public void Edit(Movie movie)
        {
            _repo.EditMovie(movie);
        }

        public void Delete(Movie movie)
        {
            _repo.DeleteMovie(movie);
        }
    }
}
