namespace UniversityIot.DataAccess.Authentication
{
    public class UserAuth : IUserAuth
    {
        public int Id { get; }
        public string Name { get; }
        public string Password { get; }

        public UserAuth(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
    }
}