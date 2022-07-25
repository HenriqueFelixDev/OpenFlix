using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public interface ICategoryRepository
    {
        public IEnumerable<VideoCategory> GetCategories();
    }
}
