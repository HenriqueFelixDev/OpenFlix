namespace OpenFlixAPI.Domain.Models.Videos
{
    /// <summary>
    /// Entidade que a API retorna os vídeos organizados por categorias
    /// </summary>
    public class CategoryzedVideos
    {
        public CategoryzedVideos(int categoryId, string categoryName, IEnumerable<SerieResponse> series)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Series = series;
        }

        /// <summary>
        /// ID da categoria
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Lista de séries pertencentes à categoria
        /// </summary>
        public IEnumerable<SerieResponse> Series { get; set; }
    }
}
