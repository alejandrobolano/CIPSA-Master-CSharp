using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoClub.BusinessLogic.Implementations;
using VideoClub.Common.Enums;
using VideoClub.Common.Exceptions;

namespace VideoClub.Common.Models
{
    public class Client
    {
        #region Private properties

        private string _name;
        private string _lastName;
        private string _phoneContact;
        private string _phoneAux;

        #endregion

        #region Public properties
        public string Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                Validations.ValidateStringClient(value);
                _name = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                Validations.ValidateStringClient(value);
                _lastName = value;
            }
        }
        public string Address { get; set; }
        public AccreditationEnum AccreditationType { get; set; }
        public string Accreditation { get; set; }

        public string PhoneContact
        {
            get => _phoneContact;
            set
            {
                Validations.ValidatePhoneNumberClient(value);
                _phoneContact = value;
            }
        }

        public string PhoneAux
        {
            get => _phoneAux;
            set
            {
                Validations.ValidatePhoneNumberClient(value);
                _phoneAux = value;
            }
        }
        public string Email { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public StateClientEnum State { get; set; }
        public int RentalQuantity { get; set; }
        public bool IsVip { get; set; }

        #endregion

        public Client()
        {
            var random = new Random();
            Id = GetVoucherNumber(6,random);
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
