using Movies.Client2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movies.Client2.Models.Movie>> GetMovies();
        Task<Movies.Client2.Models.Movie> GetMovie(string id);
        Task<Movies.Client2.Models.Movie> CreateMovie(Movies.Client2.Models.Movie movie);
        Task<Movies.Client2.Models.Movie> UpdateMovie(Movies.Client2.Models.Movie movie);
        Task DeleteMovie(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
