namespace OpenFlixAPI.Domain.Models.Errors
{
    public class ValidationError
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Dictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}
