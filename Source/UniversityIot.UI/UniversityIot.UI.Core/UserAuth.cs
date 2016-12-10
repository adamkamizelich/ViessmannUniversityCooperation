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

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
    }
}