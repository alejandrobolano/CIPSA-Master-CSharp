using System;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Utils;

namespace VideoClub.Common.Model.Models
{
    public class VideoGame : Product
    {
        public GamePlatformEnum Platform { get; set; }

        public VideoGame()
        {
            var random = new Random();
            Id = Helper.GetCodeNumber(Helper.VideoGame, 6, random);
        }
    }
}
