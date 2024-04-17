using cp2___.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cp2___.net.Controllers.Home
{
        public class UsersController : Controller
        {
            private readonly ILogger<UsersController> _logger;

            public UsersController(ILogger<UsersController> logger)
            {
                _logger = logger;
            }

            public IActionResult Index()
            {
                return View();
            }


            [HttpPost]
            public IActionResult Register(User models)
            {
                if (ModelState.IsValid)
                {
                  
                    return RedirectToAction("Index");
                }

                return View(models);
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
