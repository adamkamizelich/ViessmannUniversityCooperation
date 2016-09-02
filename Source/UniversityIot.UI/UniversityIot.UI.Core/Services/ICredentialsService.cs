namespace UniversityIot.UI.Core.Services
{
    public interface ICredentialsService
    {
        string UserName { get; }

        string Md5Password { get; }

        void SaveCredentials(string userName, string md5Password);

        void DeleteCredentials();

        bool CredentialsExist();
    }
}