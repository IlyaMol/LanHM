namespace Project.Core.Model
{
    public class RamStick : Component, IComponent
    {
        public EFormFactor FormFactor { get; set; }
        public EMemoryType MemoryType { get; set; }

        public string? BankLabel { get; set; }
        public ulong? Capacity { get; set; }
        public uint? ConfiguredClockSpeed { get; set; }
        public string? Name { get; set; }
        public uint? Speed { get; set; }

        public RamStick() : base()
        {
            WmiScope = new string[1] { @"Root\CIMV2" };
            WmiObjectInitialClass = "Win32_PhysicalMemory";
            WmiUniqueIdPropertyName = "SerialNumber";
            WmiObjectAdditionalClasses = new string[0] {};

            WmiFieldsDescription = new Dictionary<string, string>
            {
                {"FormFactor", "FormFactor" },
                {"MemoryType", "MemoryType" },
                {"BankLabel", "BankLabel" },
                {"Capacity", "Capacity" },
                {"ConfiguredClockSpeed", "ConfiguredClockSpeed" },
                {"Manufacturer", "Manufacturer" },
                {"Model", "Model" },
                {"Name", "Name" },
                {"SerialNumber", "SerialNumber" },
                {"Speed", "Speed" }
            };
        }

        public override string ToString()
        {
            return
                $"FormFactor : {FormFactor}\n" +
                $"MemoryType: {MemoryType}\n" +
                $"BankLabel: {BankLabel}\n" +
                $"Capacity: {Capacity}\n" +
                $"ConfiguredClockSpeed: {ConfiguredClockSpeed}\n" +
                $"Manufacturer: {Manufacturer}\n" +
                $"Model: {Model}\n" +
                $"Name: {Name}\n" +
                $"SerialNumber: {SerialNumber}\n" +
                $"Speed: {Speed}";
        }
    }

    public enum EMemoryType : ushort
    {
        Unknown = 0,
        Other   = 1,
        DRAM    = 2,
        EDRAM   = 6,
        VRAM    = 7,
        SRAM    = 8,
        RAM     = 9,
        ROM     = 10,
        Flash   = 11,
        SDRAM   = 17,
        DDR     = 20,
        DDR2    = 21,
        DDR3    = 25,
        DDR4    = 26,
    }

    public enum EFormFactor : ushort
    {
        Unknown     = 0,
        Other       = 1,
        SIP         = 2,
        DIP         = 3,
        Proprietary = 6,
        SIMM        = 7,
        DIMM        = 8,
        TSOP        = 9,
        RIMM        = 11,
        SODIMM      = 12,
        SRIMM       = 13,
        SMD         = 14,
        SSMP        = 15,
        QFP         = 16,
        TQFP        = 17,
        SOIC        = 18,
        BGA         = 21,
        FPBGA       = 22,
        LGA         = 23
    }
}