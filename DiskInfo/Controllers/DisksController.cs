using DiskInfo.Data;
using DiskInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Disks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disk>>> GetDisks()
        {
            if (_context.Disks == null)
            {
                return NotFound();
            }
            return await _context.Disks.ToListAsync();
        }

        // GET: api/Disks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disk>> GetDisk(int id)
        {
            if (_context.Disks == null)
            {
                return NotFound();
            }
            var disk = await _context.Disks.FindAsync(id);

            if (disk == null)
            {
                return NotFound();
            }

            return disk;
        }

        // http://localhost:5290/api/Disks/Add?_diskName=&_diskType=&_diskTotalSpace=&_diskFreeSpace=&_diskHealth=&_lastCheckDate=&_diskSerialNumber=&_hostName=&_hostSerialNumber=
        // /api/disks/add
        [Route("Add")]
        [HttpGet]
        public async Task<ActionResult<Disk>> PostDisk(
            string _diskName,
            string _diskType,
            string _diskTotalSpace,
            string _diskFreeSpace,
            string _diskHealth,
            string _lastCheckDate,
            string _diskSerialNumber,
            string _hostName,
            string _hostSerialNumber,
            string _hostOs
            )
        {
            var Data = await _context.Disks.FirstOrDefaultAsync(s => s.DiskSerialNumber == _diskSerialNumber);


            if (_diskType.ToLower().Contains("rpm") || _diskType.ToLower().Contains("inconnu"))
            {
                _diskType = "HDD";
            }
            else
            {
                _diskType = "SSD";
            }

            if (Data == null)
            {
                Disk disk = new Disk
                {
                    DiskName = _diskName,
                    DiskType = _diskType,
                    DiskTotalSpace = _diskTotalSpace,
                    DiskFreeSpace = _diskFreeSpace,
                    DiskHealth = _diskHealth,
                    DiskSerialNumber = _diskSerialNumber,
                    LastCheckDate = _lastCheckDate,
                    HostName = _hostName,
                    HostSerialNumber = _hostSerialNumber,
                    HostOs = _hostOs


                };
                _context.Add(disk);
                _context.SaveChanges();
                return Ok(disk);
            }
            else
            {

                Data.DiskName = _diskName;
                Data.DiskType = _diskType;
                Data.DiskTotalSpace = _diskTotalSpace;
                Data.DiskFreeSpace = _diskFreeSpace;
                Data.DiskHealth = _diskHealth;
                Data.DiskSerialNumber = _diskSerialNumber;
                Data.LastCheckDate = _lastCheckDate;
                Data.HostName = _hostName;
                Data.HostSerialNumber = _hostSerialNumber;
                Data.HostOs = _hostOs;

                _context.Update(Data);
                _context.SaveChanges();
                return Ok(Data);
            }

        }

        [HttpGet]
        [Route("hddCount")]
        public IActionResult GetHddCount()
        {
            var count = _context.Disks.Count(d => d.DiskType.ToLower() == "hdd");
            return Ok(count);
        }

        [HttpGet]
        [Route("ssdCount")]
        public IActionResult GetSsdCount()
        {
            var count = _context.Disks.Count(d => d.DiskType.ToLower() == "ssd");
            return Ok(count);
        }


    }
}
