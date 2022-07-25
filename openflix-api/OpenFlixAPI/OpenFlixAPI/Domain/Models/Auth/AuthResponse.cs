namespace OpenFlixAPI.Domain.Models.Auth
{
    /// <summary>
    /// Entidade de resposta aos métodos de autenticação (login e signup)
    /// </summary>
    public class AuthResponse
    {
        public AuthResponse(string token)
        {
            Token = token;
        }

        /// <summary>
        /// JWT com os dados do usuário autenticado
        /// </summary>
        public string Token { get; set; }
    }
}
