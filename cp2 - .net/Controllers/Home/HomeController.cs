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

            [HttpPost]
            public IActionResult Register(User models)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.Email == models.Email);
            if (user != null)
            {
                return BadRequest("Usu�rio ja existe");
            }
            User newUser = new User
            {
                Id = models.Id,
                Email = models.Email,
                Name = models.Name,
                Password = models.Password,
                Phone = models.Phone,
            };
            _dataContext.Add(newUser);
            _dataContext.SaveChanges();
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
