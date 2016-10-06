namespace DomainModel.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Controller
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ControllerKey { get; set; }

        [MaxLength(20)]
        public string Serial { get; set; }

        // foreign key convention.
        public int GatewayId { get; set; }

        public Gateway Gateway { get; set; }

        public ControllerStatus Status { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int ControllerTypeKey { get; set; }

        [ForeignKey(nameof(ControllerTypeKey))]
        public ControllerType ControllerType { get; set; }
    }
}
