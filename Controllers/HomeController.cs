using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;
using WebAppMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebAppMVCContext _context;

        public HomeController(ILogger<HomeController> logger, WebAppMVCContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var category1 = await _context.Category.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == 5);
            var category2 = await _context.Category.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == 3);
            ViewBag.Category1 = category1;
            ViewBag.Category2 = category2;
            return View();
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
    }
}
