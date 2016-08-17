namespace UniversityIot.Components
{
    public interface IPasswordEncoder
    {
        string Hash(string input);

        bool Verify(string input, string hash);
    }
}