using Newtonsoft.Json;

namespace UniversityIot.DataAccess.Models
{
    public class DatapointModel : BaseModel
    {
        private string datapointValue;
        private string description;
        private string hexAddress;
        private long id;
        private bool isReadOnly;

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value == this.id)
                {
                    return;
                }

                this.id = value;
                this.OnPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (value == this.description)
                {
                    return;
                }

                this.description = value;
                this.OnPropertyChanged();
            }
        }

        [JsonProperty("hexAdress")]
        public string HexAddress
        {
            get
            {
                return this.hexAddress;
            }
            set
            {
                if (value == this.hexAddress)
                {
                    return;
                }

                this.hexAddress = value;
                this.OnPropertyChanged();
            }
        }

        [JsonProperty("value")]
        public string DatapointValue
        {
            get
            {
                return this.datapointValue;
            }
            set
            {
                if (Equals(value, this.datapointValue))
                {
                    return;
                }

                this.datapointValue = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return this.isReadOnly;
            }
            set
            {
                if (value == this.isReadOnly)
                {
                    return;
                }

                this.isReadOnly = value;
                this.OnPropertyChanged();
            }
        }
    }
}