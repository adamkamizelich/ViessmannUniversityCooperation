namespace UniversityIot.UI.Core.ViewModels
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