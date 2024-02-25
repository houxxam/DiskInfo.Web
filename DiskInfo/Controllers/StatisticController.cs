using DiskInfo.Data;
using Microsoft.AspNetCore.Mvc;

namespace DiskInfo.Controllers
{
    public class StatisticController : Controller
    {
        private readonly AppDbContext _context;
        public StatisticController(AppDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            hddCount();
            ssdCount();
            return View();
        }
        public int hddCount()
        {
            var count = _context.Disks.Where(t => t.DiskType.ToLower() == "hdd").Count();
            ViewBag.hddCount = count;
            return count;

        }
        public int ssdCount()
        {
            var count = _context.Disks.Where(t => t.DiskType.ToLower() == "ssd").Count();
            ViewBag.ssdCount = count;
            return count;

        }
    }
}
