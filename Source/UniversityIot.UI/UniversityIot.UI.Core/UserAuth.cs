namespace UniversityIot.UI.Core
{
    public class UserAuth : IUserAuth
    {
        public UserAuth(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public int Id { get; }
        public string Name { get; }
        public string Password { get; }
    }
}