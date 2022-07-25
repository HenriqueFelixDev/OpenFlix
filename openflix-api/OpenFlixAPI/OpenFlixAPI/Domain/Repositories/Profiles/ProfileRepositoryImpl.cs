using Microsoft.EntityFrameworkCore;
using OpenFlixAPI.Domain.Exceptions;
using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.Repositories.Profiles
{
    public class ProfileRepositoryImpl : IProfileRepository
    {
        private readonly Context _context;

        public ProfileRepositoryImpl(Context context)
        {
            _context = context;
        }

        public int CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return profile.Id;
        }

        public void DeleteProfile(int profileId, int userId)
        {
            var profile = _context.Profiles.Find(profileId);

            if (profile == null || profile.UserId != userId)
            {
                throw new ResourceNotFoundException("Perfil não encontrado");
            }

            _context.Profiles.Remove(profile);
            _context.SaveChanges();
        }

        public IEnumerable<Profile> GetUserProfiles(int userId)
        {
            return _context.Profiles
                .Where(profile => profile.UserId == userId)
                .Include(p => p.ProfileImage);
        }

        public Profile GetProfileById(int profileId, int userId)
        {
            var profile = _context.Profiles
                .Include(p => p.ProfileImage)
                .FirstOrDefault(p => p.Id == profileId && p.UserId == userId);

            if (profile == null)
            {
                throw new ResourceNotFoundException("Perfil não encontrado");
            }

            return profile;
        }

        public void UpdateProfile(Profile profile, int userId)
        {
            var dbProfile = _context.Profiles.Find(profile.Id);

            if (dbProfile == null || dbProfile.UserId != userId)
            {
                throw new ResourceNotFoundException("Perfil não encontrado");
            }

            dbProfile.Name = profile.Name;
            dbProfile.ProfileImageId = profile.ProfileImageId;
            _context.SaveChanges();
        }
    }
}
