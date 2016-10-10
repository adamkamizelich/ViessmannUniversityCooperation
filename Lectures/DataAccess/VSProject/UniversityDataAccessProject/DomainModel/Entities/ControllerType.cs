namespace DomainModel.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Controller Type
    /// </summary>
    [Table("ControllerType")]
    public class ControllerType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public int HardwareIndex { get; set; }

        public int SoftwareIndexMin { get; set; }

        public int SoftwareIndexMax { get; set; }

        public IList<Datapoint> Datapoints { get; set; }
    }
}
