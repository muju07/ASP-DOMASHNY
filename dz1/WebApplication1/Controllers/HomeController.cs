using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        public string Index()
        {
            var osVersion = Environment.OSVersion.ToString();
            var compName = Environment.MachineName.ToString();
          
            return $"Os version is {osVersion}, computerName is {compName}";
        }
    }

}
