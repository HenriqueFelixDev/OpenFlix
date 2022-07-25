using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.Repositories.Profiles
{
    public interface IProfileImageRepository
    {
        public IEnumerable<ProfileImage> GetProfileImages();
    }
}
