using Microsoft.EntityFrameworkCore;
using OpenFlixAPI.Domain.Exceptions;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public class VideoRepositoryImpl : IVideoRepository
    {
        private readonly Context _context;
        public VideoRepositoryImpl(Context context)
        {
            _context = context;
        }

        public IEnumerable<Serie> SearchVideos(string search)
        {
            return _context.Series
                .Include(serie => serie.Videos)
                .Include(serie => serie.Category)
                .Where(serie => 
                    serie.Title.ToLower().Contains(search.ToLower()) || 
                    serie.Videos.Any(video => video.Title.ToLower().Contains(search.ToLower()))
                );
        }

        public Serie GetSerieById(int serieId)
        {
            var serie = _context.Series
                .Include(serie => serie.Category)
                .Include(serie => serie.Videos)
                .FirstOrDefault(serie => serie.Id == serieId);

            if (serie == null)
            {
                throw new ResourceNotFoundException("Série não encontrada");
            }

            return serie;
        }

        public Video GetVideoById(int videoId)
        {
            var video = _context.Videos
                .FirstOrDefault(video => video.Id == videoId);

            if (video == null)
            {
                throw new ResourceNotFoundException("Série não encontrada");
            }

            return video;
        }

        public IEnumerable<CategoryzedVideos> GetCategoryzedVideos()
        {
            var series = _context.VideoCategories
                .Include(category => category.Series)
                .ThenInclude(serie => serie.Videos)
                .Where(category => category.Series.Count() > 0)
                .Select(c => 
                    new CategoryzedVideos(
                        c.Id,
                        c.Name,
                        c.Series.Select(serie => SerieResponse.FromSerieModel(serie))
                    ));

            return series;
        }
    }
}
