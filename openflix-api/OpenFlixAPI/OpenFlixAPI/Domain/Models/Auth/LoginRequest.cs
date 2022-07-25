namespace OpenFlixAPI.Domain.Models.Auth
{
    /// <summary>
    /// Entidade enviada no request de login
    /// </summary>
    public class LoginRequest
    {
        public LoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
        /// <summary>
        /// Nome de usuário cadastrado
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Senha do usuário cadastrado
        /// </summary>
        public string Password { get; set; }
    }
}
