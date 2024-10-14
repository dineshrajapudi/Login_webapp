using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_Login.Data;
using WebApplication_Login.Models;

namespace WebApplication_Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        //public HomeController(AppDbContext db)
        //{
        //    _db = db;
        //}

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "welcome";
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Create obj)
        {
            if (ModelState.IsValid)
            {
                _db.creates.Add(obj);
                _db.SaveChanges();
                DataCp();
                return RedirectToAction("CreateSuccess");
            }
            return View(obj);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginUser1 obj1)
        {
            if (ModelState.IsValid)
            {
                //return RedirectToAction("Solar");
                //using (var db1 = new AppDbContext()) // Use 'using' to ensure proper disposal of the context
                {
                    var obj2 = _db.LoginBTNClicks.FirstOrDefault(a => a.UserNAME1 == obj1.UserNAME1 && a.Password11 == obj1.Password11);
                    if (obj2 != null)
                    {
                        return View("~/Views/Home/Solar.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("LoginFail");
                    }
                }
            }
            // If ModelState is invalid, return the same view with validation errors
            return View(obj1);
        }

        public IActionResult CreateSuccess()
        {
            return View();
        }
        public IActionResult Solar()
        {
            return View();
        }
        public IActionResult LoginFail()
        {
            return View();
        }
        //    [HttpPost]
        //public IActionResult Login()
        //{
        //    if (UserExists(UserName, password11))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return "Invalid data";
        //    }
        //    }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //public bool UserExists(string username, string password11)
        //{
        //    using (AppDbContext context = new AppDbContext())
        //    {
        //        var obj= context.creates.Any(u => u.UserName == username && u.password11 == password11);
        //    }
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
        public void DataCp()
        {
            var source = _db.creates.OrderByDescending(x => x.Id).FirstOrDefault();

            if (source != null)
            {
                // Create a new item in DestinationTable
                var d = new LoginUser1
                {
                    UserNAME1 = source.UserName,
                    Password11 = source.Password
                    // Map other properties as needed
                };
                _db.LoginBTNClicks.Add(d);
                _db.SaveChanges();
            }
            
        }
    }
}
