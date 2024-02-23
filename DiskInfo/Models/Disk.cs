namespace DiskInfo.Models
{
    public class Disk
    {
        public int Id { get; set; }
        public string DiskName { get; set; }
        public string DiskType { get; set; }
        public string DiskTotalSpace { get; set; }
        public string DiskFreeSpace { get; set; }
        public string DiskHealth { get; set; }
        public string LastCheckDate { get; set; }
        public string DiskSerialNumber { get; set; }
        public string HostName { get; set; }
        public string HostSerialNumber { get; set; }
    }
}
