namespace UniversityIot.UI.Core
{
    public interface IUserAuth
    {
        int Id { get; }
        string Name { get; }
        string Password { get; }
    }
}