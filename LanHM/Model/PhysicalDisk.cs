using System;

namespace Project.Core.Model
{
    public class PhysicalDisk : Component
    {
        // MSFT_PhysicalDisk
        public EBusType? BusType { get; set; }
        public EMediaType? MediaType { get; set; }
        public EHealthStatus? HealthStatus { get; set; }

        // MSFT_Disk
        public ulong Size { get;  set; }
        public string? BootFromDisk { get; set; }
        public string? FriendlyName { get; set; }
        public bool IsBoot { get; set; }
        public bool IsSystem { get; set; }
        public bool IsRemovable { get; set; }
        public bool PoweredOn { get; set; }
        public bool Replaceable { get; set; }

        public PhysicalDisk() : base()
        {
            WmiScope = "Root\\CIMV2";
            WmiObjectInitialClass = "MSFT_PhysicalDisk";
            WmiUniqueIdPropertyName = "SerialNumber";
            WmiObjectAdditionalClasses = new string[2] { "MSFT_Disk", "CIM_PhysicalMedia" };

            //C# class prop to WMI class dependency
            WmiFieldsDescription = new Dictionary<string, string>
            {
                { "BusType", "BusType" },
                { "MediaType", "MediaType" },
                { "HealthStatus", "HealthStatus" },
                { "FriendlyName", "FriendlyName" },
                { "Manufacturer", "Manufacturer" },
                { "SerialNumber", "SerialNumber" },
                { "Size", "Size" },
                { "Model", "Model" },
                { "BootFromDisk", "BootFromDisk" },
                { "IsBoot", "IsBoot" },
                { "IsSystem", "IsSystem" },
                { "IsRemovable", "IsRemovable" },
                { "PoweredOn", "PoweredOn" },
                { "Replaceable", "Replaceable" }
            };
        }

        public override string ToString()
        {
            return
                $"BusType : {BusType}\n" +
                $"MediaType: {MediaType}\n" +
                $"HealthStatus: {HealthStatus}\n" +
                $"Size: {Size}\n" +
                $"Model: {Model}\n" +
                $"IsBoot: {IsBoot}\n" +
                $"IsSystem: {IsSystem}\n" +
                $"Manufacturer: {Manufacturer}\n" +
                $"SerialNumber: {SerialNumber}\n" +
                $"BootFromDisk: {BootFromDisk}\n" +
                $"FriendlyName: {FriendlyName}\n" +
                $"IsRemovable: {IsRemovable}\n" +
                $"PoweredOn: {PoweredOn}\n" +
                $"Replaceable: {Replaceable}\n";
        }
    }
}
