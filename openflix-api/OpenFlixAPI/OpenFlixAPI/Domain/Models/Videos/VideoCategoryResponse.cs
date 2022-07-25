namespace OpenFlixAPI.Domain.Models.Videos
{
    /// <summary>
    /// Entidade que a API retorna as categorias das séries
    /// </summary>
    public class VideoCategoryResponse
    {
        /// <summary>
        /// ID da categoria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Name { get; set; }

        public static VideoCategoryResponse FromVideoCategory(VideoCategory videoCategory)
        {
            return new VideoCategoryResponse()
            {
                Id = videoCategory.Id,
                Name = videoCategory.Name
            };
        }
    }
}
