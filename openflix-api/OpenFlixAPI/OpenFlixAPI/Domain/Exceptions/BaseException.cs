namespace OpenFlixAPI.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(int code, string message) : base(message)
        {
            Code = code;
        }

        public int Code { get; set; }
    }
}
