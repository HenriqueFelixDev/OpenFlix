namespace OpenFlixAPI.Domain.Models.Profiles
{
    /// <summary>
    /// Entidade que a API retorna para os perfis de usuário
    /// </summary>
    public class ProfileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProfileImageResponse ProfileImage { get; set; }

        public static ProfileResponse FromProfileModel(Profile profile)
        {
            return new ProfileResponse()
            {
                Id = profile.Id,
                Name = profile.Name,
                ProfileImage = ProfileImageResponse.FromProfileImage(profile.ProfileImage)
            };
        }
    }
}
