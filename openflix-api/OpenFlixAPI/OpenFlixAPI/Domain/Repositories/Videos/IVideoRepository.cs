using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public interface IVideoRepository
    {
        public IEnumerable<Serie> SearchVideos(string search);
        public Serie GetSerieById(int serieId);
        public Video GetVideoById(int videoId);
        public IEnumerable<CategoryzedVideos> GetCategoryzedVideos();
    }
}
