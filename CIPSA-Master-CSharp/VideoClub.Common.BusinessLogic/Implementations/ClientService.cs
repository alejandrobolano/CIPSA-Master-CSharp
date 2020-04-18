using System;
using System.Collections.Generic;
using System.Linq;
using VideoClub.Common.BusinessLogic.Contracts;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Models;

namespace VideoClub.Common.BusinessLogic.Implementations
{
    public class ClientService : IClientService
    {
        public void UpdateClientsForVip(List<Client> clients)
        {
            clients.ForEach(client =>
            {
                if (client.RentalQuantity >= 60)
                {
                    client.IsVip = true;
                }
            });
        }

        public List<Client> GetClientsByState(List<Client> clients, StateClientEnum stateClient)
        {
            var activatedClients = new List<Client>();
            clients.ForEach(client =>
            {
                if (client.State.Equals(stateClient))
                {
                    activatedClients.Add(client);
                }
            });

            return activatedClients;
        }
    }
}
