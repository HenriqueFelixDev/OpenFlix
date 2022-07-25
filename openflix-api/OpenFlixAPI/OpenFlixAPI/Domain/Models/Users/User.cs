using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public IEnumerable<Profile> Profiles { get; set; }

        public override string ToString()
        {
            return $"User(Id: {Id}, Username: {Username}, Password: {Password}, Email: {Email}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt})";
        }
    }
}
