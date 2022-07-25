using Microsoft.IdentityModel.Tokens;
using OpenFlixAPI.Domain.Exceptions;
using OpenFlixAPI.Domain.Models.Auth;
using OpenFlixAPI.Domain.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpenFlixAPI.Services.Auth
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthServiceImpl(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string CreateJWT(User user)
        {
            var secret = Encoding.ASCII.GetBytes(_config.GetSection("JwtConfiguration:Secret").Value);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public LoginRequest DecodeBasicToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new AuthenticationException(
                    AuthenticationException.INVALID_AUTH_DATA,
                    "Basic Token é obrigatório!"
                );
            }

            try
            {
                token = token.Replace("Basic ", "");

                // Caso o Basic Token não esteja em um formato base64 válido,
                // Então essa linha lançará uma FormatException
                var authenticationDataBytes = Convert.FromBase64String(token);

                // Separa as informações do token que vem no formato usuario:senha em um array
                // de 2 elementos, sendo o primeiro o nome de usuário e o segundo a senha.
                var authenticationData = Encoding.UTF8.GetString(authenticationDataBytes).Split(":");

                // Caso os dados do Basic Token não estejam no formato usuario:senha,
                // Então essa linha lançará uma IndexOutOfRangeException, pois o split
                // da linha anterior não retornará um array de 2 elementos
                return new LoginRequest(authenticationData[0], authenticationData[1]);
            } catch (FormatException)
            {
                throw new AuthenticationException(AuthenticationException.INVALID_AUTH_DATA, "Basic Token não é um Base64 válido");
            } catch (IndexOutOfRangeException)
            {
                throw new AuthenticationException(AuthenticationException.INVALID_AUTH_DATA, "Formato dos dados de autenticação inválido. Formato desejado: usuario:senha");
            }
        }
    }
}
