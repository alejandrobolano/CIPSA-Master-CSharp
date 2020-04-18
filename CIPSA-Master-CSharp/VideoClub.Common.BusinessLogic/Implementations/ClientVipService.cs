using VideoClub.Common.BusinessLogic.Contracts;
using VideoClub.Common.Model.Models;

namespace VideoClub.Common.BusinessLogic.Implementations
{
    public class ClientVipService : IClientVipService
    {
        public void UpdateDiscount(ClientVip client)
        {
            var quantityRentalMonth = 0; //Change this
            switch (quantityRentalMonth)
            {
                case 5:
                    client.Discount = 10;
                    break;
                case 10:
                    client.Discount = 15;
                    break;
                case 15:
                    client.Discount = 20;
                    break;
                case 20:
                    client.Discount = 25;
                    break;
                case 30:
                    client.Discount = 50;
                    break;
            }
        }
    }
}
