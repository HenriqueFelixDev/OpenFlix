namespace OpenFlixAPI.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        public Models.Users.User? GetUserByUsername(string username);
        public void CreateUser(Models.Users.User user);
    }
}
