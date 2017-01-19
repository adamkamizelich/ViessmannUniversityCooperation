namespace UniversityIot.UI.Core
{
    public class AppSession : IAppSession
    {
        public bool IsUserSessionInitialized => this.UserAuth != null;
        public IUserAuth UserAuth { get; private set; }

        public void InitUserSession(IUserAuth userAuth)
        {
            this.UserAuth = userAuth;
        }

        public void ClearUserSession()
        {
            this.UserAuth = null;
        }
    }
}