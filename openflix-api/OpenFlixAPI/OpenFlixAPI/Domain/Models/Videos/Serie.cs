namespace OpenFlixAPI.Domain.Models.Videos
{
    public class Serie : VideoResource
    {
        public string Author { get; set; }

        public int CategoryId { get; set; }
        public VideoCategory Category { get; set; }

        public IEnumerable<Video> Videos { get; set; }

        public IEnumerable<Favorite> Favorites { get; set; }

        public override string ToString()
        {
            return $"Serie(Id: {Id}, Title: {Title}, Banner: {Banner}, Author: {Author}, CategoryId: {CategoryId}, Category: {Category}, Videos: {Videos})";
        }
    }
}
