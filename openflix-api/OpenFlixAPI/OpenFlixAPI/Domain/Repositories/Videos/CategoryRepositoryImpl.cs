using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepositoryImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<VideoCategory> GetCategories()
        {
            return _context.VideoCategories;
        }
    }
}
