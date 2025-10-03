using System.Diagnostics;
using MedCare365.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedCare365.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();


        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("registernewuser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterNewUser(RegisterDto registerDto)
        {
            if (registerDto == null)
                return BadRequest();

            // Check validation
            if (!ModelState.IsValid)
            {
                // Return the same view with validation messages
                return View(registerDto);
            }

            // Map DTO to User entity
            User user = new User()
            {
                userName = registerDto.UserName,
                email = registerDto.Email,
                phone = registerDto.Phone,
                password = registerDto.Password
            };

            // Add user and save changes asynchronously
            await  _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Registration successful!";
            return RedirectToAction("Login"); // Redirect to login page
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
