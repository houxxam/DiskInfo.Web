using DiskInfo.Data;
using DiskInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiskInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Get Disks
        public async Task<IActionResult> Index()
        {
            var data = await _context.Disks.ToListAsync();

            return View(data);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disks == null)
            {
                return NotFound();
            }

            var disk = await _context.Disks.FirstOrDefaultAsync(i => i.Id == id);
            if (disk == null)
            {
                return NotFound();
            }
            return View(disk);
        }

    }
}
