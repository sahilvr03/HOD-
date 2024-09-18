using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Data; // Adjust the namespace for your DbContext
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Injecting DbContext to interact with Users table

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Redirect if the user is not authenticated
            if (!User.Identity.IsAuthenticated)
            {
                return this.Redirect("~/identity/account/login");
            }

            // Fetch the number of users dynamically from the database
            var userCount = await _context.Employees.CountAsync();
            ViewBag.UserCount = userCount;


            var usersCount = await _context.Users.CountAsync();
            ViewBag.UsersCount = usersCount;
            // Passing the count to the view

            var LeaveCount = await _context.LeavesType.CountAsync();
            ViewBag.LeaveCount = LeaveCount;

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
