namespace UniversityIot.UsersService.Mapping
{
    using AutoMapper;
    using UniversityIot.VitoControlApi.Mapping.Profiles;

    public class ExternalServiceMapper
    {
        /// <summary>
        /// Register mapping profiles
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<UsersProfile>();
                cfg.AddProfile<GatewaysProfile>();
            });
        }
    }
}