using DiskInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace DiskInfo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Disk> Disks { get; set; }
    }
}
