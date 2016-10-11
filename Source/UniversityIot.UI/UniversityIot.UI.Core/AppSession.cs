namespace UniversityIot.UI.Core
{
    public class AppSession : IAppSession
    {
        public void InitUserSession(IUserAuth userAuth)
        {
            UserAuth = userAuth;
        }

        public void ClearUserSession()
        {
            UserAuth = null;
        }

        public bool IsUserSessionInitialized => UserAuth != null;

        public IUserAuth UserAuth { get; private set; }
    }
}