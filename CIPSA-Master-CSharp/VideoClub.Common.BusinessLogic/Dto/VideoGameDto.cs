using System;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Utils;

namespace VideoClub.Common.BusinessLogic.Dto
{
    public class VideoGameDto : ProductDto
    {
        public GamePlatformEnum Platform { get; set; }

        public VideoGameDto()
        {
            var random = new Random();
            Id = Helper.GetCodeNumber(Helper.VideoGame, 6, random);
        }
    }
}
