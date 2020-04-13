using CIPSA_CSharp_Module11.Extensions;
using CIPSA_CSharp_Module11.Extra.Enum;

namespace CIPSA_CSharp_Module11.Extra.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public AccreditationEnum Accreditation { get; set; }
        public string AccreditationAlphaNumber { get; set; }
        public SexEnum Sex { get; set; }

        public Person(string name, string lastName, string email, int phoneNumber,
            AccreditationEnum accreditation, string accreditationAlphaNumber, SexEnum sex)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Accreditation = accreditation;
            AccreditationAlphaNumber = accreditationAlphaNumber;
            Sex = sex;
        }

        public override string ToString()
        {
            return $" Nombre completo: {Name} {LastName}" +
                   $"\t Correo electrónico: {Email}" +
                   $"\t Teléfono: {PhoneNumber}" +
                   $"\t {Accreditation.GetDescription()}: {AccreditationAlphaNumber}" +
                   $"\t Sexo: {Sex.GetDescription()}";
        }
    }
}
