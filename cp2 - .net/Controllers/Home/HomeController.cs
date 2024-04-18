using cp2___.net.Models;
using cp2___.net.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cp2___.net.Controllers
{
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;
            private readonly DataContext _dataContext;
            
        public HomeController(ILogger<HomeController> logger,DataContext dataContext)
            {
                 _dataContext = dataContext;
                 _logger = logger;
            }

            public IActionResult Index()
            {
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
