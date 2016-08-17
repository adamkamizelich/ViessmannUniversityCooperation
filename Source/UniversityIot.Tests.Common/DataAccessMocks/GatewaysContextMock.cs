namespace UniversityIot.Tests.Common.DataAccessMocks
{
    using UniversityIot.GatewaysDataAccess;

    public class GatewaysContextMock : GatewaysContext
    {
        public GatewaysContextMock() :
            base("Test_UniversityIot.Gateways")
        {

        }
    }
}
