using System.ComponentModel;

namespace CIPSA_CSharp_Module11.Extra.Enum
{
    public enum AccreditationEnum
    {
        [Description("DNI")]
        Dni,
        [Description("NIE")]
        Nie,
        [Description("Pasaporte")]
        Passport,
        [Description("Carnet de conducir")]
        DriverLicense,
    }
}
