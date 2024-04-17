using cp2___.net.Models;
using cp2___.net.Models.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace cp2___.net.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User models)
        {
            if (ModelState.IsValid)
            {
             
                var newUser = new User
                {
                    Name = models.Name,
                    LastName = models.LastName,
                    Email = models.Email,
                    Password = models.Password,
                    ConfPassword = models.ConfPassword,
                    Phone = models.Phone,

                };

                _context.Users.Add(newUser);

                _context.SaveChanges();

           
                return RedirectToAction("Login");
            }
            return View(models);
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
               
                return RedirectToAction("Index", "Home");
            }

          
            ModelState.AddModelError("", "Credenciais inválidas.");
            return View();
        }
    }
}
    