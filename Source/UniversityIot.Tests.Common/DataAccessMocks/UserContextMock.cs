namespace UniversityIot.Tests.Common.DataAccessMocks
{
    using UniversityIot.UsersDataAccess;

    public class UserContextMock : UsersContext
    {
        public UserContextMock() :
            base("Test_UniversityIot.Users")
        {
            
        }
    }
}
