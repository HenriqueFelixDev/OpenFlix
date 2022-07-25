namespace OpenFlixAPI.Domain.Models.Videos
{
    public class VideoCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Serie> Series { get; set; }
    }
}
