using UniversityIot.UI.Core.MVVM;

namespace UniversityIot.UI.Core.Models
{
    public class DatapointModel : BaseViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string HexAddress { get; set; }
        public object Value { get; set; }
        public bool IsReadOnly { get; set; }
    }
}