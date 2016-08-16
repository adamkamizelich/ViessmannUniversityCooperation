namespace UniversityIot.UsersService.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using AutoMapper;
    using UniversityIot.UsersDataService;
    using UniversityIot.UsersService.Http.Attributes;

    /// <summary>
    /// Users controller
    /// </summary>
    [RoutePrefix("users")]
    [BasicAuthentication]
    public class UsersController : ApiController
    {
        /// <summary>
        /// The users data service
        /// </summary>
        private readonly IUsersDataService usersDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="usersDataService">The users data service.</param>
        public UsersController(IUsersDataService usersDataService)
        {
            this.usersDataService = usersDataService;
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <returns>
        /// List of users
        /// </returns>
        //[Route("")]
        //public async Task<IHttpActionResult> Get()
        //{
        //    //var users = await this.usersDataService.GetAllUsers();
        //    //var mappedUsers = Mapper.Map<IEnumerable<Messages.User>>(users);
        //    //return Ok(mappedUsers);
        //}

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User model
        /// </returns>
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await this.usersDataService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var mappedUser = Mapper.Map<Messages.User>(user);
            return Ok(mappedUser);
        }

        /// <summary>
        /// Gets the user
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User's insallations
        /// </returns>
        [Route("{id}/installations")]
        public async Task<IHttpActionResult> GetInstallations(int id)
        {
            var installations = await this.usersDataService.GetUsersInstallationsAsync(id);
            if (installations == null)
            {
                return NotFound();
            }
            return Ok(installations);
        }
    }
}