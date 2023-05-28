using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;
        private ProductSum _productSum;
        public HomeController(ILogger<HomeController> logger, IRepository repo, ProductSum productSum)
        {
            _logger = logger;
            _repo = repo;
            _productSum = productSum;
        }

        public IActionResult Index()
        {
            ViewBag.HomeControllerGuid = _repo.ToString();
            ViewBag.TotalGuid = _productSum.repository.ToString();
            ViewBag.Total = _productSum.Total;
            return View(_repo.Products);
        }

        public IActionResult Privacy(string msg)
        {
            return View(msg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}