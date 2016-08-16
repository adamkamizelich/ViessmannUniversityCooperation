namespace UniversityIot.GatewaysService.Mapping.Profiles
{
    using AutoMapper;
    using UniversityIot.GatewaysDataService.Models;

    public class GatewaysServiceProfile : Profile
    {
        public GatewaysServiceProfile()
        {
            CreateMap<Gateway, Messages.Gateway>();
            CreateMap<GatewaySetting, Messages.GatewaySetting>();
        }
    }
}