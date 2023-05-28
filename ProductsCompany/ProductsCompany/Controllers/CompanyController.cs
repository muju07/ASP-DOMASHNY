using Microsoft.AspNetCore.Mvc;
using ProductsCompany.Models;

namespace ProductsCompany.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Production()
        {
            List<Products> list = new List<Products>();
            list.Add(new Products
            {
                Name = "ccc",
                Description = "ccccccc",
                Price = 23333,
            });
           
           ViewBag.items = list;
            
            return View(list);
        }
        public IActionResult Images()
        {
            return View();
        }
    }
}
