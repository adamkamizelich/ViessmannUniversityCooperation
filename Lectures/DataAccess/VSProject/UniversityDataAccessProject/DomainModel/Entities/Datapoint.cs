namespace DomainModel.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Datapoint
    {
        public int Id { get; set; }

        [StringLength(4, MinimumLength = 4)]
        public string HexAddress { get; set; }

        public string Name { get; set; }
    }
}
