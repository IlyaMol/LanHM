namespace Project.Core.Model
{
    public enum EBusType : ushort
    {
        Unknown = 0,
        SCSI = 1,
        ATAPI = 2,
        ATA = 3,
        SSA = 5,
        USB = 7,
        RAID = 8,
        iSCSI = 9,
        SAS = 10,
        SATA = 11,
        SD = 12,
        MMC = 13,
        MAX = 14,
        NVMe = 17
    }
}
