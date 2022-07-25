using OpenFlixAPI.Config;

namespace OpenFlixAPI.Domain.Models.Videos
{
    public class SerieResponse
    {
        /// <summary>
        /// ID da série
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título da série
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// URL da imagem de capa da série
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Autor da série
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///  Categoria da série
        /// </summary>
        public VideoCategoryResponse? Category { get; set; }

        /// <summary>
        /// Vídeos da série
        /// </summary>
        public IEnumerable<VideoResponse> Videos { get; set; }

        public static SerieResponse FromSerieModel(Serie serie)
        {
            return new SerieResponse()
            {
                Id = serie.Id,
                Title = serie.Title,
                Banner = $"{ProjectConfig.BANNERS_URL}/{serie.Banner}",
                Author = serie.Author,
                Category = serie.Category != null
                    ? VideoCategoryResponse.FromVideoCategory(serie.Category)
                    : null,
                Videos = serie.Videos?.Select(video => VideoResponse.FromVideoModel(video)) 
                    ?? new List<VideoResponse>()
            };
        }
    }
}
