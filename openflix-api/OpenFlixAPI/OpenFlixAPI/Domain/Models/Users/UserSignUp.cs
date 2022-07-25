using System.ComponentModel.DataAnnotations;

namespace OpenFlixAPI.Domain.Models.Users
{
    /// <summary>
    /// Dados de entrada do usuário
    /// </summary>
    public class UserSignUp
    {
        /// <summary>
        /// Nome de usuário
        /// </summary>
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome de usuário precisa ter pelo menos 3 caracteres")]
        [MaxLength(32, ErrorMessage = "O nome de usuário deve ter no máximo 32 caracteres")]
        public string Username { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha precisa ter pelo menos 6 caracteres")]
        [MaxLength(255, ErrorMessage = "A senha deve ter no máximo 255 caracteres")]
        public string Password { get; set; }

        /// <summary>
        /// E-mail do usuário
        /// </summary>
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(3, ErrorMessage = "O E-mail precisa ter pelo menos 3 caracteres")]
        [MaxLength(128, ErrorMessage = "O E-mail deve ter no máximo 128 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
