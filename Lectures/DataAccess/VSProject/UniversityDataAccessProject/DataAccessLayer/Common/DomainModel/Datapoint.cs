namespace DataAccessLayer.Common.DomainModel
{
    public class Datapoint : IEntity
    {
        public int? Id { get; set; }

        public string HexAddress { get; set; }

        public string Name { get; set; }
    }
}
