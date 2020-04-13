using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Common.Enums;

namespace VideoClub.Common.Models
{
    public class VideoGame : Product
    {
        public GamePlatformEnum Platform { get; set; }

        public VideoGame()
        {
            Id = new Guid();
        }
    }
}
