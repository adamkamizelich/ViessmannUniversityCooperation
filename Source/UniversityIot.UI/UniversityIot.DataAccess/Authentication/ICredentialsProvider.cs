namespace UniversityIot.DataAccess.Authentication
{
    public interface ICredentialsProvider
    {
        IUserAuth UserAuth { get; }
        bool IsUserSessionInitialized { get; }
        void InitUserSession(IUserAuth userAuth);
        void ClearUserSession();
    }
}