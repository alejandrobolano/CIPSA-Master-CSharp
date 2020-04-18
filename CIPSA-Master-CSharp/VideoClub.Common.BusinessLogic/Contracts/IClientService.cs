using System.Collections.Generic;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Models;

namespace VideoClub.Common.BusinessLogic.Contracts
{
    public interface IClientService
    {
        void UpdateClientsForVip(List<Client> clients);

        List<Client> GetClientsByState(List<Client> clients, StateClientEnum stateClient);
    }
}
