using OpenFlixAPI.Domain.Models.Auth;
using OpenFlixAPI.Domain.Models.Users;

namespace OpenFlixAPI.Services.Auth
{
    public interface IAuthService
    {
        public LoginRequest DecodeBasicToken(string token);
        public string CreateJWT(User user);
    }
}
