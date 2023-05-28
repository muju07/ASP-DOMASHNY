using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    
    public IActionResult Test()
    {
        return View();
    }
}