using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.Repositories.Profiles
{
    public interface IProfileRepository
    {
        public int CreateProfile(Models.Profiles.Profile profile);
        public void UpdateProfile(Models.Profiles.Profile profile, int userId);
        public void DeleteProfile(int profileId, int userId);
        public IEnumerable<Models.Profiles.Profile> GetUserProfiles(int userId);
        public Models.Profiles.Profile GetProfileById(int profileId, int userId);
    }
}
