using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKYResturant.Models;
using System.Diagnostics;

namespace SKYResturant.Controllers
{
    
    public class HomeController : Controller
    {
        private   ILogger<HomeController> _logger;
        private readonly SkyDbContext _context;

        public HomeController(ILogger<HomeController> logger, SkyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin"); // Redirect to the admin/index page
            }
            else
            {
                return _context.Menus != null ?
                              View(await _context.Menus.ToListAsync()) :
                              Problem("Entity set 'SkyDbContext.Menus'  is null.");
            }  //return View();
        } 
        public IActionResult Aboutus()
        {
            return View();
        } 
        //public IActionResult Menu()
        //{
        //    return View("~/Views/Home/Menu.cshtml");
        //}

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