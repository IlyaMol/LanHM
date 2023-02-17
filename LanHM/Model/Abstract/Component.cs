using System.Text.Json.Serialization;

namespace Project.Core.Model
{
    public abstract class Component : IComponent
    {
        #region Fields
        private Guid _id;
        private string? _manufacturer;
        private string? _model;
        private string? _serialNumber;
        #endregion

        #region Properties
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id == value) return;
                _id = value;
            }
        }
        public string? Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (_manufacturer == value) return;
                _manufacturer = value;
            }
        }
        public string? Model
        {
            get { return _model; }
            set
            {
                if (_model == value) return;
                _model = value;
            }
        }
        public string? SerialNumber
        {
            get { return _serialNumber; }
            set
            {
                if (_serialNumber == value) return;
                _serialNumber = value;
            }
        }
        #endregion

        #region Wmi_common_stuff
        [JsonIgnore]
        public string WmiScope { get; internal set; }
        [JsonIgnore]
        public string WmiObjectInitialClass { get; internal set; }
        [JsonIgnore]
        public string? WmiUniqueIdPropertyName { get; internal set; }
        [JsonIgnore]
        public string[]? WmiObjectAdditionalClasses { get; internal set; }
        [JsonIgnore]
        public Dictionary<string, string> WmiFieldsDescription { get; internal set; }
        #endregion
    }
}
