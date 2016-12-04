namespace UniversityIot.UsersService.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using UniversityIot.UsersDataAccess.Models;
    using UniversityIot.UsersDataService;
    using UniversityIot.UsersService.Helpers;
    using UniversityIot.UsersService.Models;

    public class UsersController : ApiController
    {
        private readonly IUsersDataService usersDataService;

        public UsersController(IUsersDataService usersDataService)
        {
            this.usersDataService = usersDataService;
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok("a");
        }

        private static UserViewModel MapUser(User user)
        {
            var userVM = new UserViewModel()
            {
                CustomerNumber = user.CustomerNumber,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };

            foreach (var userGateway in user.UserGateways)
            {
                userVM.UserGateways.Add(new UserGatewayViewModel()
                {
                    GatewaySerial = userGateway.GatewaySerial,
                    Id = userGateway.Id,
                    AccessType = userGateway.AccessType.ToString()
                });
            }

            return userVM;
        }
    }
}