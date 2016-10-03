namespace DataAccessLayer.UoW.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW;

    public class GatewayUoWRepository : UoWRepositoryBase<Gateway>
    {
        public GatewayUoWRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Gateway Add(Gateway entity)
        {

            this.UnitOfWork.Gateways.Add(entity);
            return entity;
        }

        public override void Update(Gateway entity)
        {
            this.UnitOfWork.Gateways.Update(entity);
        }

        public override void Delete(Gateway entity)
        {
            this.UnitOfWork.Gateways.Delete(entity);
        }

        public override async Task<IList<Gateway>> GetAllAsync()
        {
            return await this.UnitOfWork.Gateways.GetAllAsync();
        }

        public override async Task<Gateway> GetByIdAsync(int id)
        {
            return await this.UnitOfWork.Gateways.GetByIdAsync(id);
        }
    }
}
