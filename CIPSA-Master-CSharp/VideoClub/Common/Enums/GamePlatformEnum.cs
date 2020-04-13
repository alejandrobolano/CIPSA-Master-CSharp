using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Common.Enums
{
    public enum GamePlatformEnum
    {
        [Description("PC")]
        Pc,
        [Description("XBOX")]
        XBox,
        [Description("Playstation 2")]
        Ps2,
        [Description("Playstation 3")]
        Ps3,
        [Description("Wii")]
        Wii
    }
}
