namespace UniversityIot.UsersService.Mapping.Profiles
{
    using AutoMapper;
    using UniversityIot.UsersDataAccess.Models;
    using Messages = UniversityIot.Messages;

    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile()
        {
            CreateMap<User, Messages.User>();
        }
    }
}