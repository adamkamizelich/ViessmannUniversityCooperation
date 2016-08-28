namespace UniversityIot.VitoControlApi.Handlers.Users
{
    using System.Threading.Tasks;
    using UniversityIot.VitoControlApi.Models;

    public interface IGetByIdHandler
    {
        /// <summary>
        /// Internals of handling message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// Response model
        /// </returns>
        Task<GetUserResponse> Handle(GetUserRequest message);
    }
}