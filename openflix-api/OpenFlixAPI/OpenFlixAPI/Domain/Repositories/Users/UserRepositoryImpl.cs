namespace OpenFlixAPI.Domain.Repositories.Users
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly Context _context;
        public UserRepositoryImpl(Context context)
        {
            _context = context;
        }

        public Models.Users.User? GetUserByUsername(string username)
        {
            return _context.Users
                .FirstOrDefault(user => user.Username.Equals(username));
        }

        public void CreateUser(Models.Users.User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
