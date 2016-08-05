namespace UniversityIot.GatewaysDataService
{
    using System.Threading.Tasks;
    using UniversityIot.GatewaysDataService.Models;

    public interface IGatewaysDataService
    {
        Task SaveGateway(Gateway gateway);
    }
}
