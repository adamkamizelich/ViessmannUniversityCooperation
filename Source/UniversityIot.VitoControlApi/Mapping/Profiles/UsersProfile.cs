namespace UniversityIot.VitoControlApi.Mapping.Profiles
{
    using AutoMapper;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Messages.User, User>();
        }
    }
}