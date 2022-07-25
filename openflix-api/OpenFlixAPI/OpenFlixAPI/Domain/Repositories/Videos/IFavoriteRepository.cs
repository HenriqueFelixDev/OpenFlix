using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public interface IFavoriteRepository
    {
        public void CreateFavorites(Favorite favorite);
        public Favorite GetProfileFavorites(int profileId, int userId);
        public void AddToFavorites(int serieId, int profileId, int userId);
        public void RemoveFromFavorites(int serieId, int profileId, int userId);
    }
}
