using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityIot.VitoControlApi.Mapping.Profiles
{
    using AutoMapper;
    using UniversityIot.VitoControlApi.Models.DataObjects;

    public class GatewaysProfile : Profile
    {
        public GatewaysProfile()
        {
            CreateMap<Messages.Gateway, Gateway>();
            CreateMap<Messages.GatewaySetting, GatewayDatapoint>();
        }
    }
}