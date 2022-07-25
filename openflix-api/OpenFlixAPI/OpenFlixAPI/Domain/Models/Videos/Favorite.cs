using OpenFlixAPI.Domain.Models.Profiles;
using OpenFlixAPI.Domain.Models.Users;

namespace OpenFlixAPI.Domain.Models.Videos
{
    public class Favorite
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Serie> Series { get; set; }

        public override string ToString()
        {
            return $"Favorite(Id: {Id}, ProfileId: {ProfileId}, Profile: {Profile}, UserId: {UserId}, User: {User}, Series: {Series})";
        }
    }
}
