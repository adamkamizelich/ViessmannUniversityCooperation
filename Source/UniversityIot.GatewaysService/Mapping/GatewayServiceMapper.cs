namespace UniversityIot.UsersService.Mapping
{
    using AutoMapper;
    using UniversityIot.GatewaysService.Mapping.Profiles;

    public class GatewayServiceMapper
    {
        /// <summary>
        /// Register mapping profiles
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<GatewaysServiceProfile>();
            });
        }
    }
}