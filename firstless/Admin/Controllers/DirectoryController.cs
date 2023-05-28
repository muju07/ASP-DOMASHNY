using Admin.Models;
using asp.Lib;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        public DirectoryController(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index(string message)
        {
            return View(message);
        }
        public IActionResult DirectoryRoomProperties(int page = 0)
        {
            {
                var data = new RoomPropertiesModel()
                {
                    RoomProperty = new RoomProperty(),
                    RoomProperties = new List<RoomProperty>()
                };

                return View(data);
            }
        }
            [HttpPost]
            public IActionResult RoomProperties()
            {
                string NameProperties = Request.Form["NameProperties"];
                string DescProperties = Request.Form["Description"];
                return View("Index", "данные добавлены");
            }
            [HttpPost]
            public IActionResult RoomPropertiesModel(RoomProperty roomProperties)
            {
                RoomService roomService = new RoomService();
                roomService.AddRoomProperties(roomProperties);
                return View("index", "");
            }
            [HttpPost]
            public async Task<IActionResult> RoomPropertiesModel(IFormFile photo)
            {
                using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, photo.FileName), FileMode.OpenOrCreate))
                {
                    await photo.CopyToAsync(stream);
                }
                string fileName = photo.FileName;
                return View("Index", "Данные добавлены");

            }
        }
    
}

