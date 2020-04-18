using System.ComponentModel;

namespace VideoClub.Common.Model.Enums
{
    public enum StateProductEnum
    {
        [Description("No disponible")]
        NonAvailable,
        [Description("Disponible")]
        Available,
        [Description("Perdido")]
        Lost,
        [Description("Mal Estado")]
        BadState
    }
}
