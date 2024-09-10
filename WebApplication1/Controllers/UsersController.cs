using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
