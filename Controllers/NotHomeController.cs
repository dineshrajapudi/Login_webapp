using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Login.Controllers
{
    public class NotHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Zoo() => View();
    }
}
