using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Models;

namespace VideoClub.Common.BusinessLogic.Contracts
{
    public interface IMovieService
    {
        void ChangeState(Movie movie, StateProductEnum state);
    }
}
