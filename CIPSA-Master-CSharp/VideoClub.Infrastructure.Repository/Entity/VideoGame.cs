using System;
using System.ComponentModel.DataAnnotations;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Utils;

namespace VideoClub.Infrastructure.Repository.Entity
{
    public class VideoGame : Product
    {
        [Required]
        public GamePlatformEnum Platform { get; set; }

    }
}
