using OpenFlixAPI.Config;

namespace OpenFlixAPI.Domain.Models.Videos
{
    /// <summary>
    /// Entidade que a API retorna os vídeos das séries
    /// </summary>
    public class VideoResponse
    {
        /// <summary>
        /// ID do vídeo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título do vídeo
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// URL da imagem de capa do vídeo
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Duração (em segundos) do vídeo
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// URL do vídeo
        /// </summary>
        public string Url { get; set; }

        public static VideoResponse FromVideoModel(Video video)
        {
            return new VideoResponse()
            {
                Id = video.Id,
                Title = video.Title,
                Banner = $"{ProjectConfig.BANNERS_URL}/{video.Banner}",
                Duration = video.Duration,
                Url = video.Url 
            };
        }
    }
}
