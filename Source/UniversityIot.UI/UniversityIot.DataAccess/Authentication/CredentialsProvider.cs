namespace UniversityIot.DataAccess.Authentication
{
    public class CredentialsProvider : ICredentialsProvider
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