using OpenFlixAPI.Config;

namespace OpenFlixAPI.Domain.Models.Profiles
{
    /// <summary>
    /// Entidade que a API retorna para as imagens de perfil
    /// </summary>
    public class ProfileImageResponse
    {
        /// <summary>
        /// ID da imagem de perfil
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// URL da imagem de perfil
        /// </summary>
        public string ImageName { get; set; }

        public static ProfileImageResponse FromProfileImage(ProfileImage profileImage)
        {
            return new ProfileImageResponse()
            {
                Id = profileImage.Id,
                ImageName = $"{ProjectConfig.PROFILE_IMAGES_URL}/{profileImage.ImageName}"
            };
        }
    }
}