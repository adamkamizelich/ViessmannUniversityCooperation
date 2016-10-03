namespace DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces
{
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;

    public interface IControllerTypeRepository : IRepository<ControllerType>
    {
        Task<ControllerType> GetByHardwareIndexAndSoftwareIndexAsync(int hardwareIndex, int softwareIndex);
    }
}
