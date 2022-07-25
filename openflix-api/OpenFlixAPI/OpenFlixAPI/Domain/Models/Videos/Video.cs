namespace OpenFlixAPI.Domain.Models.Videos
{
    public class Video : VideoResource
    {
        public int Duration { get; set; }
        public string Url { get; set; }

        public int SerieId { get; set; }
        public Serie Serie { get; set; }

        public override string ToString()
        {
            return $"Video(Id: {Id}, Title: {Title}, Banner: {Banner}, Duration: {Duration}, Url: {Url}, SerieId: {SerieId}, Serie: {Serie})";
        }
    }
}
