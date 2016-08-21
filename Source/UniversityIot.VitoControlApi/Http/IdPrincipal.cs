namespace UniversityIot.VitoControlApi.Http
{
    using System.Security.Principal;

    public class IdPrincipal : GenericPrincipal
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IdPrincipal" /> class.
        /// </summary>
        /// <param name="identity">A basic implementation of <see cref="T:System.Security.Principal.IIdentity" /> that represents any user.</param>
        /// <param name="userId">The user identifier.</param>
        public IdPrincipal(IIdentity identity, int userId) : base(identity, null)
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public int UserId { get; private set; }
    }
}