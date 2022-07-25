using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.Repositories.Profiles
{
    public class ProfileImageRepositoryImpl : IProfileImageRepository
    {
        private readonly Context _context;
        public ProfileImageRepositoryImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<ProfileImage> GetProfileImages()
        {
            return _context.ProfileImages;
        }
    }
}
