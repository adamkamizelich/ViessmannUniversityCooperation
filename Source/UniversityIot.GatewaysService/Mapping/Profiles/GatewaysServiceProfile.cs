namespace UniversityIot.GatewaysService.Mapping.Profiles
{
    using AutoMapper;
    using GatewaysDataAccess.Models;
    using Messages = UniversityIot.Messages;

    public class GatewaysServiceProfile : Profile
    {
        public GatewaysServiceProfile()
        {
            CreateMap<Gateway, Messages.Gateway>();
            CreateMap<GatewaySetting, Messages.GatewaySetting>();
        }
    }
}