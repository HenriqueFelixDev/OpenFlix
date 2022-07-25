namespace OpenFlixAPI.Domain.Exceptions
{
    public class AuthenticationException : BaseException
    {
        public AuthenticationException(int code, string message) 
            : base(code, message) { }

        public static readonly int INVALID_AUTH_DATA = 400;
        public static readonly int INVALID_TOKEN = 401;
    }
}
