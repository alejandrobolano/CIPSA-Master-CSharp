using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.BusinessLogic.Contracts;

namespace VideoClub.Core.BusinessLogic.Implementations
{
    public class ClientService : IClientService
    {
        public void UpdateClientsForVip()
        {
            throw new NotImplementedException();
        }

        public static string GetVoucherNumber(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

            return result;
        }
    }
}
