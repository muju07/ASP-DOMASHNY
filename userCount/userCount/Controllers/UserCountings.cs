using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userCount.Models;

namespace userCount.Controllers
{
    public class UserCountings : Controller
    {
        public IActionResult Index()
        {
            //HttpContext context = new HttpContext();

           
            return View();
        }
    }
}
