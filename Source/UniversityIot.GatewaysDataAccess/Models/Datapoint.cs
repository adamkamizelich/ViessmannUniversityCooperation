namespace UniversityIot.GatewaysDataAccess.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UniversityIot.Enums;

    public class Datapoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }

        public string HexAdress { get; set; }

        public SettingDataType DataType { get; set; }

        public bool IsReadonly { get; set; }
    }
}
