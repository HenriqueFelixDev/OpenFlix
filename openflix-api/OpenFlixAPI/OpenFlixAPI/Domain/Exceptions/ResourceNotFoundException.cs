namespace OpenFlixAPI.Domain.Exceptions
{
    public class ResourceNotFoundException : BaseException
    {
        public ResourceNotFoundException(string message) : base(404, message) { }
    }
}
