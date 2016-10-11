namespace UniversityIot.UI.Core
{
    public interface IAppSession
    {
        IUserAuth UserAuth { get; }
        bool IsUserSessionInitialized { get; }
        void InitUserSession(IUserAuth userAuth);
        void ClearUserSession();
    }
}