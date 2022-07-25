namespace OpenFlixAPI.Services.Password
{
    public interface IPasswordService
    {
        public string EncryptPassword(string password);
        public bool VerifyPassword(string hash, string password);
    }
}
