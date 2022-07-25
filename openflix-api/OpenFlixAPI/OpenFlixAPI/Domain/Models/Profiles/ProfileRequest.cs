using System.ComponentModel.DataAnnotations;

namespace OpenFlixAPI.Domain.Models.Profiles
{
    /// <summary>
    /// Dados de entrada do perfil
    /// </summary>
    public class ProfileRequest
    {
        /// <summary>
        /// Nome do perfil
        /// </summary>
        [Required(ErrorMessage = "O nome do perfil é obrigatório")]
        [MaxLength(32, ErrorMessage = "O tamanho máximo do nome do perfil é 32 caracteres")]
        public string Name { get; set; }

        /// <summary>
        /// ID da imagem de perfil
        /// </summary>
        [Required(ErrorMessage = "A imagem do perfil é obrigatória")]
        public int ImageId { get; set; }
    }
}
