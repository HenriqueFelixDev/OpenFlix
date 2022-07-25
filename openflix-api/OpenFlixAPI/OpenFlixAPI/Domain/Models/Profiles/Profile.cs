using OpenFlixAPI.Domain.Models.Users;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Models.Profiles
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProfileImage ProfileImage { get; set; }
        public int ProfileImageId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Favorite Favorite { get; set; }
    }
}
