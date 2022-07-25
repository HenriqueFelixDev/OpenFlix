using Microsoft.EntityFrameworkCore;
using OpenFlixAPI.Domain.Exceptions;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories.Videos
{
    public class FavoriteRepositoryImpl : IFavoriteRepository
    {
        private delegate void OnFavoriteSeriesChange(List<Serie> series, Serie serie);

        private readonly Context _context;
        public FavoriteRepositoryImpl(Context context)
        {
            _context = context;
        }

        public void CreateFavorites(Favorite favorite)
        {
            _context.Add(favorite);
            _context.SaveChanges();
        }

        public Favorite GetProfileFavorites(int profileId, int userId)
        {
            var favorite = _context.Favorites
                .Include(favorite => favorite.Series)
                .ThenInclude(serie => serie.Videos)
                .FirstOrDefault(favorite => favorite.ProfileId == profileId && favorite.UserId == userId);

            if (favorite == null)
            {
                throw new ResourceNotFoundException("Favoritos do perfil não encontrados");
            }

            return favorite;
        }

        public void AddToFavorites(int serieId, int profileId, int userId)
        {
            _updateFavoriteSeries(
                serieId,
                profileId,
                userId,
                (series, currentSerie) => series.Add(currentSerie)
            );
        }

        public void RemoveFromFavorites(int serieId, int profileId, int userId)
        {
            _updateFavoriteSeries(
                serieId,
                profileId,
                userId,
                (series, currentSerie) => series.Remove(currentSerie)
            );
        }

        private void _updateFavoriteSeries(int serieId, int profileId, int userId, OnFavoriteSeriesChange onChange)
        {
            var serie = _context.Series.Find(serieId);
            var favorite = _context.Favorites
                .Include(favorite => favorite.Series)
                .FirstOrDefault(favorite => favorite.ProfileId == profileId && favorite.UserId == userId);

            if (serie == null)
            {
                throw new ResourceNotFoundException("A série que você está tentando adicionar aos favoritos não existe");
            }

            if (favorite == null)
            {
                throw new ResourceNotFoundException("Favoritos do perfil não encontrados");
            }

            var newFavoriteSeries = new List<Serie>(favorite.Series);
            onChange.Invoke(newFavoriteSeries, serie);

            favorite.Series = newFavoriteSeries;
            _context.Entry(favorite).Collection(p => p.Series).IsModified = true;
            _context.SaveChanges();
        }
    }
}
