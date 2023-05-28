
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dzCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string value, string date)
        {
            CookieOptions option = new CookieOptions();
            
            option.Expires = DateTime.Parse(date);
            Response.Cookies.Append(value, date.ToString(), option);
            return RedirectToAction("CheckCookie", option);
        }
        public IActionResult CheckCookie(CookieOptions cookie)
        {
            if(cookie == null) { return NoContent(); }
            else
            {
                ViewBag.mess = "Cookies exist";
                return View();
            }
        }
      

    }
}