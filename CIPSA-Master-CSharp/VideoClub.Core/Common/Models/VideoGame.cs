using System;
using VideoClub.Core.Common.Enums;

namespace VideoClub.Core.Common.Models
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
