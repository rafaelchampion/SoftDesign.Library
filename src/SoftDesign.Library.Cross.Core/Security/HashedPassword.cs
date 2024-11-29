namespace SoftDesign.Library.Cross.Core.Security
{
    public class HashedPassword
    {
        public string Password { get; }
        public string Salt { get; }
        
        public HashedPassword(string password, string salt)
        {
            Password = password;
            Salt = salt;
        }
    }
}