namespace UniversityIot.UsersService.Mapping.Profiles
{
    using AutoMapper;
    using UniversityIot.UsersDataService.Models;

    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile()
        {
            CreateMap<User, Messages.User>();
        }
    }
}