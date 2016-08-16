namespace UniversityIot.UsersService.Mapping
{
    using AutoMapper;
    using UniversityIot.UsersService.Mapping.Profiles;

    public class UserServiceMapper
    {
        /// <summary>
        /// Register mapping profiles
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<UsersServiceProfile>();
            });
        }
    }
}