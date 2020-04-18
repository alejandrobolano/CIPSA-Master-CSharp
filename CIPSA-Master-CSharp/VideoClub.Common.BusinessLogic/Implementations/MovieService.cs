using VideoClub.Common.BusinessLogic.Contracts;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Models;

namespace VideoClub.Common.BusinessLogic.Implementations
{
    class MovieService : IMovieService
    {
        public void ChangeState(Movie movie, StateProductEnum state)
        {
            movie.State = state;
        }
    }
}
