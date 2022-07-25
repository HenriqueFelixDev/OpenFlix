namespace OpenFlixAPI.Domain.Models.Profiles
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }

        public List<Profile> Profiles { get; set; }
    }
}
