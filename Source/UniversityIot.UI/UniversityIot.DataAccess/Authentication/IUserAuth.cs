namespace UniversityIot.DataAccess.Authentication
{
    public interface IUserAuth
    {
        int Id { get; }
        string Name { get; }
        string Password { get; }
    }
}